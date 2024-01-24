using System.Runtime.CompilerServices;

namespace TodoApp.Models.Dtos
{
    public class AddTodoDto
    {
        public string Title { get; set; } = null!;
        public static implicit operator Todo(AddTodoDto dto)
            => new()
            {
                Title = dto.Title          
            };
    }
}
