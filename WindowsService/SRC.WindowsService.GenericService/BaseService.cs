using System.ServiceProcess;

namespace SRC.WindowsService.GenericService
{
    public class BaseService : ServiceBase
    {
        public BaseService()
        {
            ServiceName = GetType().Name;
        }
    }
}
