using System.Runtime.Serialization;

namespace CustomerDemo.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        [IgnoreDataMember]
        public string ImageFile { get; set; }

    }
}