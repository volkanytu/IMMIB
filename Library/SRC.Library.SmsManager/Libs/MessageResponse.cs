using SRC.Library.SmsManager.SmsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.SmsManager.Libs
{
    public class MessageResponse
    {

        private Result[] resultsField;

        private string errorField;

        /// <remarks/>
        public Result[] Results
        {
            get
            {
                return this.resultsField;
            }
            set
            {
                this.resultsField = value;
            }
        }

        /// <remarks/>
        public string Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }
}
