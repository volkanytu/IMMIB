using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.Entities
{
    public class EntityContainer
    {
        public Guid? EntityId { get; set; }
        public Entity PreImage { get; set; }
        public Entity Input { get; set; }
        public Entity PostImage { get; set; }
        public SetStateEntity SetStateInput { get; set; }
        public Guid UserId { get; set; }
        public Entity Merged
        {
            get
            {
                return Input ?? PreImage ?? PostImage;
            }
        }
    }
}
