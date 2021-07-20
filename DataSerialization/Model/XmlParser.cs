using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DataSerialization.Model
{
    class XmlParser<T> where T : class, new()
    {
        public IConfiguration Сonfiguraton { get; private set; }

        private XmlSerializer _serializer = new XmlSerializer(typeof(T));

        public T EntityDeserialized { get; private set; }

        public XmlParser(IConfigurationRoot configuraton)
        {
            Сonfiguraton = configuraton;
        }
        public string XmlToJson()
        {

            using(var file = new FileStream(Сonfiguraton["xmlpath"], FileMode.Open))
            {
                EntityDeserialized = _serializer.Deserialize(file) as T;
            }
            var data = JsonConvert.SerializeObject(EntityDeserialized);
            using(StreamWriter sw = new StreamWriter(Сonfiguraton["jsonpath"], false, System.Text.Encoding.Default))
            {
                sw.WriteLine(data);
            }
            return data;
        }
    }
}
