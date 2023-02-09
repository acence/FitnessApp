using FitnessApp.Domain.Base;
using FitnessApp.Domain.Executions;

namespace FitnessApp.Domain
{
    public class WorkoutDay : BaseModel
    {
        #region Foreign keys
        public Int32 WorkoutPlanId { get; set; }
        #endregion

        public DayOfWeek DayOfWeek { get; set; }
        public WorkoutDayFlags Flags { get; set; }

        #region Children
        public ICollection<Excercise> Excercises { get; set; } = new List<Excercise>();
        public ICollection<WorkoutDayExecution> Workouts { get; set; } = new List<WorkoutDayExecution>();
        #endregion

        #region Parent
        public WorkoutPlan WorkoutPlan { get; set; } = null!;
        #endregion
    }

    [Flags]
    public enum WorkoutDayFlags
    {
        None = 0,
        ShuffleExcercises = 1,
    }
}
