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

        public class DestroyRecordEventArgs : EventArgs
        {
            private T storable;
            private T findedStorable;

            public DestroyRecordEventArgs(T storable, T findedStorable)
            {
                this.storable = storable;
                this.findedStorable = findedStorable;
            }

            public T Storable { get { return storable; } }
            public T FindedStorable { get { return findedStorable; } }
        }

        private Stream dataStream;
        private SerializedData data;
        private IFormatter formatter = new BinaryFormatter();

        protected EventHandlerList listEventDelegates = new EventHandlerList();

        static readonly object onDestroyRecordEventKey = new object();
        public delegate void DestroyRecordEventHandler(object sender, DestroyRecordEventArgs e);
        public event DestroyRecordEventHandler DestroyRecord
        {
            add { listEventDelegates.AddHandler(onDestroyRecordEventKey, value); }
            remove { listEventDelegates.AddHandler(onDestroyRecordEventKey, value); }
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

            writeBuffer();
        }

        public virtual T Destroy(T storable)
        {
            var finded = this.data.objects.FirstOrDefault(st => st.id == storable.id);

            if (finded != null)
            {
                OnDestroyRecord(new DestroyRecordEventArgs(storable, finded));
                this.data.objects.Remove(finded);
                writeBuffer();
            }

            return finded;
        }

        public T findById(string id)
        {
            return findBy(s => s.id == id);
        }

        protected T findBy(Func<T, Boolean> condition)
        {
            var finded = this.data.objects.FirstOrDefault(condition);

            if (finded != null)
                finded = data.storableAdapter.FromSerializedToPublic(finded);

            return finded;
        }

        public int Count()
        {
            return this.data.objects.Count();
        }

        public BindingList<T> List()
        {
            var list = new BindingList<T>();

            foreach (var node in this.data.objects)
            {
                var record = data.storableAdapter.FromSerializedToPublic(node);
                list.Add(record);
            }
               
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

        private void OnDestroyRecord(DestroyRecordEventArgs e)
        {
            var handler = (DestroyRecordEventHandler)listEventDelegates[onDestroyRecordEventKey];
            handler(this, e);
        }
    };

}
