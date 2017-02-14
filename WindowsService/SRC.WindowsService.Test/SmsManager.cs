using SRC.Library.Entities.CrmEntities;
using SRC.WindowsService.TestService.Interfaces;
using SRC.WindowsService.TestService.SmsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.WindowsService.TestService
{
    public class SmsManager : ISmsManager
    {
        //Taşınacak
        private string _accountNumber = "2014cib5967";
        private string _userName = "uyeiliskileri.immib";
        private string _password = "UyeIliskileri2015Crm";
        private string _orginator = "IMMIBUYELIK";
        private string _shortNumber = "5967";

        private MessageServices _messageService;

        public SmsManager()
        {
            _messageService = new MessageServices();
        }

        public string GetSession()
        {
            Session ses = new Session();
            ses.AccountNumber = _accountNumber;
            ses.UserName = _userName;
            ses.Password = _password;
            return _messageService.Register(ses);
        }

        public string SendSms(SmsEnt smsEntity,string sessionId)
        {
            SendSMSRequest sms = new SendSMSRequest();
            sms.DeleteDate = "";
            sms.GroupID = "0";
            sms.Isunicode = Unicode.Yes;
            sms.Operator = Operators.Turkcell;
            sms.Orginator = _orginator;
            sms.SendDate = "";
            sms.SessionID = sessionId;
            sms.ShortNumber = _shortNumber;
            sms.MessageList = new MessageList()
            {
                 ContentList = new Content[] { new Content() { Value = smsEntity.Message }},
                 GSMList = new GSM[] { new GSM() { Value = smsEntity.PhoneNumber } }
            };
            SendMessageResponse rl = _messageService.SendSMS(sms);
            if (rl.Results != null)
            {
                foreach (var r in rl.Results)
                {
                    string messageid = r.MessageID;
                    return r.Status;
                }
            }

            return "";
        }
    }
}
