using SRC.Library.Entities.CrmEntities;
using System;
namespace SRC.Library.Domain.Business.Interfaces
{
    public interface IContactBusiness
    {
        Contact GetContact(string userName);
        Contact GetContact(string userName, string password);
    }
}
