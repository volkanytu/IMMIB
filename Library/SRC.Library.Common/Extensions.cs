using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SRC.Library.Common
{
    public static class Extensions
    {
        private static DateTime _unixTimeStartDate = new DateTime(1970, 1, 1);

        public static int? ToUnixTimeStamp(this DateTime date)
        {
            if (date == null)
            {
                return null;
            }

            return (Int32)(date.ToUniversalTime().Subtract(_unixTimeStartDate)).TotalSeconds;
        }

        public static double ToUnixTimeStampDbl(this DateTime date)
        {
            return (date.ToUniversalTime().Subtract(_unixTimeStartDate)).TotalSeconds;
        }

        public static DateTime? ToDateTime(this int unixTimeStamp)
        {
            if (unixTimeStamp == default(int))
            {
                return null;
            }

            return _unixTimeStartDate.AddSeconds((double)unixTimeStamp).ToLocalTime();
        }

        public static DateTime? ToDateTime(this double unixTimeStamp)
        {
            if (unixTimeStamp == default(double))
            {
                return null;
            }

            return _unixTimeStartDate.AddSeconds((double)unixTimeStamp).ToLocalTime();
        }

        public static TSource QueryStringToClass<TSource>(this HttpRequest request) where TSource : new()
        {
            if (request == null)
            {
                return default(TSource);
            }

            var obj = new TSource();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new
                                 {
                                     Name = aProp.Name
                                     ,
                                     Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                                 }).ToList();

            foreach (var aField in objFieldNames)
            {
                bool hasDecriptionAttribute = CheckHasAttribute<TSource>(aField.Name, typeof(DescriptionAttribute));

                if (hasDecriptionAttribute)
                {
                    continue;
                }

                PropertyInfo propertyInfos = obj.GetType().GetProperty(aField.Name);
                Type propertyType = Nullable.GetUnderlyingType(propertyInfos.PropertyType) ?? propertyInfos.PropertyType;

                var qsValue = request.QueryString[aField.Name];

                if (propertyType.IsEnum)
                {
                    object enumValue = Enum.ToObject(propertyType, qsValue);
                    propertyInfos.SetValue(obj, enumValue, null);
                }
                else
                {
                    propertyInfos.SetValue(obj, qsValue, null);
                }
            }

            return obj;
        }

        public static bool CheckHasAttribute<T>(string propertyName, Type attributeType)
        {
            var t = typeof(T);
            var pi = t.GetProperty(propertyName);
            return Attribute.IsDefined(pi, attributeType);
        }

        public static string ToUniversalString(this string value)
        {
            value = value.Replace("ü", "u");
            value = value.Replace("ı", "i");
            value = value.Replace("ö", "o");
            value = value.Replace("ü", "u");
            value = value.Replace("ş", "s");
            value = value.Replace("ğ", "g");
            value = value.Replace("ç", "c");
            value = value.Replace("Ü", "U");
            value = value.Replace("İ", "I");
            value = value.Replace("Ö", "O");
            value = value.Replace("Ü", "U");
            value = value.Replace("Ş", "S");
            value = value.Replace("Ğ", "G");
            value = value.Replace("Ç", "C");

            return value;
        }
    }
}
