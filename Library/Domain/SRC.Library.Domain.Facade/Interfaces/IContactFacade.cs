using System;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;

namespace SRC.Library.Domain.Facade.Interfaces
{
    public interface IContactFacade
    {
        Contact CheckLogin(string userName, string password, string ipAddress);
        void RememberPassWord(string userName);
        void UpdatePassWord(Guid? contactId, string password);
        Guid? CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        void CreateLoginLog(EntityReferenceWrapper contact, string ipAddress);
        Contact GetContact(Guid? contactId);
        bool CheckUserExists(string userName);
        Guid CreateAttachment(Attachment attacment);
    }
}