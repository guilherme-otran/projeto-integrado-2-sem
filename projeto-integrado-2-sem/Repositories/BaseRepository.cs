using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Repositories
{ 
    public abstract class BaseRepository<T> where T : IStorable
    {
        public class InvalidHeader : ArgumentException { };

        private IStorableAdapter<T> storableAdapter;
        private Stream dataStream;
        private List<StorableNode> buffer;
        private int autoIncrementValue = 0;

        protected class StorableNode
        {
            public string id;
            public string[] data;
        }

        public BaseRepository(IStorableAdapter<T> storableAdapter, BufferedStream dataStream)
        {
            this.storableAdapter = storableAdapter;
            this.dataStream = dataStream;
            this.buffer = new List<StorableNode>();
        }

        public void initComponents()
        {
            loadBuffer();
        }
        public void close()
        {
            dataStream.Dispose();
        }

        public void persist(T storable)
        {
            var asArray = storableAdapter.AsStringArray(storable);
            var finded = findNodeById(storableAdapter.Identifier(storable));

            if (finded == null)
            {
                var node = new StorableNode();
                autoIncrementValue++;
                node.id = storableAdapter.DefineIdentifier(storable, autoIncrementValue);
                node.data = asArray;
                buffer.Add(node);
            }
            else
            {
                finded.data = asArray;
            }

            writeBuffer();
        }

        public T findById(string id)
        {
            var node = findNodeById(id);
            if (node == null)
                return default(T);

            return storableAdapter.FromStringArray(node.id, node.data);   
        }

        protected T findByData(string data, int dataIndex)
        {
            var node = findNodeByData(data, dataIndex);
            if (node == null)
                return default(T);

            return storableAdapter.FromStringArray(node.id, node.data);
        }

        protected StorableNode findNodeById(string id)
        {
            if (id == null)
                return null;

            return buffer.FirstOrDefault(node => node.id.Equals(id));
        }

        protected StorableNode findNodeByData(string data, int dataIndex)
        {
            if (data == null)
                return null;

            return buffer.FirstOrDefault(node => node.data[dataIndex].Equals(data));
        }

        public int Count()
        {
            return buffer.Count();
        }

        public void InitializeFile()
        {
            buffer.Clear();
            writeBuffer();
            initComponents();
        }

        private void loadBuffer()
        {
            dataStream.Position = 0;
            buffer.Clear();

            var reader = new StreamReader(dataStream);
            autoIncrementValue = handleHeader(reader.ReadLine());
            
            string id;

            while ((id = reader.ReadLine()) != null)
            {
                var currentNode = new StorableNode();
                var data = new string[storableAdapter.AttributeCount()];

                currentNode.id = handleDataRead(id);
                for (int i = 0; i < storableAdapter.AttributeCount(); i++)
                {
                    data[i] = handleDataRead(reader.ReadLine());
                }

                currentNode.data = data;
                buffer.Add(currentNode);
            }
        }

        private void writeBuffer()
        {
            dataStream.Position = 0;
            dataStream.SetLength(0);
            var writer = new StreamWriter(dataStream);

            writer.WriteLine(("{ProjIntegrado2Sem Version " + storableAdapter.Version() + " AutoIncrement " + autoIncrementValue + "}"));

            foreach (var node in buffer)
            {
                writer.WriteLine(handleDataWrite(node.id));

                foreach (var data in node.data)
                    writer.WriteLine(handleDataWrite(data));
            }
            writer.Flush();
        }

        private int handleHeader(string header)
        {
            if (header == null)
                throw new InvalidHeader();

            var regexText = @"^{ProjIntegrado2Sem Version " + storableAdapter.Version() + @" AutoIncrement (?<aival>\d+)}$";
            var headerMatch = (new Regex(regexText)).Match(header);

            if (headerMatch.Success)
                return int.Parse(headerMatch.Groups["aival"].Value);

            throw new InvalidHeader();
        }

        private string handleDataWrite(string data)
        {
            if (data == null)
                return "";

            data = data.Replace("\r", "").Replace("\n", "");
            return data;
        }

        private string handleDataRead(string readed)
        {
            if (readed == null)
                return null;

            if (readed.Length < 1)
                return null;

            return readed;
        }
    };

}
