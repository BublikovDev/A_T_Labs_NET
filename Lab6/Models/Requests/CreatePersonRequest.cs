namespace Lab6.Models.Requests
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsMarried { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }

        public ICollection<string> PhoneNumbers { get; set; }

        public ICollection<string> Interests { get; set; }
    }
}
