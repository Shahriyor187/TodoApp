using MongoDB.Bson;

namespace TodoApp.Models.Dtos
{
    public class TodoDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = string.Empty;


        public static implicit operator Todo(TodoDto dto)
            => new()
            {
                Id = ObjectId.Parse(dto.Id),
                Title = dto.Title
            };
        public static implicit operator TodoDto(Todo dto)
            => new()
            {
                Id = dto.Id.ToString(),
                Title = dto.Title
            };
    }
}
