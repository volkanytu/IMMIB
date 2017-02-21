using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.Entities
{
    public class SetStateEntity
    {
        public EntityReference EntityMoniker { get; set; }
        public OptionSetValue Status { get; set; }
        public OptionSetValue State { get; set; }
    }
}
