namespace Lab6.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
