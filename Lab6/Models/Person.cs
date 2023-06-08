using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsMarried { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public ICollection<Interest> Interests { get; set; }

        public Address Address { get; set; }
    }
}
