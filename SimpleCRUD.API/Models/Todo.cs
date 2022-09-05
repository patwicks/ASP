namespace SimpleCRUD.API.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public bool IsFinihed { get; set; }

    }
}
