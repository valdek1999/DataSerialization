using Microsoft.Extensions.Configuration;
using System;

namespace DynamicDataSerialization
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
