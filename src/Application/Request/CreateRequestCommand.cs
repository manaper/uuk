

using TemplateTest.Application.Common.Interfaces;
using TemplateTest.Domain.Entities;

namespace Commands.CreateRequestCommand;

    public class CreateRequestCommand : IRequest<Unit>
    {
        public string? Iin { get; set; }
        public string? InnScan { get; set; }
        public string? Ogrnip { get; set; }
        public string? OgrnipScan { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? LeaseAgreementScan { get; set; }
     
    }

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        public CreateRequestCommandHandler(IApplicationDbContext context,
           IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }
        public async Task<Unit> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            TodoItem item = new TodoItem();
            item.Title = request.InnScan;
            item.Note = request.OgrnipScan;
            item.Reminder = request.RegistrationDate;
            
             _context.TodoItems.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
