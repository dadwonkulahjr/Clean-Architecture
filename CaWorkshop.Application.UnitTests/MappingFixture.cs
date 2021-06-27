using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWorkshop.Application.UnitTests
{
    public class MappingFixture
    {
        public IMapper Mapper { get; set; }
        public MappingFixture()
        {
            Mapper = MapperFactory.Create();
        }
    }
}
