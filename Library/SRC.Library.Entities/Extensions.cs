using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using SRC.Library.Entities.CustomEntities;

namespace SRC.Library.Entities
{
    public static class Extensions
    {
        public static EntityReferenceWrapper ToEntityReferenceWrapper(this object entityObject)
        {
            EntityReferenceWrapper returnValue = null;

            if (entityObject == null)
            {
                return null;
            }

            System.Reflection.MemberInfo info = entityObject.GetType();

            var schemaAttr = info.GetCustomAttributes(typeof(CrmSchemaName), false).OfType<CrmSchemaName>().FirstOrDefault();

            if (schemaAttr != null)
            {
                string entityName = schemaAttr.SchemaName;

                var id = entityObject.GetType().GetProperty("Id").GetValue(entityObject, null);
                var nameProperty = entityObject.GetType().GetProperty("Name") ??
                                   entityObject.GetType().GetProperty("Subject");
                var name = nameProperty.GetValue(entityObject, null);

                if (id != null && name != null)
                {
                    returnValue = new EntityReferenceWrapper();

                    returnValue.Id = (Guid)id;
                    returnValue.Name = name.ToString();
                    returnValue.LogicalName = entityName;
                }

                return returnValue;
            }
            else
            {
                return null;
            }
        }

        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                        return attr.Description;
                }
            }
            return value.ToString();
        }

        public static TEnum? ToEnum<TEnum>(this OptionSetValueWrapper optionSetValue) where TEnum : struct, IConvertible
        {
            if (optionSetValue != null)
            {
                return (TEnum)(object)optionSetValue.AttributeValue;
            }

            return null;
        }

        public static OptionSetValueWrapper ToOptionSetValueWrapper(this Enum enumValue)
        {
            if (enumValue != null)
            {
                return new OptionSetValueWrapper()
                {
                    AttributeValue = (int)(object)enumValue
                };
            }

            return null;
        }

        public static TEnum? ToEnum<TEnum>(this string enumString) where TEnum : struct, IConvertible
        {
            if (string.IsNullOrWhiteSpace(enumString))
            {
                return null;
            }

            return (TEnum)Enum.Parse(typeof(TEnum), enumString, true);
        }

        public static TValue CastObject<TValue>(this object objectValue)
        {
            if (objectValue != null)
            {
                return (TValue)objectValue;
            }

            return default(TValue);
        }

        public static EntityReferenceWrapper ToEntityReferenceWrapper<TClass>(this Guid objectId) where TClass : class
        {
            EntityReferenceWrapper returnValue = null;

            if (objectId == Guid.Empty)
            {
                return null;
            }

            MemberInfo info = typeof(TClass);

            var schemaAttr = info.GetCustomAttributes(typeof(CrmSchemaName), false).OfType<CrmSchemaName>().FirstOrDefault();

            if (schemaAttr != null)
            {
                string entityName = schemaAttr.SchemaName;

                returnValue = new EntityReferenceWrapper
                {
                    Id = objectId,
                    LogicalName = entityName
                };

                return returnValue;
            }

            return null;
        }

        public static void CheckNull(this object obj, string errorMessage, string logKey = null, string contextIdentifier = null)
        {
            if (obj == null || (obj is string && string.IsNullOrEmpty((string) obj)))
            {
                throw new CustomException(errorMessage, logKey, contextIdentifier);
            }
        }
    }
}
