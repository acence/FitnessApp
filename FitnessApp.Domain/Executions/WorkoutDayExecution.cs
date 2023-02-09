using FitnessApp.Domain.Base;

namespace FitnessApp.Domain.Executions
{
    public class WorkoutDayExecution : BaseModel
    {
        #region Foreign keys
        public Int32 WorkoutDayId { get; set; }
        #endregion

        public DateTimeOffset Date { get; set; }

        #region Children
        public ICollection<ExcerciseExecution> ExcerciseExecutions { get; set; } = new List<ExcerciseExecution>();
        #endregion

        #region Parent objects
        public WorkoutDay WorkoutDay { get; set; } = null!;
        #endregion
    }
}
