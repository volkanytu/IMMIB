using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.SmsManager.Libs;
using SRC.Library.SmsManager.SmsApi;

namespace SRC.Library.Interfaces.SmsManager
{
    public interface ISmsManager
    {
        string GetSession();
        MessageResponse SendSms(SmsEnt smsEntity, string sessionId);
    }
}