using System;

namespace LegacyApp;

public interface IUserCreditService
{
    void Dispose();
    int GetCreditLimit(string lastName, DateTime dateOfBirth);
}