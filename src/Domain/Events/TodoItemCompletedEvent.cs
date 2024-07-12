namespace TemplateTest.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(ToDoItem item)
    {
        Item = item;
    }

    public ToDoItem Item { get; }
}
