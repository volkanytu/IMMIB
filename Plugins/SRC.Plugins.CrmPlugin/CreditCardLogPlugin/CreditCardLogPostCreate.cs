using Microsoft.Xrm.Sdk;
using SRC.Plugins.CrmPlugin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.CreditCardLogPlugin
{
    public class CreditCardLogPostCreate : BasePlugin, IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            base.DoWork(serviceProvider, TaskType.CREDIT_CARD_LOG, PluginOperation.POST_CREATE);
        }
    }
}
