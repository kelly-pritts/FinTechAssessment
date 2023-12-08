using System.ComponentModel.DataAnnotations;

namespace PersonsManagerApi.Models
{
    public class PersonCreationRequest
    { 
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        private int _age;
        [Range(1, 100)]
        public required int Age
        {
            get { return _age; }
            set
            {
                if (value > 0 && value <= 100)
                {
                    _age = value;
                }

            }
        }

    }
}
