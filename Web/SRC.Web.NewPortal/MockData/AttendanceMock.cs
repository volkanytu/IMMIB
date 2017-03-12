using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.NewPortal.MockData
{
    public static class AttendanceMock
    {
        public static List<EducationAttendance> GetAttendances()
        {
            return new List<EducationAttendance>
            {
                new EducationAttendance{
                     Id=Guid.Parse("2deda20c-cdda-4925-878a-7a65e894300f"),
                     Education=new EntityReferenceWrapper(){ Id=Guid.Parse("2deda20c-cdda-4925-878a-7a65e894300f"),LogicalName="new_education", Name="ŞİRKETLERDE KURUMSALLAŞMA"},
                     Status=EducationAttendance.StatusCode.WAITING_PAYMENT.ToOptionSetValueWrapper(),
                     Contact=new EntityReferenceWrapper(){ Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),LogicalName="contact"},
                     Code="11112222",
                     IsPaymentDone=false
                },
                 new EducationAttendance{
                     Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),
                     Education=new EntityReferenceWrapper(){ Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),LogicalName="new_education"},
                     Status=EducationAttendance.StatusCode.JOINED.ToOptionSetValueWrapper(),
                     Contact=new EntityReferenceWrapper(){ Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),LogicalName="contact"},
                     Code="2222"
                },
                 new EducationAttendance{
                     Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),
                     Education=new EntityReferenceWrapper(){ Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),LogicalName="new_education"},
                     Status=EducationAttendance.StatusCode.JOINED .ToOptionSetValueWrapper(),
                     Contact=new EntityReferenceWrapper(){ Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),LogicalName="contact"},
                     Code="3333"
                }
            };
        }

        public static List<OptionSetValueWrapper> GetInstallmentTypes()
        {
            return new List<OptionSetValueWrapper>
            {
                new OptionSetValueWrapper{ AttributeValue=1, Value="1"},
                new OptionSetValueWrapper{ AttributeValue=2, Value="2"},
                new OptionSetValueWrapper{ AttributeValue=3, Value="3"},
                new OptionSetValueWrapper{ AttributeValue=4, Value="4"},
                new OptionSetValueWrapper{ AttributeValue=5, Value="5"},
                new OptionSetValueWrapper{ AttributeValue=6, Value="6"},
                new OptionSetValueWrapper{ AttributeValue=7, Value="7"},
                new OptionSetValueWrapper{ AttributeValue=8, Value="8"},
                new OptionSetValueWrapper{ AttributeValue=9, Value="9"},


            };
        }
    }
}