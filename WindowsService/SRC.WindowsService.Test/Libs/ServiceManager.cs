using SRC.Library.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Interfaces.SmsManager;
using SRC.Library.SmsManager.Libs;
using SRC.WindowsService.TestService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Entities;
using SRC.Library.Domain.Business.Interfaces;

namespace SRC.WindowsService.TestService.Libs
{
    public class ServiceManager : IDisposable, IServiceManager
    {
        private IBaseBusiness<SmsEnt> _baseSmsBusiness;
        private ISmsBusiness _smsBusiness;
        private ISmsManager _smsManager;

        private System.Timers.Timer _timer;
        private const int INTERVAL = 30 * 1000;
        private bool isDisposed = false;

        public ServiceManager(IBaseBusiness<SmsEnt> baseSmsBusiness, ISmsBusiness smsBusiness, ISmsManager smsManager)
        {
            _baseSmsBusiness = baseSmsBusiness;
            _smsBusiness = smsBusiness;
            _smsManager = smsManager;
        }

        public void Start()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = INTERVAL;
            _timer.AutoReset = true;

            ProcessSmsToSend();

            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            _timer.Start();

        }

        public void Dispose()
        {
            isDisposed = true;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            _timer.Stop();

            ProcessSmsToSend();

            _timer.Enabled = true;
            _timer.Start();
        }

        private void ProcessSmsToSend()
        {
            string sessionId = _smsManager.GetSession();

            List<SmsEnt> smsList = _baseSmsBusiness.GetList();

            foreach (var smsEntity in smsList)
            {
                if (isDisposed)
                {
                    break;
                }

                MessageResponse response = _smsManager.SendSms(smsEntity, sessionId);
                if (response.Results != null)
                {
                    var result = response.Results[0];

                    smsEntity.MessageID = result.MessageID;
                    smsEntity.MessageStatus = result.Status;

                    if (result.Status == "0")
                    {
                        smsEntity.Status = SmsEnt.StatusCode.SENT.ToOptionSetValueWrapper();
                    }
                    else
                    {
                        smsEntity.Status = SmsEnt.StatusCode.CANT_SEND.ToOptionSetValueWrapper();
                    }
                }

                _smsBusiness.UpdateSmsResult(smsEntity);
            }
        }
    }
}
