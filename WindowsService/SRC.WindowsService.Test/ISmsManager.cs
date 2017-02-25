using SRC.Library.Entities.CrmEntities;
using System;
namespace SRC.WindowsService.TestService.Interfaces
{
    public interface ISmsManager
    {
        string GetSession();
        string SendSms(SmsEnt smsEntity, string sessionId);
    }
}
