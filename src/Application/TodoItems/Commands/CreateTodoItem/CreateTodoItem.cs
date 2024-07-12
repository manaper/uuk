using Microsoft.VisualBasic;
using TemplateTest.Application.Common.Interfaces;
using TemplateTest.Domain.Entities;
using TemplateTest.Domain.Enums;
using TemplateTest.Domain.Events;

namespace TemplateTest.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<Guid>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public User? User { get; set; }
   
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        ToDoItem item = new ToDoItem()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted,
            DueDate = request.DueDate,
            Priority = request.Priority,
            User = request.User,

        };

       

        await _context.SaveChangesAsync(cancellationToken);

        return item.Id;
    }
}
