using PersonsManagerApi.Data;

namespace PersonsManagerApi.Models
{
    public class PersonsResponse : Response
    {
        public List<Person>? Persons { get; set; }
       
    }
}
