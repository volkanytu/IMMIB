using Autofac;
using SRC.Library.Common;
using SRC.Library.Data.ElasticDao;
using SRC.Library.Data.ElasticDao.Interfaces;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.Ioc.Interceptor;
using SRC.Library.LogManager;
using SRC.Library.LogManager.Interfaces;
using SSRC.Library.Data.SqlDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Business;
using SRC.Library.Business.Interfaces;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Domain.Business;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Domain.Facade.Interfaces;

namespace SRC.Library.Ioc.IocManager
{
    public static class IocContainerBuilder
    {
        public static ContainerBuilder RegisterDataAccess(ContainerBuilder builder)
        {
            builder.Register<ISqlAccess>(c => new SqlAccess(Globals.ConnectionString))
                .InstancePerLifetimeScope();

            builder.Register<ISqlAccess>(c => new SqlAccess(Globals.ConnectionStringCrm4))
                .Named<ISqlAccess>("CRM4")
                .InstancePerLifetimeScope();

            builder.Register<IElasticAccess>(c => new ElasticAccess(Globals.ElasticUrl, Globals.ElasticIndexName)).InstancePerLifetimeScope();
            builder.Register<IMsCrmAccess>(c => new MsCrmAccess(Globals.CrmConnectionString)).InstancePerDependency();

            return builder;
        }

        public static ContainerBuilder RegisterPortal(ContainerBuilder builder)
        {
            #region | DATA |
            builder.Register<IBaseDao<LoginLog>>(c => new BaseSqlDao<LoginLog>(c.Resolve<ISqlAccess>()
                , c.Resolve<IMsCrmAccess>(), "", "")).InstancePerDependency();
            builder.Register<IBaseDao<SmsEnt>>(c => new BaseSqlDao<SmsEnt>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , SmsQueries.GET_SMS, SmsQueries.GET_SMS_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<University>>(c => new BaseSqlDao<University>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , UniversityQueries.GET_UNIVERSITY, UniversityQueries.GET_UNIVERSITY_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Contact>>(c => new BaseSqlDao<Contact>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , ContactQueries.GET_CONTACT, ContactQueries.GET_CONTACT_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Account>>(c => new BaseSqlDao<Account>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , AccountQueries.GET_ACCOUNT, AccountQueries.GET_ACCOUNT_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<CreditCardLog>>(c => new BaseSqlDao<CreditCardLog>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , CreditCardQueries.GET_CREDIT_CARD, CreditCardQueries.GET_CREDIT_CARD_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<EducationAttendance>>(c => new BaseSqlDao<EducationAttendance>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE, EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Education>>(c => new BaseSqlDao<Education>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , EducationQueries.GET_EDUCATION, EducationQueries.GET_EDUCATION_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<GsmOperator>>(c => new BaseSqlDao<GsmOperator>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , GsmOperatorQueries.GET_GSM_OPERATOR, GsmOperatorQueries.GET_GSM_OPERATOR_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<InformedBy>>(c => new BaseSqlDao<InformedBy>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , InformedByQueries.GET_INFORMEDBY, InformedByQueries.GET_INFORMEDBY_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<City>>(c => new BaseSqlDao<City>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , CityQueries.GET_CITY, CityQueries.GET_CITY_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Town>>(c => new BaseSqlDao<Town>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , TownQueries.GET_TOWN, TownQueries.GET_TOWN_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<DynamicPage>>(c => new BaseSqlDao<DynamicPage>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>()
                , DynamicPageQueries.GET_DYNAMIC_PAGE, DynamicPageQueries.GET_DYNAMIC_PAGE_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<EducationDefinition>>(c => new BaseSqlDao<EducationDefinition>(c.Resolve<ISqlAccess>()
                , c.Resolve<IMsCrmAccess>()
                , EducationDefinitionQueries.GET_EDUCATION_DEFINITION, EducationDefinitionQueries.GET_EDUCATION_DEFINITION_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Association>>(c => new BaseSqlDao<Association>(c.Resolve<ISqlAccess>()
                , c.Resolve<IMsCrmAccess>()
                , AssociationQueries.GET_ASSOCIATION, AssociationQueries.GET_ASSOCIATION_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<EducationLocation>>(c => new BaseSqlDao<EducationLocation>(c.Resolve<ISqlAccess>()
                , c.Resolve<IMsCrmAccess>()
                , EducationLocationQueries.GET_EDUCATION_LOCATION, EducationLocationQueries.GET_EDUCATION_LOCATION_LIST)).InstancePerDependency();


            builder.Register<IContactDao>(c => new ContactDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IAccountDao>(c => new AccountDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationDao>(c => new EducationDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationAttendanceDao>(c => new EducationAttendanceDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IAssociationDao>(c => new AssociationDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<ISmsDao>(c => new SmsDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();

            builder.Register<ICommonDao>(c => new CommonDao(c.Resolve<ISqlAccess>()
                , c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            #endregion

            #region | BUSINESS |
            builder.Register<IBaseBusiness<LoginLog>>(c => new BaseBusiness<LoginLog>(c.Resolve<IBaseDao<LoginLog>>())).InstancePerDependency();
            builder.Register<ISmsBusiness>(c => new SmsBusiness(c.Resolve<IBaseDao<SmsEnt>>(), c.Resolve<ISmsDao>())).InstancePerDependency();
            builder.Register<IBaseBusiness<University>>(c => new BaseBusiness<University>(c.Resolve<IBaseDao<University>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Contact>>(c => new BaseBusiness<Contact>(c.Resolve<IBaseDao<Contact>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Account>>(c => new BaseBusiness<Account>(c.Resolve<IBaseDao<Account>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<CreditCardLog>>(c => new BaseBusiness<CreditCardLog>(c.Resolve<IBaseDao<CreditCardLog>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<EducationAttendance>>(c => new BaseBusiness<EducationAttendance>(c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Education>>(c => new BaseBusiness<Education>(c.Resolve<IBaseDao<Education>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<GsmOperator>>(c => new BaseBusiness<GsmOperator>(c.Resolve<IBaseDao<GsmOperator>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<InformedBy>>(c => new BaseBusiness<InformedBy>(c.Resolve<IBaseDao<InformedBy>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<City>>(c => new BaseBusiness<City>(c.Resolve<IBaseDao<City>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Town>>(c => new BaseBusiness<Town>(c.Resolve<IBaseDao<Town>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<DynamicPage>>(c => new BaseBusiness<DynamicPage>(c.Resolve<IBaseDao<DynamicPage>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<EducationDefinition>>(c => new BaseBusiness<EducationDefinition>(c.Resolve<IBaseDao<EducationDefinition>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Association>>(c => new BaseBusiness<Association>(c.Resolve<IBaseDao<Association>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<EducationLocation>>(c => new BaseBusiness<EducationLocation>(c.Resolve<IBaseDao<EducationLocation>>())).InstancePerDependency();

            builder.Register<IContactBusiness>(c => new ContactBusiness(c.Resolve<IBaseDao<Contact>>(), c.Resolve<IContactDao>())).InstancePerDependency();
            builder.Register<IAccountBusiness>(c => new AccountBusiness(c.Resolve<IBaseDao<Account>>(), c.Resolve<IAccountDao>())).InstancePerDependency();
            builder.Register<IEducationBusiness>(c => new EducationBusiness(c.Resolve<IEducationDao>())).InstancePerDependency();
            builder.Register<IEducationAttendanceBusiness>(c => new EducationAttendanceBusiness(c.Resolve<IEducationAttendanceDao>()
                , c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();
            builder.Register<IAssociationBusiness>(c => new AssociationBusiness(c.Resolve<IBaseDao<Association>>(), c.Resolve<IAssociationDao>())).InstancePerDependency();
            builder.Register<ICommonBusiness>(c => new CommonBusiness(c.Resolve<ICommonDao>())).InstancePerDependency();
            #endregion

            #region | FACADE |
            builder.Register<IContactFacade>(c => new ContactFacade(
                c.Resolve<IContactBusiness>(),
                c.Resolve<ISmsBusiness>(), c.Resolve<IBaseBusiness<LoginLog>>(),
                c.Resolve<IBaseBusiness<Contact>>(),
                c.Resolve<IBaseBusiness<Account>>())).InstancePerDependency();
            builder.Register<IEducationFacade>(c => new EducationFacade(
                c.Resolve<IEducationBusiness>(),
                c.Resolve<IEducationAttendanceBusiness>(),
                c.Resolve<IBaseBusiness<EducationAttendance>>(),
                c.Resolve<IBaseBusiness<CreditCardLog>>(),
                c.Resolve<IAssociationBusiness>())).InstancePerDependency();
            #endregion

            return builder;
        }

        public static ContainerBuilder RegisterLogManager(ContainerBuilder builder, string applicationName, LogEntity.LogClientType logClientType)
        {
            builder = RegisterDataAccess(builder);

            builder.Register<ILog>(c => new SqlLogDao(c.Resolve<ISqlAccess>(), applicationName)).Keyed<ILog>(LogEntity.LogClientType.SQL);
            builder.Register<ILog>(c => new SqlLogDao(c.Resolve<ISqlAccess>(), applicationName)).Keyed<ILog>(LogEntity.LogClientType.ELASTIC);
            builder.Register<ILog>(c => new FileLogger(Globals.FileLogPath)).Keyed<ILog>(LogEntity.LogClientType.FILE);

            builder.Register<ILogManager>(c => new Logger(c.ResolveKeyed<ILog>(logClientType))).InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder RegisterInterceptors(ContainerBuilder builder)
        {
            builder.Register(c => new LogInterceptor(c.Resolve<ILogManager>()));
            builder.Register(c => new CustomExceptionInterceptor());

            return builder;
        }

        public static ContainerBuilder RegisterPlugin(ContainerBuilder builder)
        {
            #region | DATA |
            builder.Register<IBaseDao<LoginLog>>(c => new BaseSqlDao<LoginLog>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), "", "")).InstancePerDependency();
            builder.Register<IBaseDao<SmsEnt>>(c => new BaseSqlDao<SmsEnt>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), SmsQueries.GET_SMS, SmsQueries.GET_SMS_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Contact>>(c => new BaseSqlDao<Contact>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), ContactQueries.GET_CONTACT, ContactQueries.GET_CONTACT_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<CreditCardLog>>(c => new BaseSqlDao<CreditCardLog>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), CreditCardQueries.GET_CREDIT_CARD, CreditCardQueries.GET_CREDIT_CARD_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<EducationAttendance>>(c => new BaseSqlDao<EducationAttendance>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE, EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Education>>(c => new BaseSqlDao<Education>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), EducationQueries.GET_EDUCATION, EducationQueries.GET_EDUCATION_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<GsmOperator>>(c => new BaseSqlDao<GsmOperator>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), GsmOperatorQueries.GET_GSM_OPERATOR, GsmOperatorQueries.GET_GSM_OPERATOR_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<InformedBy>>(c => new BaseSqlDao<InformedBy>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), InformedByQueries.GET_INFORMEDBY, InformedByQueries.GET_INFORMEDBY_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<City>>(c => new BaseSqlDao<City>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), CityQueries.GET_CITY, CityQueries.GET_CITY_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<DynamicPage>>(c => new BaseSqlDao<DynamicPage>(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>(), DynamicPageQueries.GET_DYNAMIC_PAGE, DynamicPageQueries.GET_DYNAMIC_PAGE_LIST)).InstancePerDependency();
            builder.Register<IBaseDao<Association>>(c => new BaseSqlDao<Association>(c.Resolve<ISqlAccess>()
    , c.Resolve<IMsCrmAccess>()
    , AssociationQueries.GET_ASSOCIATION, AssociationQueries.GET_ASSOCIATION_LIST)).InstancePerDependency();

            builder.Register<IContactDao>(c => new ContactDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationDao>(c => new EducationDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IEducationAttendanceDao>(c => new EducationAttendanceDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<IAssociationDao>(c => new AssociationDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            builder.Register<ISmsDao>(c => new SmsDao(c.Resolve<ISqlAccess>(), c.Resolve<IMsCrmAccess>())).InstancePerDependency();
            #endregion

            #region | BUSINESS |
            builder.Register<IBaseBusiness<LoginLog>>(c => new BaseBusiness<LoginLog>(c.Resolve<IBaseDao<LoginLog>>())).InstancePerDependency();
            builder.Register<ISmsBusiness>(c => new SmsBusiness(c.Resolve<IBaseDao<SmsEnt>>(), c.Resolve<ISmsDao>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Contact>>(c => new BaseBusiness<Contact>(c.Resolve<IBaseDao<Contact>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<CreditCardLog>>(c => new BaseBusiness<CreditCardLog>(c.Resolve<IBaseDao<CreditCardLog>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<EducationAttendance>>(c => new BaseBusiness<EducationAttendance>(c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Education>>(c => new BaseBusiness<Education>(c.Resolve<IBaseDao<Education>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<GsmOperator>>(c => new BaseBusiness<GsmOperator>(c.Resolve<IBaseDao<GsmOperator>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<InformedBy>>(c => new BaseBusiness<InformedBy>(c.Resolve<IBaseDao<InformedBy>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<City>>(c => new BaseBusiness<City>(c.Resolve<IBaseDao<City>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<DynamicPage>>(c => new BaseBusiness<DynamicPage>(c.Resolve<IBaseDao<DynamicPage>>())).InstancePerDependency();
            builder.Register<IBaseBusiness<Association>>(c => new BaseBusiness<Association>(c.Resolve<IBaseDao<Association>>())).InstancePerDependency();

            builder.Register<IContactBusiness>(c => new ContactBusiness(c.Resolve<IBaseDao<Contact>>(), c.Resolve<IContactDao>())).InstancePerDependency();
            builder.Register<IEducationBusiness>(c => new EducationBusiness(c.Resolve<IEducationDao>())).InstancePerDependency();
            builder.Register<IEducationAttendanceBusiness>(c => new EducationAttendanceBusiness(c.Resolve<IEducationAttendanceDao>()
                , c.Resolve<IBaseDao<EducationAttendance>>())).InstancePerDependency();
            builder.Register<IAssociationBusiness>(c => new AssociationBusiness(c.Resolve<IBaseDao<Association>>(), c.Resolve<IAssociationDao>())).InstancePerDependency();
            #endregion

            #region | FACADE |
            builder.Register<IContactFacade>(c => new ContactFacade(
                c.Resolve<IContactBusiness>(),
                c.Resolve<ISmsBusiness>(), c.Resolve<IBaseBusiness<LoginLog>>(),
                c.Resolve<IBaseBusiness<Contact>>(),
                c.Resolve<IBaseBusiness<Account>>())).InstancePerDependency();
            builder.Register<IEducationFacade>(c => new EducationFacade(
                c.Resolve<IEducationBusiness>(),
                c.Resolve<IEducationAttendanceBusiness>(),
                c.Resolve<IBaseBusiness<EducationAttendance>>(),
                c.Resolve<IBaseBusiness<CreditCardLog>>(),
                c.Resolve<IAssociationBusiness>())).InstancePerDependency();
            #endregion

            return builder;
        }

    }
}
