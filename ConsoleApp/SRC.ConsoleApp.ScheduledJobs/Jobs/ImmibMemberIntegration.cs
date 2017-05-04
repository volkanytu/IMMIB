using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Business.Interfaces;
using SRC.Library.Common;
using SRC.Library.Services.Members.MemberService;
using SRC.Library.Data.SqlDao;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Services.Members;

namespace SRC.ConsoleApp.ScheduledJobs.Jobs
{
    public class ImmibMemberIntegration: BaseJob
    {
        private ImmibMembers _service;
        private ILogManager _logmanager;
        private IAccountBusiness _accountBusiness;
        private IBaseBusiness<Account> _baseAccountBusiness;
        private IAssociationBusiness _associationBusiness;
        private IBaseBusiness<Association> _baseAssociationBusiness;

        public ImmibMemberIntegration(ILogManager logmanager, IBaseBusiness<Account> baseAccountBusiness, IAccountBusiness accountBusiness
                                                            , IBaseBusiness<Association> baseAssociationBusiness, IAssociationBusiness associationBusiness)
        {
            _service = new ImmibMembers(); //Bunu ioc'ye taşımalı mıyız?
            _accountBusiness = accountBusiness;
            _baseAccountBusiness = baseAccountBusiness;
            _associationBusiness = associationBusiness;
            _baseAssociationBusiness = baseAssociationBusiness;
            _logmanager = logmanager;
        }
        protected override void DoWork(string[] args)
        {
            List<ImmibMember> members = _service.GetMembers();

            //TODO: GMT alanından gelen değerle değiştirilebiliriz belki
            _accountBusiness.PassiveAllAccount();

            foreach (var immibMember in members)
            {
                Account account = _accountBusiness.GetAccount(immibMember.VERGINO);
                if (account == null)
                {
                    //immibmember to account
                    account = new Account();
                    account.Name = immibMember.UNVAN;
                    account.TaxNumber = immibMember.VERGINO;
                    account.Address = immibMember.ADRES;
                    account.PostalCode = immibMember.PK;
                    account.WorkPhone = immibMember.TELEFON1;
                    account.LandPhone = immibMember.TELEFON2;
                    account.Fax = immibMember.FAX;
                    account.EmailAddress = immibMember.EMAIL;
                    account.WebSite = immibMember.WEB;

                    Association association = _associationBusiness.GetAssociation(immibMember.SICIL.ToInteger());
                    if (association == null)
                    {
                        association = new Association
                        {
                            Name = "",
                            Code = immibMember.SICIL.ToInteger()
                        };
                        association.Id = _baseAssociationBusiness.Insert(association);
                    }

                    account.Association = association.ToEntityReferenceWrapper();
                    _baseAccountBusiness.Insert(account);
                }
                else
                {
                    _baseAccountBusiness.SetState(account.Id, (int)Account.StateCode.ACTIVE, (int)Account.StatusCode.ACTIVE);
                }
            }
        }
    }
}
