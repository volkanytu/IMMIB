using AutoMapper;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities
{
    public class EntityMapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //ÖRNEK
                cfg.CreateMap<Contact, EntityBase>()
                    .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                    .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
                    ;

            }
            );

            return config.CreateMapper();
        }
    }
}
