using MongoDB.Bson;

namespace TodoApp.Models.Dtos
{
    public class UpdateDto 
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = string.Empty;

        public static implicit operator Todo(UpdateDto dto)
            => new()
            {
                Id = ObjectId.Parse(dto.Id),
                Title = dto.Title,
            };
    }
}
