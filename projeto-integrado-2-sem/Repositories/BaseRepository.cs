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

        private Stream dataStream;
        private SerializedData data;
        private IFormatter formatter = new BinaryFormatter();

        [Serializable]
        private class SerializedData
        {
            public IStorableAdapter<T> storableAdapter;
            public IList<T> objects;
        }

        public BaseRepository(BufferedStream dataStream)
        {
            this.dataStream = dataStream;
        }

        public abstract void InitializeFile();

        protected void InitializeFile(IStorableAdapter<T> storableAdapter)
        {
            this.data = new SerializedData();
            this.data.storableAdapter = storableAdapter;
            this.data.objects = new List<T>();
            writeBuffer();
            InitComponents();
        }

        public void InitComponents()
        {
            loadBuffer();
        }

        public void Close()
        {
            dataStream.Dispose();
        }

        public virtual void Persist(T storable)
        {
            var finded = findById(storable.id);

            if (finded == null)
            {
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
    };

}
