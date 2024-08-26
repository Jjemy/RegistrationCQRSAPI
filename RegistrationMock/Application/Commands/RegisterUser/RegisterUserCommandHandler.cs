using MediatR;
using RegistrationMock.Application.Interfaces;
using RegistrationMock.Domain.Entities;
using RegistrationMock.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RegistrationMock.Application.Commands
{
    public class RegisterUserCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new ValidationException("Email is already taken.");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                ProfilePicture = request.ProfilePicture,
                Role = RoleEnum.Admin 
            };

            await _userRepository.AddAsync(user);

            return true;
        }
    }
}
