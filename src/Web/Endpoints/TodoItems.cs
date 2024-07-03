using Commands.CreateRequestCommand;
using Microsoft.AspNetCore.Mvc;
using TemplateTest.Application.Common.Models;
using TemplateTest.Application.TodoItems.Commands.CreateTodoItem;
using TemplateTest.Application.TodoItems.Commands.DeleteTodoItem;
using TemplateTest.Application.TodoItems.Commands.UpdateTodoItem;
using TemplateTest.Application.TodoItems.Commands.UpdateTodoItemDetail;
using TemplateTest.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace TemplateTest.Web.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoItemsWithPagination)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTodoItem, "{id}");
    }
   
    [HttpPost, Route("createRequest")]
    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    public async Task<Unit> Create(ISender sender, [FromForm] CreateRequestCommand command)
    {
        return await sender.Send(command);
    }

    public Task<PaginatedList<TodoItemBriefDto>> GetTodoItemsWithPagination(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
}
