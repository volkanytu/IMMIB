using System;
namespace SRC.WindowsService.TestService.Interfaces
{
    interface IServiceManager
    {
        void Dispose();
        void Start();
    }
}
