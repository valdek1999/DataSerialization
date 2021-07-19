using DataSerialization.Model;
using System;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;

namespace DataSerialization
{
    class Program
    {
        static readonly string pathConfig = Environment.GetEnvironmentVariable("config_name");
        static void Main(string[] args)
        {
            XmlParser<Data> xmlParser = new XmlParser<Data>(new ConfigurationBuilder()
                .AddJsonFile(pathConfig)
                .Build());
            xmlParser.XmlToJson();          
        }
    }
}
