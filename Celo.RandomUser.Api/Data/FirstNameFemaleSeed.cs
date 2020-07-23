using System.ComponentModel.DataAnnotations;

namespace Celo.RandomUser.Data
{
    public class FirstNameFemaleSeed
    {
        public FirstNameFemaleSeed(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
