using SRC.Library.Entities.CrmEntities;
using System;
namespace SRC.Library.Domain.Business.Interfaces
{
    public interface IAccountBusiness
    {
        Account GetAccount(string taxNumber);
    }
}
