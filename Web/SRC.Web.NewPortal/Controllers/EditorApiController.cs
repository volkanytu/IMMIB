using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Web.NewPortal.filters;
using SRC.Web.NewPortal.MockData;
using SRC.Web.NewPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SRC.Web.NewPortal.Controllers
{
    public class EditorApiController : ApiController
    {
        private ICommonBusiness _commonBusiness;

        private bool isMockActive = bool.Parse(ConfigurationManager.AppSettings["isMockActive"]);

        public EditorApiController(ICommonBusiness commonBusiness)
        {
            _commonBusiness = commonBusiness;
        }

        public ResponseContainer<string> GetEntityFieldValue(string id, string typeName, int typeCode, string fieldName)
        {
            ResponseContainer<string> returnValue = new ResponseContainer<string>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = "<strong>HELLO WORLD BOLD</strong>";
                returnValue.Success = true;
            }
            else
            {
                id.CheckNull("Entity id parametresi eksik.", "ENTITY_ID_NULL");
                typeName.CheckNull("İlgili Entity bulunamadı", "ENTITY_NOT_FOUND", typeCode.ToString());
                fieldName.CheckNull("Alan adı parametresi eksik", "FIELD_NAME_NULL", fieldName.ToString());

                id = id.Replace("{", "").Replace("}", "");

                var value = _commonBusiness.GetEntityFieldValue(Guid.Parse(id), typeName, fieldName);

                returnValue.Result = value != null ? value.ToString() : string.Empty;
                returnValue.Success = true;
            }

            return returnValue;
        }

        [HttpPost]
        public ResponseContainer<bool> SetEntityFieldValue(SaveEditorTestRequest request)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = true;
                returnValue.Success = true;
            }
            else
            {
                request.id.CheckNull("Entity id parametresi eksik.", "ENTITY_ID_NULL");
                request.typeName.CheckNull("İlgili Entity bulunamadı", "ENTITY_NOT_FOUND", request.typeCode.ToString());
                request.fieldName.CheckNull("Alan adı parametresi eksik", "FIELD_NAME_NULL", request.fieldName.ToString());
                request.fieldValue.CheckNull("Alan değeri parametresi eksik", "FIELD_VALUE_NULL", request.fieldName.ToString());

                request.id = request.id.Replace("{", "").Replace("}", "");

                var entityRef = new EntityReferenceWrapper()
                {
                    Id = Guid.Parse(request.id),
                    LogicalName = request.typeName,
                };

                _commonBusiness.UpdateEntityField(entityRef, new KeyValuePair<string, object>(request.fieldName, request.fieldValue));

                returnValue.Result = true;
                returnValue.Success = true;
                returnValue.Message = "İçerik güncelleme başarılı.";
            }

            return returnValue;
        }

    }
}
