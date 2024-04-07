using System;

namespace LegacyApp.Validator;

public class UserValidator : IUserValidator
{
    private int CalculateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age;
    }

    public bool Validate(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }

        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        if (CalculateAge(dateOfBirth) < 21)
        {
            return false;
        }

        return true;
    }
}