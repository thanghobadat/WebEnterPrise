namespace Data.Entities
{
    public class IdeaCategory
    {
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
