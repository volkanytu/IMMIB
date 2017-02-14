using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Ioc.Interceptor;
using SRC.WindowsService.TestService.Interfaces;
using SRC.WindowsService.TestService.Libs;
using SRC.Library.Ioc.IocManager;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Data.SqlDao;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Business.Interfaces;
using SRC.Library.Data.Interfaces;
using SRC.Library.Business;
using SRC.Library.Interfaces.SmsManager;
using SRC.Library.SmsManager;
using SRC.Library.SmsManager.Libs;
using System.Linq;
using SRC.Library.Common;

namespace SRC.WindowsService.TestService
{
    public class IocContainerConfig
    {
        public static string APPLICATION_NAME = "TEST_SERVICE";

        public static IContainer BuildIocContainer()
        {
            var builder = new ContainerBuilder();   

            #region | IOC REGISTER |
            IocContainerBuilder.RegisterDataAccess(builder);
            //IocContainerBuilder.RegisterLogManager(builder, APPLICATION_NAME, LogEntity.LogClientType.ELASTIC);
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            #region | INVALID CHARACTERS |
            var invalidCharacters = (ConfigurationManager.GetSection("InvalidCharacters/Characters") as System.Collections.Hashtable)
                 .Cast<System.Collections.DictionaryEntry>()
                 .ToDictionary(n => n.Key.ToInteger(), n => n.Value.ToInteger());
            #endregion

            builder.Register<IBaseDao<SmsEnt>>(c => new BaseSqlDao<SmsEnt>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), SmsQueries.GET_SMS, SmsQueries.GET_SMS_LIST)).InstancePerDependency();
            builder.Register<IBaseBusiness<SmsEnt>>(c => new BaseBusiness<SmsEnt>(c.Resolve<IBaseDao<SmsEnt>>())).InstancePerDependency();
            builder.Register<ISmsManager>(c => new SmsManager(new SmsConfig() { AccountNumber = ConfigurationManager.AppSettings["AccountNumber"].ToString(),UserName = ConfigurationManager.AppSettings["UserName"].ToString(),
                Password = ConfigurationManager.AppSettings["Password"].ToString(),
                ShortNumber = ConfigurationManager.AppSettings["ShortNumber"].ToString(),
                Orginator = ConfigurationManager.AppSettings["Orginator"].ToString(), InvalidCharacters = invalidCharacters
            })).InstancePerDependency();

            builder.Register<IServiceManager>(c => new ServiceManager(c.Resolve<IBaseBusiness<SmsEnt>>()
                ,c.Resolve<ISmsManager>()))
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            var container = builder.Build();

            return container;
        }
    }
}
