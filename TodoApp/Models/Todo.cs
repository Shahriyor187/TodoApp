using MongoDB.Bson;

namespace TodoApp.Models;

public class Todo
{
    public ObjectId Id { get; set; }
    public string Title { get; set; } = string.Empty!;
}
