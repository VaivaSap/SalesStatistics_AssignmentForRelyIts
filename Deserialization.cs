using System.Xml.Serialization;

namespace SalesStatistics
{
    public class Deserialization
    {
        public T DeserializeToObject<T>(string filepath) where T : class
        {
        var posLog = new POSLogRoot();
           var serializer = new XmlSerializer(posLog.GetType());

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                return (T)serializer.Deserialize(streamReader);
            }
        }
    }
}


