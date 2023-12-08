using System;

namespace PersonsManagerApi.Data
{
    /// <summary>
    /// Sub for EF Context
    /// </summary>
    public static class SeedData
    {
        private static List<Person> _persons = new List<Person>();
        private static Random _random = new Random();
        public static Person AddPerson(Person newPerson)
        {
            newPerson.Id = _random.Next(6, 1000);
            _persons.Add(newPerson);

            return newPerson;
        }
        public static List<Person> Persons() {  return _persons; }
        public static Person GetPerson(int id) {
            try
            {
                Person? person = _persons.Find(x => x.Id == id);
                if(person == null)
                {
                    throw new Exception("Invalid Person");
                }
                return person;
            }
            catch { throw new Exception("Invalid Person"); }
        }
        public static Person UpdatePerson(int index, Person personToUpdate)
        {
            try
            {
                _persons[index] = personToUpdate;

                return personToUpdate;
            }
            catch { throw new Exception("Invalid Person"); }
        }
        public static bool DeletePerson(int index)
        {
            try
            {
                _persons.RemoveAt(index);

                return true;
            }
            catch { throw new Exception("Invalid Person"); }
        }

        public static void DeleteAll()
        {
            _persons.Clear();
        }

        public static void GenerateSeedData()
        {
            _persons.Add(new Person()
            {
                Id = 1,
                FirstName = "Kelly",
                LastName = "Pritts",
                Age = 29,
            });
            _persons.Add(new Person()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Smith",
                Age = 59,
            });
            _persons.Add(new Person()
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Doe",
                Age = 88,
            });
            _persons.Add(new Person()
            {
                Id = 4,
                FirstName = "Price",
                LastName = "Miller",
                Age = 21,
            });
            _persons.Add(new Person()
            {
                Id = 5,
                FirstName = "Peter",
                LastName = "Fuller",
                Age = 30,
            });
        }

    }
}
