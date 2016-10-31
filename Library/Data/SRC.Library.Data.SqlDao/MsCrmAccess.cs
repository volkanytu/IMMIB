using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Configuration;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using SRC.Library.Data.SqlDao.Interfaces;
using System;
using System.Net;
using System.ServiceModel.Description;
using System.Threading;

namespace SSRC.Library.Data.SqlDao
{
    public class MsCrmAccess : IMsCrmAccess
    {
        private readonly string _connectionString;
        public Guid ServiceID { get { return _serviceID; } set { _serviceID = value; } }

        private IOrganizationService _crmService = null;
        private Guid _serviceID = Guid.Empty;
        private static ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

        public IOrganizationService CrmService
        {
            get
            {
                return _crmService;
            }
            set
            {
                _crmService = value;
            }
        }
        public MsCrmAccess(string connectionString)
        {
            _connectionString = connectionString;
            _serviceID = Guid.NewGuid();
        }

        public IOrganizationService GetCrmService()
        {
            cacheLock.EnterReadLock();

            try
            {
                if (_crmService == null)
                {
                    CrmService = GetService();
                }
            }
            finally
            {
                cacheLock.ExitReadLock();
            }

            return _crmService;
        }

        private IOrganizationService GetService()
        {
            //string connectionUrl = string.Format("Url={0}{1}; Domain={2}; Username={3}; Password={4};", Globals.CrmUrl, Globals.OrganizationName, Globals.DomainName, Globals.AdminUserName, Globals.AdminPassword);

            CrmConnection connection = CrmConnection.Parse(_connectionString);

            connection.ServiceConfigurationInstanceMode = ServiceConfigurationInstanceMode.PerRequest;
            connection.Timeout = new TimeSpan(2, 0, 0);
            connection.UserTokenExpiryWindow = new TimeSpan(0, 1, 0);

            OrganizationService service = new OrganizationService(connection);

            return service;
        }

    }
}
