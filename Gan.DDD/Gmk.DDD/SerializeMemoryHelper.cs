using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Gan.DDD
{
    public class SerializeMemoryHelper
    {
        public static byte[] SerializeToBinary(object value)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            memStream.Seek(0, 0);
            serializer.Serialize(memStream, value);
            return memStream.ToArray();
        }
        public static object DeserializeFromBinary(byte[] someBytes)
        {
            IFormatter bf = new BinaryFormatter();
            object res = null;
            if (someBytes == null)
                return null;
            using (var memoryStream=new MemoryStream())
            {
                memoryStream.Write(someBytes, 0, someBytes.Length);
                memoryStream.Seek(0, 0);
                memoryStream.Position = 0;
                res = bf.Deserialize(memoryStream);
            }
            return res;
        }
    }
}
