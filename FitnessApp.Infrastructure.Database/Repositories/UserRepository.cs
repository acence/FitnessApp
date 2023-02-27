using FitnessApp.Domain.Authentication;
using FitnessApp.Infrastructure.Database.Base;
using FitnessApp.Infrastructure.Database.Interfaces;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitnessApp.Infrastructure.Database.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(IDatabaseContext context, ILogger<BaseRepository<User>> logger) : base(context, logger)
		{
		}

		public async Task<User?> GetForLogin(String email, String password)
		{
			return await Select().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
		}
	}
}
