using System;
using System.ComponentModel.DataAnnotations;

namespace Celo.RandomUser.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name => $"{Title} {FirstName} {LastName}";
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureSmall { get; set; }
        public string ProfilePictureLarge { get; set; }
        public Gender Gender { get; set; }
    }
}
