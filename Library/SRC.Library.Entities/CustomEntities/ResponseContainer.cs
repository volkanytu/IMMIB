using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CustomEntities
{
    public class ResponseContainer<T>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Succes { get; set; }
        public T Result { get; set; }
    }
}
