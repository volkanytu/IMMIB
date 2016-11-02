using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface ISmsBusiness
    {
        void CreateRememberPasswordSms(Contact contact, string password);
    }
}