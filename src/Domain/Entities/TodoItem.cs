﻿using System.ComponentModel.DataAnnotations;

public class ToDoItem
{
    public Guid Id { get; set; }

    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime DueDate { get; set; }

    [Range(1, 5)]
    public int Priority { get; set; }

    public int UserId { get; set; }

    public User? User { get; set; }
}
