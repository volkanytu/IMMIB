using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Common
{
    public class Globals
    {
        //public static string DomainName
        //{
        //    get { return RegistryHelper.Get.Value("DomainName"); }
        //}

        //public static string AdminName
        //{
        //    get { return RegistryHelper.Get.Value("AdminName"); }
        //}

        //public static string AdminUserName
        //{
        //    get { return RegistryHelper.Get.Value("AdminUserName"); }
        //}

        //public static string AdminPassword
        //{
        //    get { return RegistryHelper.Get.Value("AdminPassword"); }
        //}

        //public static string AdminId
        //{
        //    get { return RegistryHelper.Get.Value("AdminId"); }
        //}

        //public static string CrmUrl
        //{
        //    get { return RegistryHelper.Get.Value("CrmUrl"); }
        //}

        //public static string OrganizationName
        //{
        //    get { return RegistryHelper.Get.Value("OrganizationName"); }
        //}

        //public static string AdministratorId
        //{
        //    get { return RegistryHelper.Get.Value("AdminId"); }
        //}

        //public static string DatabaseName
        //{
        //    get { return RegistryHelper.Get.Value("DatabaseName"); }
        //}

        public static string ConnectionString
        {
            get { return RegistryHelper.Get.Value("ConnectionString"); }
        }

        public static string FileLogPath
        {
            get { return RegistryHelper.Get.Value("FileLogPath"); }
        }

        public static string CrmConnectionString
        {
            get { return RegistryHelper.Get.Value("CrmConnectionString"); }
        }

        public static string ElasticUrl
        {
            get { return RegistryHelper.Get.Value("ElasticUrl"); }
        }

        public static string ElasticIndexName
        {
            get { return RegistryHelper.Get.Value("ElasticIndexName"); }
        }

        public static string LogExt
        {
            get { return RegistryHelper.Get.Value("LogExt"); }
        }

    }
}
