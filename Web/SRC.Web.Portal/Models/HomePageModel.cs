﻿using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.Models
{
    public class HomePageModel
    {
        public List<DynamicPage> SliderData { get; set; }
        public List<Education> ComingEducations { get; set; }
        public List<Education> DoneEducations { get; set; }
    }
}