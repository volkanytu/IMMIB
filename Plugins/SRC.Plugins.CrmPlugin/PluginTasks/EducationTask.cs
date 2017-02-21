using SRC.Library.Domain.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.PluginTasks
{
    public class EducationTask : BasePluginTask
    {
        private IEducationBusiness _educationBusiness;

        public EducationTask(IEducationBusiness educationBusiness)
        {
            _educationBusiness = educationBusiness;
        }

        protected override void PreCreate()
        {
            throw new NotImplementedException();
        }

        protected override void PostCreate()
        {
            throw new NotImplementedException();
        }

        protected override void PreUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void PostUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void PreDelete()
        {
            throw new NotImplementedException();
        }

        protected override void PostDelete()
        {
            throw new NotImplementedException();
        }

        protected override void SetState()
        {
            throw new NotImplementedException();
        }
    }
}
