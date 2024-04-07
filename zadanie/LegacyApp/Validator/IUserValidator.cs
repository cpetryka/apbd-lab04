using System;

namespace LegacyApp.Validator;

public interface IUserValidator
{
    bool Validate(string firstName, string lastName, string email, DateTime dateOfBirth);
}