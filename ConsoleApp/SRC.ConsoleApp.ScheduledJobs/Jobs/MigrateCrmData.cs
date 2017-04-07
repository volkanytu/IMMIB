using SRC.ConsoleApp.ScheduledJobs.MigrationLibs;
using SRC.Library.Business.Interfaces;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.LogManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.ConsoleApp.ScheduledJobs.Jobs
{
    /// <summary>
    /// MigrateCrmData
    /// </summary>
    public class MigrateCrmData : BaseJob
    {
        private ILogManager _logmanager;
        private ISqlAccess _crm4SqlAccess;
        private IBaseBusiness<City> _cityBaseBusiness;
        private IBaseBusiness<Town> _townBaseBusiness;
        private IBaseBusiness<EducationDefinition> _educationDefinationBaseBusiness;
        private IBaseBusiness<Association> _associationBaseBusiness;
        private IBaseBusiness<EducationLocation> _educationLocationBaseBusiness;
        private IBaseBusiness<Account> _accountBaseBusiness;

        public MigrateCrmData(ILogManager logmanager, ISqlAccess crm4SqlAccess
            , IBaseBusiness<City> cityBaseBusiness
            , IBaseBusiness<Town> townBaseBusiness
            , IBaseBusiness<EducationDefinition> educationDefinationBaseBusiness
            , IBaseBusiness<Association> associationBaseBusiness
            , IBaseBusiness<EducationLocation> educationLocationBaseBusiness
            , IBaseBusiness<Account> accountBaseBusiness)
        {
            _logmanager = logmanager;
            _crm4SqlAccess = crm4SqlAccess;
            _cityBaseBusiness = cityBaseBusiness;
            _townBaseBusiness = townBaseBusiness;
            _educationDefinationBaseBusiness = educationDefinationBaseBusiness;
            _associationBaseBusiness = associationBaseBusiness;
            _educationLocationBaseBusiness = educationLocationBaseBusiness;
            _accountBaseBusiness = accountBaseBusiness;
        }

        protected override void DoWork(string[] args)
        {
            //ProcessCities();

            //ProcessTowns();

            //ProcessEducationDefinations();

            //ProcessAssociations();

            //ProcessEducationLocations();

            ProcessAccounts();

        }

        public void ProcessCities()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("City migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_CITIES);
            var entityList = dt.ToList<City>();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Record Count:{0}", entityList.Count.ToString());

            int counter = 0;
            int success = 0;
            int error = 0;

            foreach (var entity in entityList)
            {
                counter++;

                try
                {
                    _cityBaseBusiness.Insert(entity);
                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:City, Id:{0}, Message:{1}", entity.Id, ex.Message);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessTowns()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Town migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_TOWNS);
            var entityList = dt.ToList<Town>();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Record Count:{0}", entityList.Count.ToString());

            int counter = 0;
            int success = 0;
            int error = 0;

            foreach (var entity in entityList)
            {
                counter++;

                try
                {
                    _townBaseBusiness.Insert(entity);
                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Town, Id:{0}, Message:{1}", entity.Id, ex.Message);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessEducationDefinations()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Education Definations migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_EDUCATION_DEF);
            var entityList = dt.ToList<EducationDefinition>();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Record Count:{0}", entityList.Count.ToString());

            int counter = 0;
            int success = 0;
            int error = 0;

            foreach (var entity in entityList)
            {
                counter++;

                try
                {
                    _educationDefinationBaseBusiness.Insert(entity);
                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Education Defination, Id:{0}, Message:{1}", entity.Id, ex.Message);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessAssociations()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Associations migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_ASSOCIATIONS);
            var entityList = dt.ToList<Association>();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Record Count:{0}", entityList.Count.ToString());

            int counter = 0;
            int success = 0;
            int error = 0;

            foreach (var entity in entityList)
            {
                counter++;

                try
                {
                    _associationBaseBusiness.Insert(entity);
                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Association, Id:{0}, Message:{1}", entity.Id, ex.Message);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessEducationLocations()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Education Location migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_EDUCATION_LOCATIONS);
            var entityList = dt.ToList<EducationLocation>();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Record Count:{0}", entityList.Count.ToString());

            int counter = 0;
            int success = 0;
            int error = 0;

            foreach (var entity in entityList)
            {
                counter++;

                try
                {
                    _educationLocationBaseBusiness.Insert(entity);
                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Education Location, Id:{0}, Message:{1}", entity.Id, ex.Message);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessAccounts()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Account migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_ACCOUNTS);
            var entityList = dt.ToList<Account>();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Record Count:{0}", entityList.Count.ToString());

            int counter = 0;
            int success = 0;
            int error = 0;

            foreach (var entity in entityList)
            {
                counter++;

                try
                {
                    _accountBaseBusiness.Insert(entity);

                    var erAssociation = GetAccountAssociation(entity.Id);

                    if (erAssociation != null)
                    {
                        _accountBaseBusiness.AssociateIn(entity.Id, erAssociation, "new_account_new_association");
                    }

                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Account, Id:{0}, Message:{1}", entity.Id, ex.Message);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public EntityReferenceWrapper GetAccountAssociation(Guid accountId)
        {
            var dt = _crm4SqlAccess.GetDataTable(string.Format(Queries.GET_ACCOUNT_ASSOCIATION, accountId.ToString()));

            return dt.ToList<EntityReferenceWrapper>().FirstOrDefault();
        }
    }
}
