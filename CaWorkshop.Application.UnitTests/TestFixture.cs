using AutoMapper;
using CaWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWorkshop.Application.UnitTests
{
    public class TestFixture : IDisposable
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }
        public TestFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = MapperFactory.Create();
        }
        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}
