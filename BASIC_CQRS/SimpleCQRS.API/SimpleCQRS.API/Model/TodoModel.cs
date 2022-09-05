namespace SimpleCQRS.API.Model
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public bool IsFinihed { get; set; }
    }
}
