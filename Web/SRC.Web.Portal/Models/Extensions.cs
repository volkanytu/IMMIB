using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Entities;

namespace SRC.Web.Portal.Models
{
    public static class Extensions
    {
        public static SelectList ToSelectList<T>(this List<T> list, EntityReferenceWrapper value)
        {
            if (list.Count == 0)
            {
                return null;
            }

            SelectList returnValue = value != null
                ? new SelectList(list, "Id", "Name", value.Id)
                : new SelectList(list, "Id", "Name");
            return returnValue;
        }

        public static EntityReferenceWrapper ToEntityReferenceWrapper(this string id, string logicalName)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            EntityReferenceWrapper returnValue = new EntityReferenceWrapper()
            {
                Id = new Guid(id),
                LogicalName = logicalName
            };
            return returnValue;
        }

        public static List<SelectListItem> ToSelectListItems<T>(this List<T> entityObjectList)
        {
            if (entityObjectList.Count == 0)
            {
                return null;
            }

            System.Reflection.MemberInfo info = entityObjectList[0].GetType();

            var schemaAttr = info.GetCustomAttributes(typeof(CrmSchemaName), false).OfType<CrmSchemaName>().FirstOrDefault();

            if (schemaAttr != null)
            {
                var returnValue = new List<SelectListItem>();
                returnValue.AddRange(from item in entityObjectList
                                     let id = item.GetType().GetProperty("Id").GetValue(item, null)
                                     let nameProperty = item.GetType().GetProperty("Name") ?? item.GetType().GetProperty("Subject")
                                     let name = nameProperty.GetValue(item, null)
                                     where id != null && name != null
                                     select new SelectListItem()
                                     {
                                         Text = name.ToString(),
                                         Value = id.ToString()
                                     });

                //foreach (var item in entityObjectList)
                //{
                //    var id = item.GetType().GetProperty("Id").GetValue(entityObject, null);
                //    var nameProperty = item.GetType().GetProperty("Name") ??
                //                       item.GetType().GetProperty("Subject");
                //    var name = nameProperty.GetValue(entityObject, null);

                //    if (id != null && name != null)
                //    {
                //        returnValue.Add(new SelectListItem()
                //        {
                //            Text = name.ToString(),
                //            Value = id.ToString()
                //        });
                //    }
                //}


                return returnValue;
            }
            return null;
        }


    }
}