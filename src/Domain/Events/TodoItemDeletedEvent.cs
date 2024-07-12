namespace TemplateTest.Domain.Events;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(ToDoItem item)
    {
        Item = item;
    }

    public ToDoItem Item { get; }
}
