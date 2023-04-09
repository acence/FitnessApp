using FitnessApp.Domain;
using FitnessApp.Infrastructure.Database.Interfaces.Base;

namespace FitnessApp.Infrastructure.Database.Interfaces
{
	public interface IWorkoutPlanRepository : IBaseRepository<WorkoutPlan>
	{
		Task<IEnumerable<WorkoutPlan>> GetWorkoutPlansForUserAsync(int userId);
	}
}
