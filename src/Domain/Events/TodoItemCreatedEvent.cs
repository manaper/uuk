namespace TemplateTest.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(ToDoItem item)
    {
        Item = item;
    }

    public ToDoItem Item { get; }
}
