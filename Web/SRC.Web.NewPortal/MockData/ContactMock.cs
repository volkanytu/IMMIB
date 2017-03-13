﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Web.NewPortal.MockData
{
    public static class ContactMock
    {
        public static Contact GetContact()
        {
            Contact contact = new Contact();
            contact.Id = Guid.Parse("d5d39c8c-08f0-443b-bc46-349c21334b82");
            contact.Name = "Burak Yılmazzzz";
            contact.FirstName = "Burak";
            contact.LastName = "Yılmaz";
            contact.BirthDate = DateTime.Now.AddYears(-20);
            contact.Gender = new OptionSetValueWrapper()
            {
                AttributeValue = 1,
                Value = "Erkek"
            };
            contact.MobilePhone = "05438499258";
            contact.GsmOperator = new EntityReferenceWrapper()
            {
                Id = Guid.NewGuid(),
                LogicalName = "new_gsmoperator",
                Name = "Turkcell"
            };
            contact.WorkPhone = "02122653214";
            contact.Fax = "02122653215";
            contact.EmailAddress = "burak.yilmazzz@immib.org.tr";
            contact.TaxNumber = "123456798";
            contact.CompanyName = "SRC Danışmanlık";
            contact.CompanyPosition = "CTO";
            contact.TaxOffice = new EntityReferenceWrapper()
            {
                Id = Guid.NewGuid(),
                LogicalName = "new_taxxoffice",
                Name = "Beyoğlu"
            };
            contact.CompanyAddress = "Bağdat Caddesi No:24 Kadıköy/İstanbul";
            contact.InformedBy = new EntityReferenceWrapper()
            {
                Id = Guid.NewGuid(),
                LogicalName = "new_informedby",
                Name = "Sosyal Medya"
            };
            contact.City = new EntityReferenceWrapper()
            {
                Id = Guid.NewGuid(),
                LogicalName = "new_informedby",
                Name = "Sosyal Medya"
            };
            contact.EducationLevel = new OptionSetValueWrapper()
            {
                AttributeValue = (int)Contact.EducationLevelCode.HIGH_SCHOOL,
                Value = "Lise"
            };

            return contact;
        }

        public static List<EntityReferenceWrapper> GetCities()
        {
            return new List<EntityReferenceWrapper>
            {
                new EntityReferenceWrapper{ Id=Guid.NewGuid(), Name="İstanbul", LogicalName="new_city"},
                new EntityReferenceWrapper{ Id=Guid.NewGuid(), Name="İzmir", LogicalName="new_city"}
            };
        }

        public static List<OptionSetValueWrapper> GetEducationLevels()
        {
            return new List<OptionSetValueWrapper>
            {
                new OptionSetValueWrapper{ AttributeValue=1, Value="İlköğretim"},
                new OptionSetValueWrapper{ AttributeValue=2, Value="Lise"},
                new OptionSetValueWrapper{ AttributeValue=3, Value="Lisans"},
            };
        }

        public static List<OptionSetValueWrapper> GetGenderCodes()
        {
            return new List<OptionSetValueWrapper>
            {
                new OptionSetValueWrapper{ AttributeValue=1, Value="Kadın"},
                new OptionSetValueWrapper{ AttributeValue=2, Value="Erkek"},
            };
        }


    }
}