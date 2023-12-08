using System.ComponentModel.DataAnnotations;

namespace PersonsManagerApi.Models
{
    public class PersonUpdateRequest
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [Range(1, 100)]
        public required int Age { get; set; }
    }
}
