using FitnessApp.Domain.Authentication;
using FitnessApp.Infrastructure.Database.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Infrastructure.Database.Interfaces
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User?> GetForLogin(String email, String password);
	}
}
