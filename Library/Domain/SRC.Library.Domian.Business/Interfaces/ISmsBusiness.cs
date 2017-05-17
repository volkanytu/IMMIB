﻿using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface ISmsBusiness
    {
        void UpdateSmsResult(SmsEnt sms);
        void CreateNewContactSms(Contact contact, string password);
        void CreateRememberPasswordSms(Contact contact, string password);
    }
}