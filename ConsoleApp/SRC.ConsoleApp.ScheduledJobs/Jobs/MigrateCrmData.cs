using SRC.ConsoleApp.ScheduledJobs.MigrationLibs;
using SRC.Library.Business.Interfaces;
using SRC.Library.Common;
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
        private IBaseBusiness<Contact> _contactBaseBusiness;
        private IBaseBusiness<Education> _educationBaseBusiness;
        private IBaseBusiness<EducationAttendance> _educationAttendanceBaseBusiness;
        private IBaseBusiness<CreditCardLog> _creditCardLogBaseBusiness;

        public MigrateCrmData(ILogManager logmanager, ISqlAccess crm4SqlAccess
            , IBaseBusiness<City> cityBaseBusiness
            , IBaseBusiness<Town> townBaseBusiness
            , IBaseBusiness<EducationDefinition> educationDefinationBaseBusiness
            , IBaseBusiness<Association> associationBaseBusiness
            , IBaseBusiness<EducationLocation> educationLocationBaseBusiness
            , IBaseBusiness<Account> accountBaseBusiness
            , IBaseBusiness<Contact> contactBaseBusiness
            , IBaseBusiness<Education> educationBaseBusiness
            , IBaseBusiness<EducationAttendance> educationAttendanceBaseBusiness
            , IBaseBusiness<CreditCardLog> creditCardLogBaseBusiness
            )
        {
            _logmanager = logmanager;
            _crm4SqlAccess = crm4SqlAccess;
            _cityBaseBusiness = cityBaseBusiness;
            _townBaseBusiness = townBaseBusiness;
            _educationDefinationBaseBusiness = educationDefinationBaseBusiness;
            _associationBaseBusiness = associationBaseBusiness;
            _educationLocationBaseBusiness = educationLocationBaseBusiness;
            _accountBaseBusiness = accountBaseBusiness;
            _contactBaseBusiness = contactBaseBusiness;
            _educationBaseBusiness = educationBaseBusiness;
            _educationAttendanceBaseBusiness = educationAttendanceBaseBusiness;
            _creditCardLogBaseBusiness = creditCardLogBaseBusiness;
        }

        protected override void DoWork(string[] args)
        {
            ProcessCities();

            //ProcessTowns();

            //ProcessEducationDefinations();

            //ProcessAssociations();

            //ProcessEducationLocations();

            //ProcessAccounts();

            //ProcessContacts();

            //ProcessEducations();

            //ProcessEducationAttendances();

            //ProcessCreditCardLogs();

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
                    var city = _cityBaseBusiness.Get(entity.Id);

                    if (city != null)
                        _cityBaseBusiness.Update(entity);
                    else
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

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessCities", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
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
                    var town = _townBaseBusiness.Get(entity.Id);

                    if (town != null)
                        _townBaseBusiness.Update(entity);
                    else
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

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessTowns", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
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
                    var educationDefination = _educationDefinationBaseBusiness.Get(entity.Id);

                    if (educationDefination != null)
                        _educationDefinationBaseBusiness.Update(entity);
                    else
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

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessEducationDefinations", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
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

                    var association = _associationBaseBusiness.Get(entity.Id);

                    if (association != null)
                        _associationBaseBusiness.Update(entity);
                    else
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

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessAssociations", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
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
                    var educationLocation = _educationLocationBaseBusiness.Get(entity.Id);

                    if (educationLocation != null)
                        _educationLocationBaseBusiness.Update(entity);
                    else
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

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessEducationLocations", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
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
                    var account = _accountBaseBusiness.Get(entity.Id);

                    if (account != null)
                        _accountBaseBusiness.Update(entity);
                    else
                        _accountBaseBusiness.Insert(entity);

                    AssociateToAccount(entity.Id);

                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Account, Id:{0}, Message:{1}", entity.Id, ex.Message);

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessAccounts", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessContacts()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Contact migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_CONTACTS);
            var entityList = dt.ToList<Contact>();

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
                    var contact = _contactBaseBusiness.Get(entity.Id);

                    if (contact != null)
                    {
                        entity.Password = entity.Password.ToSHA1();
                        _contactBaseBusiness.Update(entity);
                    }
                    else
                    {
                        entity.Password = entity.Password.ToSHA1();
                        _contactBaseBusiness.Insert(entity);
                    }

                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Contact, Id:{0}, Message:{1}", entity.Id, ex.Message);

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessContacts", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessEducations()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Education migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_EDUCATIONS);
            var entityList = dt.ToList<Education>();

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
                    var education = _educationBaseBusiness.Get(entity.Id);

                    if (education != null)
                        _educationBaseBusiness.Update(entity);
                    else
                        _educationBaseBusiness.Insert(entity);

                    AssociateToEducation(entity.Id);

                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:Education, Id:{0}, Message:{1}", entity.Id, ex.Message);

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessEducations", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessEducationAttendances()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("EducationAttendance migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_EDUCATION_ATTENDANCE);
            var entityList = dt.ToList<EducationAttendance>();

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
                    var educationAttendance = _educationAttendanceBaseBusiness.Get(entity.Id);

                    if (educationAttendance != null)
                        _educationAttendanceBaseBusiness.Update(entity);
                    else
                        _educationAttendanceBaseBusiness.Insert(entity);

                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:EducationAttendance, Id:{0}, Message:{1}", entity.Id, ex.Message);

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessEducationAttendances", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);

            }
        }

        public void ProcessCreditCardLogs()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("CreditCardLog migration is working.");

            var dt = _crm4SqlAccess.GetDataTable(Queries.GET_CREDIT_CARD_LOGS);
            var entityList = dt.ToList<CreditCardLog>();

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
                    var creditCardLog = _creditCardLogBaseBusiness.Get(entity.Id);

                    if (creditCardLog != null)
                        _creditCardLogBaseBusiness.Update(entity);
                    else
                        _creditCardLogBaseBusiness.Insert(entity);

                    success++;

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Counter:{0}/{1}", counter, entityList.Count);
                }
                catch (Exception ex)
                {
                    error++;
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Process:CreditCardLog, Id:{0}, Message:{1}", entity.Id, ex.Message);

                    FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "ProcessCreditCardLogs", entity.Id.ToString(), ex.Message)
                        , Globals.FileLogPath);
                }

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Success:{0}", success);

                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Error:{0}", error);
            }
        }

        public void AssociateToAccount(Guid accountId)
        {
            try
            {
                var erAssociation = GetAccountAssociation(accountId);

                if (erAssociation != null)
                {
                    _accountBaseBusiness.AssociateIn(accountId, erAssociation, "new_account_new_association");
                }
            }
            catch (Exception ex)
            {
                FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "AssociateToAccount", accountId.ToString(), ex.Message)
                    , Globals.FileLogPath);
            }
        }

        public void AssociateToEducation(Guid educationId)
        {
            try
            {
                var associationList = GetEducationAssociations(educationId);

                foreach (var association in associationList)
                {
                    _educationBaseBusiness.AssociateIn(educationId, association, "new_new_education_new_association");
                }
            }
            catch (Exception ex)
            {
                FileLog.WriteToFile(string.Format("Method:{0}|Id:{1}|Message:{2}", "AssociateToEducation", educationId.ToString(), ex.Message)
                    , Globals.FileLogPath);
            }
        }

        public EntityReferenceWrapper GetAccountAssociation(Guid accountId)
        {
            var dt = _crm4SqlAccess.GetDataTable(string.Format(Queries.GET_ACCOUNT_ASSOCIATION, accountId.ToString()));

            return dt.ToList<EntityReferenceWrapper>().FirstOrDefault();
        }

        public List<EntityReferenceWrapper> GetEducationAssociations(Guid educationId)
        {
            var dt = _crm4SqlAccess.GetDataTable(string.Format(Queries.GET_EDUCATION_ASSOCIATIONS, educationId.ToString()));

            return dt.ToList<EntityReferenceWrapper>();
        }
    }
}
