using TemplateTest.Application.Common.Interfaces;
using TemplateTest.Domain.Entities;

namespace TemplateTest.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public User? User { get; set; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        ToDoItem entity = await _context.TodoItems.Where(x => x.Id == request.Id).FirstAsync();
           
        entity.Title = request.Title;
        entity.Description = request.Description;   
        entity.IsCompleted = request.IsCompleted;
        entity.DueDate = request.DueDate;
        entity.Priority = request.Priority;
        entity.User = request.User;

      

        await _context.SaveChangesAsync(cancellationToken);
    }
}
