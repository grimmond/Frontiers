using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace GameServer
{
    public static class Settings
    {
        public static int ThreadsPerProcessor { get; set; }
        public static int Processors { get; set; }
        public static int QuickLocatorSize { get; set; }

        static Settings()
        {
            //threadsperprocessor
            string result = ConfigurationManager.AppSettings["ThreadsPerProcessor"];
            ThreadsPerProcessor = Convert.ToInt32(result);  

            //processors
            Processors = Environment.ProcessorCount;

            //quick locator size
            result = ConfigurationManager.AppSettings["QuickLocatorSize"];
            QuickLocatorSize = Convert.ToInt32(result);

        }

        

    }
}
