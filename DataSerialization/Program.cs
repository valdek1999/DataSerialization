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
        static readonly string pathConfig = "config.json";
        static void Main(string[] args)
        {
            XmlParser<Root> xmlParser = new XmlParser<Root>(new ConfigurationBuilder()
                .AddJsonFile(pathConfig)
                .Build());
            xmlParser.XmlToJson();          
        }
    }
}
