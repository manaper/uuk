using TemplateTest.Application.Common.Interfaces;
using TemplateTest.Domain.Events;

namespace TemplateTest.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(Guid Id) : IRequest;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity =  _context.TodoItems
            .Where(x => x.Id == request.Id).FirstOrDefault();


        _context.TodoItems.Remove(entity);

       

        await _context.SaveChangesAsync(cancellationToken);
    }

}
