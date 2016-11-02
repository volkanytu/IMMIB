using SRC.Library.Entities;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface ILoginLogBusiness
    {
        void Create(EntityReferenceWrapper contact, string ipAddress);
    }
}