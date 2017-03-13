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
using SRC.Web.NewPortal.filters;
using System.Configuration;

namespace SRC.Web.NewPortal.Controllers
{
    public class DynamicPageApiController : ApiController
    {
        private IBaseBusiness<DynamicPage> _dynamicPageBaseBusiness;
        private bool isMockActive = bool.Parse(ConfigurationManager.AppSettings["isMockActive"]);

        public DynamicPageApiController(IBaseBusiness<DynamicPage> dynamicPageBaseBusiness)
        {
            _dynamicPageBaseBusiness = dynamicPageBaseBusiness;
        }

        public ResponseContainer<List<DynamicPage>> GetSliderPageList()
        {
            ResponseContainer<List<DynamicPage>> returnValue = new ResponseContainer<List<DynamicPage>>();

            if (isMockActive)
            {
                returnValue.Result = DynamicPageMock.GetDynamicPages();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _dynamicPageBaseBusiness.GetList().Where(p => p.PageType.ToEnum<DynamicPage.PageTypeCode>() == DynamicPage.PageTypeCode.ROTATOR).ToList();
                returnValue.Success = true;
                returnValue.Message = "Ana sayfa banner bilgileri çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<DynamicPage> GetPage(int pageType)
        {
            ResponseContainer<DynamicPage> returnValue = new ResponseContainer<DynamicPage>();

            if (isMockActive)
            {
                if (pageType == 3) //howto
                {
                    returnValue.Result = DynamicPageMock.GetHowtoPage();
                }
                else if (pageType == 5) //contact
                {
                    returnValue.Result = DynamicPageMock.GetContactPage();
                }
                else if (pageType == 6) //apply text???
                {
                    returnValue.Result = DynamicPageMock.GetApply();
                }
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _dynamicPageBaseBusiness.GetList().Where(p => p.PageType.ToEnum<DynamicPage.PageTypeCode>() == (DynamicPage.PageTypeCode)pageType)
                    .ToList().FirstOrDefault();

                returnValue.Success = true;
                returnValue.Message = "Dinamik sayfa içeriği çekildi.";
            }

            return returnValue;
        }
    }
}
