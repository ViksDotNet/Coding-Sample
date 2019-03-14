
using CodingSample.Core.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Unity;
using System.Web.Script.Serialization;
using CodingSample.Core.Entities;
using CodingSample.MainProgram.Models;
using AutoMapper;
using CodingSample.Core.Logging;


namespace CodingSample.MainProgram
{
    class Program
    {
        private static UnityContainer container = new UnityContainer();
        private static ILogger log;

        static void Main(string[] args)
        {
            //Dependency Injection using Unity
            container.RegisterType<IDataService, ConsoleDataService>();
            container.RegisterType<IDataService, DataBaseService>();
            IDataService _consoleService = container.Resolve<ConsoleDataService>();
            IDataService _databaseService = container.Resolve<DataBaseService>();

            //log4net init
            container.RegisterType<ILogger, Log4NetLogger>();
            log4net.Config.XmlConfigurator.Configure();
            log = container.Resolve<Log4NetLogger>();


            //AutoMapper
            AutoMapper.Mapper.Initialize(config =>
            {         
                config.CreateMap<OutputViewModel, OutputDataEntity>().ReverseMap();
            });



            string url = ConfigurationManager.AppSettings["Api_Url"];
            OutputViewModel result = CallRestMethod(url);
            if(result == null)
            {
                Console.WriteLine("API Error: Please check log file");
                Console.ReadLine();
                Environment.Exit(0);
            }
            OutputDataEntity resultEntity = Mapper.Map<OutputDataEntity>(result);

            string outputMethod = ConfigurationManager.AppSettings["Output_Method"];
            switch (outputMethod)
            {
                case "Console":
                    WriteMessage(_consoleService, resultEntity);
                    break;
                case "Database":
                    WriteMessage(_databaseService, resultEntity);
                    break;
                default:
                    Console.WriteLine("Error: 'Output_Method' is not correct in App.config file");
                    break;

            }
            Console.ReadLine();
        }

        public static OutputViewModel CallRestMethod(string url)
        {
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                webrequest.Method = "GET";
                webrequest.ContentType = "application/json";                
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                var objText = responseStream.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                OutputViewModel result = (OutputViewModel)js.Deserialize(objText, typeof(OutputViewModel));
                webresponse.Close();
                return result;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
           
        }

        static void WriteMessage(IDataService writer, OutputDataEntity data)
        {
            writer.WriteData(data);
            return;
        }
    }
}
