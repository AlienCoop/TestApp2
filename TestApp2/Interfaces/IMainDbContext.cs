using Microsoft.EntityFrameworkCore;
using TestApp2.Models;

namespace TestApp2.Interfaces
{
    public interface IMainDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Models.Task> Tasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
