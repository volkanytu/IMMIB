using SRC.Library.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SRC.Library.Entities;
using SRC.Web.NewPortal.MockData;

namespace SRC.Web.NewPortal.Controllers
{
    public class DynamicPageApiController : ApiController
    {
        private IBaseBusiness<DynamicPage> _dynamicPageBaseBusiness;

        public DynamicPageApiController(IBaseBusiness<DynamicPage> dynamicPageBaseBusiness)
        {
            _dynamicPageBaseBusiness = dynamicPageBaseBusiness;
        }

        public ResponseContainer<List<DynamicPage>> GetSliderPageList()
        {
            ResponseContainer<List<DynamicPage>> returnValue = new ResponseContainer<List<DynamicPage>>();

            //returnValue.Result = _dynamicPageBaseBusiness.GetList().Where(
            //        p => p.PageType.ToEnum<DynamicPage.PageTypeCode>() == DynamicPage.PageTypeCode.ROTATOR).ToList();
            returnValue.Result = DynamicPageMock.GetDynamicPages();
            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<DynamicPage> GetPage(int pageType)
        {
            ResponseContainer<DynamicPage> returnValue = new ResponseContainer<DynamicPage>();

            if (pageType == 3) //howto
            {
                returnValue.Result = DynamicPageMock.GetHowtoPage();
            }
            else if(pageType==5) //contact
            {
                returnValue.Result = DynamicPageMock.GetContactPage();
            }
            returnValue.Success = true;

            return returnValue;
        }
    }
}
