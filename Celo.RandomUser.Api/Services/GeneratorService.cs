using System;
using System.Linq;
using Celo.RandomUser.Data;

namespace Celo.RandomUser.Services
{
    public class GeneratorService : IGeneratorService
    {

        private Random _genRandom = new Random();
        private readonly RandomUserDbContext _context;

        public GeneratorService(RandomUserDbContext context)
        {
            _context = context;
        }

        public Gender RandomGender()
        {
            var index = RandomNumber(0, 1);
            return (Gender)index;
        }

        public string RandomEmail(string firstName, string lastName)
        {
            var initial = lastName.Substring(0);
            return $"{firstName}{initial}@example.com";
        }

        public DateTime RandomDateOfBirth()
        {
            DateTime start = new DateTime(1920, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_genRandom.Next(range));
        }

        public string RandomPhoneNumber()
        {
            return $"0{RandomNumber(10, 99)} {RandomNumber(10, 99)} {RandomNumber(1000, 9999)}";
        }

        public int RandomNumber(int min, int max)
        {
            return _genRandom.Next(min, max);
        }

        public User CreateUser()
        {
            var gender = RandomGender();

            var firstName = IsMale(gender) ? _context.MaleNames.Skip(RandomNumber(1, 50)).FirstOrDefault().Name
                : _context.FemaleNames.Skip(RandomNumber(1, 50)).FirstOrDefault().Name;
            var lastName = _context.LastNames.Skip(RandomNumber(1, 50)).FirstOrDefault().Name;

            var user = new User
            {
                Title = IsMale(gender) ? "Sr." : "Miss",
                DateOfBirth = RandomDateOfBirth(),
                PhoneNumber = RandomPhoneNumber(),
                FirstName = firstName,
                LastName = lastName,
                Email = RandomEmail(firstName, lastName)
            };
            return user;
        }

        private bool IsMale(Gender gender)
        {
            return Gender.Male == gender;
        }
    }
}
