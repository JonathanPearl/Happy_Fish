namespace HappyFish.Models
{
    public class Comparator
    {
        public int ComparatorId { get; set; }
        public int ProductId { get; set; }
        public int OtherProductId { get; set; }
        public bool IsFood { get; set; }
        public bool Friendly { get; set; }
    }
}