using Domain = FitnessApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Infrastructure.Database.Interfaces;

namespace FitnessApp.Core.Application.UseCases.User.Handlers
{
	public class GetLoginUser : IRequestHandler<GetLoginUser.Query, Domain.Authentication.User?>
	{
		private readonly IUserRepository _userRepository;

		public GetLoginUser(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task<Domain.Authentication.User?> Handle(Query request, CancellationToken cancellationToken)
		{
			return await _userRepository.GetForLogin(request.Email, request.Password);
		}

		public class Query : IRequest<Domain.Authentication.User?>
		{
			public String Email { get; set; } = null!;
			public String Password { get; set; } = null!;
		}

	}
}
