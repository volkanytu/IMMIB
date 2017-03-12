using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRC.Library.Entities;
namespace SRC.Web.NewPortal.MockData
{
    public static class EducationMock
    {
        public static List<Education> GetEducations()
        {
            return new List<Education>
            {
                new Education
                {
                    Id=Guid.Parse("2deda20c-cdda-4925-878a-7a65e894300f")
                    ,City=new EntityReferenceWrapper{ Id=Guid.Parse("b6707e1c-22fb-4da0-af28-ea139bba45dc"), LogicalName="new_education",Name="MANİSA"}
                    , StartDate=DateTime.Now.AddDays(7)
                    , EndDate=DateTime.Now.AddDays(8)
                    ,Contact=new EntityReferenceWrapper{ Id=Guid.Parse("2deda20c-cdda-4925-878a-7a65e894300f"), LogicalName="contact",Name="VOLKAN SERTER"}
                    ,EducationPeriod=1
                    ,Status=new OptionSetValueWrapper(){ AttributeValue=1, Value="Beklemede"}
                    , Name="ŞİRKETLERDE KURUMSALLAŞMA"
                    ,Info="INFO"
                    ,LeftQuota=1
                    ,Code="EDU-K937925"
                    ,RecordStartDate=DateTime.Now.AddDays(7)
                    ,RecordEndDate=DateTime.Now.AddDays(8)
                    ,Quota=15
                     ,EducationAmount=1200
                }
                ,new Education
                {
                    Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82")
                    ,City=new EntityReferenceWrapper{ Id=Guid.Parse("d0e4a7d8-a89b-4bde-99af-27158b02020c"), LogicalName="new_education",Name="İZMİR"}
                    , StartDate=DateTime.Now.AddDays(28)
                    , EndDate=DateTime.Now.AddDays(30)
                    ,Contact=new EntityReferenceWrapper{ Id=Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82"), LogicalName="contact",Name="ERHAN SERTER"}
                    ,EducationPeriod=2
                    ,Status=new OptionSetValueWrapper(){ AttributeValue=1, Value="Beklemede"}
                    , Name="STRES YÖNETİMİ VE MOTİVASYON"
                    ,Code="EDU-K937926"
                    ,Info="INFO 2"
                    ,RecordStartDate=DateTime.Now.AddDays(28)
                    ,RecordEndDate=DateTime.Now.AddDays(30)
                    ,Quota=45
                }
                ,new Education
                {
                    Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755")
                    ,City=new EntityReferenceWrapper{ Id=Guid.Parse("f59e99ab-e82c-4db9-8720-7e9d2b3c1546"), LogicalName="new_education",Name="ANTALYA"}
                    , StartDate=DateTime.Now.AddDays(-5)
                    , EndDate=DateTime.Now.AddDays(-3)
                    ,Contact=new EntityReferenceWrapper{ Id=Guid.Parse("47458d2d-5155-4165-a2b6-ef4415bc7755"), LogicalName="contact",Name="NURŞAH SERTER"}
                    ,EducationPeriod=1
                    ,Status=new OptionSetValueWrapper(){ AttributeValue=2, Value="Gerçekleşti"}
                    ,Info="INFO 3"
                    ,LeftQuota=1
                    , Name="KALİTE YÖNETİMİ"
                    ,Code="EDU-K937927"
                    ,RecordStartDate=DateTime.Now.AddDays(-5)
                    ,RecordEndDate=DateTime.Now.AddDays(-3)
                    ,Quota=35
                }
                ,new Education
                {
                    Id=Guid.Parse("4011db40-a849-4c5a-bbc4-b9faf1932a66")
                    ,City=new EntityReferenceWrapper{ Id=Guid.Parse("4011db40-a849-4c5a-bbc4-b9faf1932a66"), LogicalName="new_education",Name="İSTANBUL"}
                    , StartDate=DateTime.Now.AddDays(-6)
                    , EndDate=DateTime.Now.AddDays(-3)
                    ,Contact=new EntityReferenceWrapper{ Id=Guid.Parse("e9be575a-b904-4605-8cc4-1bf3ca39504e"), LogicalName="contact",Name="BURAK YILMAZ"}
                    ,EducationPeriod=3
                    ,Status=new OptionSetValueWrapper(){ AttributeValue=2, Value="Gerçekleşti"}
                    ,Info="INFO 4"
                    , Name="İTHALAT MEVZUATI"
                    ,Code="EDU-K937928"
                    ,RecordStartDate=DateTime.Now.AddDays(-6)
                    ,RecordEndDate=DateTime.Now.AddDays(-3)
                    ,Quota=25
                }
            };
        }

        public static List<Education> GetComingEducations()
        {
            return GetEducations().Where(e => e.StartDate > DateTime.Now).ToList();
        }

        public static List<Education> GetDoneEducations()
        {
            return GetEducations().Where(e => e.StartDate < DateTime.Now).ToList();
        }
    }
}