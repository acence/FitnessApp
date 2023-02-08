using FitnessApp.Domain.Authentication;
using FitnessApp.Domain.Base;

namespace FitnessApp.Domain
{
    public class WorkoutPlan : BaseObject
    {
        #region Foreign keys
        public int UserId { get; set; }
        #endregion
        public string Name { get; set; } = null!;

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
