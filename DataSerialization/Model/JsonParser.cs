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
        public IConfiguration _configuraton { get; private set; }

        private XmlSerializer serializer = new XmlSerializer(typeof(T));

        public T EntityDeserialized { get; private set; }

        public string xmlpath { get; set; }

        public string jsonpath { get;set; }
        public XmlParser(IConfigurationRoot configuraton)
        {
            _configuraton = configuraton;
            xmlpath = _configuraton["xmlpath"];
            jsonpath = _configuraton["jsonpath"];
        }
        public string XmlToJson()
        {

            using(var file = new FileStream(xmlpath, FileMode.Open))
            {
                EntityDeserialized = serializer.Deserialize(file) as T;
            }
            var data = JsonConvert.SerializeObject(EntityDeserialized);
            using(StreamWriter sw = new StreamWriter(jsonpath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(data);
            }
            return data;
        }


    }
}
