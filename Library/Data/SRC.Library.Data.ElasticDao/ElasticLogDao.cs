using Nest;
using SRC.Library.Data.ElasticDao.Interfaces;
using SRC.Library.Data.Interfaces;
using SRC.Library.Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GK.Library.Data.ElasticDataLayer
{
    public class ElasticLogDao : ILog
    {
        private IElasticAccess _elasticAccess;
        private string _applicationName;

        public ElasticLogDao(IElasticAccess elasticAccess, string applicationName)
        {
            _elasticAccess = elasticAccess;
            _applicationName = applicationName;
        }

        public void Log(LogEntity logEntity)
        {
            logEntity.ApplicationName = _applicationName;

            _elasticAccess.CreateDocument(logEntity.FunctionName, logEntity);
        }
    }
}
