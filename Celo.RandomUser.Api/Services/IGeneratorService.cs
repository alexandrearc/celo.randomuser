using System;
using Celo.RandomUser.Data;

namespace Celo.RandomUser.Services
{
    public interface IGeneratorService
    {
        Gender RandomGender();

        string RandomEmail(string firstName, string lastName);

        DateTime RandomDateOfBirth();

        string RandomPhoneNumber();

        int RandomNumber(int min, int max);

        User CreateUser();
    }
}