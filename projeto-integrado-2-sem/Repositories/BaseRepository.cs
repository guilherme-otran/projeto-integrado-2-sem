using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace projeto_integrado_2_sem.Repositories
{ 
    public abstract class BaseRepository<T> where T : IStorable
    {
        public class InvalidFile : ArgumentException { };

        [Serializable]
        private class SerializedData
        {
            public IStorableAdapter<T> storableAdapter;
            public IList<T> objects;
        }

        public class DestroyRecordsEventArgs : EventArgs
        {
            private IEnumerable<T> storables;
            private IEnumerable<T> findedStorables;

            public DestroyRecordsEventArgs(IEnumerable<T> storables, IEnumerable<T> findedStorables)
            {
                this.storables = storables;
                this.findedStorables = findedStorables;
            }

            public IEnumerable<T> Storables { get { return storables; } }
            public IEnumerable<T> FindedStorables { get { return findedStorables; } }
        }

        private Stream dataStream;
        private SerializedData data;
        private IFormatter formatter = new BinaryFormatter();
        protected IStorableAdapter<T> StorableAdapter { get { return this.data.storableAdapter; } }

        protected EventHandlerList listEventDelegates = new EventHandlerList();

        static readonly object onDestroyRecordsEventKey = new object();
        public delegate void DestroyRecordsEventHandler(object sender, DestroyRecordsEventArgs e);
        public event DestroyRecordsEventHandler DestroyRecords
        {
            add { listEventDelegates.AddHandler(onDestroyRecordsEventKey, value); }
            remove { listEventDelegates.AddHandler(onDestroyRecordsEventKey, value); }
        }

        public BaseRepository(string fileName)
        {
            this.dataStream = new BufferedStream(new FileStream("C:\\temp\\" + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite));
        }

        public abstract void InitializeFile();

        public virtual void InitializeFile(IStorableAdapter<T> storableAdapter)
        {
            this.data = new SerializedData();
            this.data.storableAdapter = storableAdapter;
            this.data.objects = new List<T>();
            writeBuffer();
            InitComponents();
        }

        public virtual void InitComponents()
        {
            loadBuffer();
        }

        public virtual void Close()
        {
            dataStream.Dispose();
        }

        public virtual void Persist(T storable)
        {
            persistRecord(storable);
            writeBuffer();
        }

        public virtual void PersistMany(IEnumerable<T> storables)
        {
            foreach (var st in storables)
                persistRecord(st);

            writeBuffer();
        }

        protected virtual void persistRecord(T storable)
        {
            var finded = this.data.objects.FirstOrDefault(st => st.id == storable.id);

            if (finded == null)
            {
                if (storable.id == null)
                    this.data.storableAdapter.DefineIdentifier(storable);

                this.data.objects.Add(storable);
            }
            else
            {
                var idx = this.data.objects.IndexOf(finded);
                this.data.objects.RemoveAt(idx);
                this.data.objects.Insert(idx, storable);
            }
        }

        public virtual bool Any(Func<T, Boolean> func)
        {
            return this.data.objects.Any(func);
        }

        public virtual T Destroy(T storable)
        {
            var list = new List<T>();
            list.Add(storable);

            return DestroyMany(list).FirstOrDefault();
        }


        public virtual IEnumerable<T> DestroyMany(IEnumerable<T> storables)
        {
            var finds = storables.Select(str => this.data.objects.FirstOrDefault(node => node.id == str.id)).Where(rec => rec != null);

            if (finds.Count() > 0)
            {
                OnDestroyRecord(new DestroyRecordsEventArgs(storables, finds));

                foreach (var record in finds)
                    this.data.objects.Remove(record);

                writeBuffer();
            }

            return finds;
        }

        public T FindById(string id)
        {
            return FindBy(s => s.id == id);
        }

        protected T FindBy(Func<T, Boolean> condition)
        {
            var finded = this.data.objects.FirstOrDefault(condition);

            if (finded != null)
                finded = data.storableAdapter.FromSerializedToPublic(finded);

            return finded;
        }

        public virtual IList<T> FindManyWith(Func<T, bool> condition)
        {
            var list = new List<T>();
            foreach (var node in this.data.objects)
            {
                var record = data.storableAdapter.FromSerializedToPublic(node);
                if (condition(record))
                    list.Add(record);
            }

            return list;
        }

        protected IList<T> Nodes()
        {
            return this.data.objects;
        }

        public int Count()
        {
            return this.data.objects.Count();
        }

        public BindingList<T> List()
        {
            return List(r => true);
        }

        public BindingList<T> List(Func<T, bool> condition)
        {
            var list = new BindingList<T>();

            foreach (var record in FindManyWith(condition))
                list.Add(record);
               
            return list;
        }

        private void loadBuffer()
        {
            dataStream.Position = 0;

            try
            {
                var data = formatter.Deserialize(dataStream);
                this.data = (SerializedData)data;
            }
            catch (SerializationException)
            {
                throw new InvalidFile();
            }
        }

        private void writeBuffer()
        {
            dataStream.Position = 0;
            dataStream.SetLength(0);
            formatter.Serialize(dataStream, data);
            dataStream.Flush();
        }

        private void OnDestroyRecord(DestroyRecordsEventArgs e)
        {
            var handler = (DestroyRecordsEventHandler)listEventDelegates[onDestroyRecordsEventKey];
            handler(this, e);
        }
    };

}
