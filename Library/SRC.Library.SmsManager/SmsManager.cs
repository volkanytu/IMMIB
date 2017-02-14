using SRC.Library.Common;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.Interfaces.SmsManager;
using SRC.Library.SmsManager.Libs;
using SRC.Library.SmsManager.SmsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.SmsManager
{
    public class SmsManager : ISmsManager
    {
        private MessageServices _messageService;
        private SmsConfig _smsConfig;

        public SmsManager(SmsConfig smsConfig)
        {
            _messageService = new MessageServices();
            _smsConfig = smsConfig;
        }

        public string GetSession()
        {
            Session ses = new Session();
            ses.AccountNumber = _smsConfig.AccountNumber;
            ses.UserName = _smsConfig.UserName;
            ses.Password = _smsConfig.Password;
            return _messageService.Register(ses);
        }

        public MessageResponse SendSms(SmsEnt smsEntity, string sessionId)
        {
            SendSMSRequest sms = new SendSMSRequest();
            sms.DeleteDate = "";
            sms.GroupID = "0";
            sms.Isunicode = Unicode.No;
            sms.Operator = Operators.Turkcell;
            sms.Orginator = _smsConfig.Orginator;
            sms.SendDate = "";
            sms.SessionID = sessionId;
            sms.ShortNumber = _smsConfig.ShortNumber;
            sms.MessageList = new MessageList()
            {
                ContentList = new Content[] { new Content() { Value = smsEntity.Message.RemoveInvalidCharactersByAscii(_smsConfig.InvalidCharacters) } },
                GSMList = new GSM[] { new GSM() { Value = smsEntity.PhoneNumber } }
            };
            SendMessageResponse rl = _messageService.SendSMS(sms);
            MessageResponse returnValue = new MessageResponse();
            returnValue.Error = rl.Error;
            returnValue.Results = rl.Results;
            

            return returnValue;
        }
    }
}
