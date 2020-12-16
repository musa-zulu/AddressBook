using AddressBook.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AddressBook.Tests.Common.Helpers
{
    public class FakeContactDbContext
    {
        public FakeContactDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                         .UseInMemoryDatabase(name)
                         .Options;

            DbContext = new ApplicationDbContext(options);
        }
        public ApplicationDbContext DbContext;

        public async Task Add(params object[] data)
        {
            DbContext.AddRange(data);
            await DbContext.SaveChangesAsync();
        }
    }
}
