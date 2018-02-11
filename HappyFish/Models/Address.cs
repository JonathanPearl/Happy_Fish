using System.ComponentModel.DataAnnotations;

namespace HappyFish
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public int BusinessId { get; set; }

        public string Location { get; set; }
    }
}
