using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }

        public string State { get; set; }

    }
}
