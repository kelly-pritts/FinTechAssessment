using System.ComponentModel.DataAnnotations;

namespace PersonsManagerApi.Models
{
    public class PersonUpdateRequest : Request
    {
        public required int Id { get; set; }
        
    }
}
