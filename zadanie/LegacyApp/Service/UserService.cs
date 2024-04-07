using System;
using LegacyApp.Validator;

namespace LegacyApp
{
    public class UserService
    {
        private IUserValidator _userValidator;
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;

        public UserService()
        {
            _userValidator = new UserValidator();
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }

        public UserService(IUserValidator userValidator, IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _userValidator = userValidator;
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if(!_userValidator.Validate(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
