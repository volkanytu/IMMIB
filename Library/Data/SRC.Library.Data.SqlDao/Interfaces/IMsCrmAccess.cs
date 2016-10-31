using Microsoft.Xrm.Sdk;
using System;
namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IMsCrmAccess
    {
        IOrganizationService CrmService { get; set; }
        IOrganizationService GetCrmService();
        Guid ServiceID { get; set; }
    }
}
