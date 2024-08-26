using MediatR;

namespace RegistrationMock.Application.Commands
{
    public class RegisterUserCommand(string firstName, string lastName, string email, string password, string profilePicture) : IRequest<bool>
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public string ProfilePicture { get; set; } = profilePicture;
    }
}
