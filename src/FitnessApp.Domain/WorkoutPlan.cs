using FitnessApp.Domain.Authentication;
using FitnessApp.Domain.Base;

namespace FitnessApp.Domain
{
    public class WorkoutPlan : BaseModel
    {
        public String Name { get; set; } = null!;
		public WorkoutPlanFlags Flags { get; set; }

        #region Children
        public ICollection<WorkoutDay> WorkoutDays { get; set; } = new List<WorkoutDay>();
		#endregion

		#region Parent
		public User User { get; set; } = null!;
        #endregion
    }

    [Flags]
    public enum WorkoutPlanFlags
    {
        None = 0,
        IsSystem = 1,
    }
}
