using TemplateTest.Domain.Entities;

namespace TemplateTest.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    DbSet<ToDoItem> TodoItems { get; }
    DbSet<User> User { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
