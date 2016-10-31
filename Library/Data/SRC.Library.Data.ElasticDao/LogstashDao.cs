using Newtonsoft.Json;
using SRC.Library.Data.Interfaces;
using SRC.Library.Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.ElasticDao
{
    public class LogstashDao : ILog
    {
        private string _logStashHost;
        private int _logStashPort;

        public LogstashDao(string logStashHost, int logStashPort)
        {
            _logStashHost = logStashHost;
            _logStashPort = logStashPort;
        }

        public void Log(LogEntity logEntity)
        {
            using (var udpClient = new UdpClient())
            {
                using (var stream = new MemoryStream())
                {
                    var asen = new UTF8Encoding();
                    var ba = asen.GetBytes(JsonConvert.SerializeObject(logEntity));
                    stream.Write(ba, 0, ba.Length);
                    udpClient.SendAsync(ba, ba.Length, _logStashHost, _logStashPort);
                }
            }
        }
    }
}
