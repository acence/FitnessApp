using FitnessApp.Domain;
using FitnessApp.Domain.Authentication;
using FitnessApp.Infrastructure.Database.Base;
using FitnessApp.Infrastructure.Database.Interfaces;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitnessApp.Infrastructure.Database.Repositories
{
	public class WorkoutPlanRepository : BaseRepository<WorkoutPlan>, IWorkoutPlanRepository
	{
		public WorkoutPlanRepository(IDatabaseContext context, ILogger<BaseRepository<WorkoutPlan>> logger) : base(context, logger){}

		public async Task<IEnumerable<WorkoutPlan>> GetWorkoutPlansForUserAsync(int userId)
		{
			return await Select().ToListAsync();
		}
	}
}
