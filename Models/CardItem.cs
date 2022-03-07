namespace KanbanAPI.Models
{
    public class CardItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public TypeCard TypeCard { get; set; }
        public string? Title { get; set; }
        public Status Status { get; set; }
        public string? Description { get; set; }
    }
}
