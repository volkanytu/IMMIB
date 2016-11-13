using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.MockData
{
    public static class AttendanceMock
    {
        public static List<EducationAttendance> GetAttendances()
        {
            return new List<EducationAttendance>
            {
                new EducationAttendance{
                     Id=Guid.Parse("2deda20c-cdda-4925-878a-7a65e894300f"),
                     Education=new EntityReferenceWrapper(){ Id=Guid.Parse("2deda20c-cdda-4925-878a-7a65e894300f"),LogicalName="new_education"},
                     Status=EducationAttendance.StatusCode.WAITING_PAYMENT.ToOptionSetValueWrapper(),
                     Contact=new EntityReferenceWrapper(){ Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),LogicalName="contact"},
                },
                 new EducationAttendance{
                     Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),
                     Education=new EntityReferenceWrapper(){ Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),LogicalName="new_education"},
                     Status=EducationAttendance.StatusCode.JOINED.ToOptionSetValueWrapper(),
                     Contact=new EntityReferenceWrapper(){ Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),LogicalName="contact"},
                },
                 new EducationAttendance{
                     Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),
                     Education=new EntityReferenceWrapper(){ Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"),LogicalName="new_education"},
                     Status=EducationAttendance.StatusCode.JOINED .ToOptionSetValueWrapper(),
                     Contact=new EntityReferenceWrapper(){ Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"),LogicalName="contact"},
                }
            };
        }
    }
}