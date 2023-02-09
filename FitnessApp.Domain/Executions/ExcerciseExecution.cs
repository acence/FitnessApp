using FitnessApp.Domain.Base;

namespace FitnessApp.Domain.Executions
{
    public class ExcerciseExecution : BaseModel
    {
        #region Foreign keys
        public Int32 WorkoutDayId { get; set; }
        public Int32 ExcerciseId { get; set; }
        #endregion

        public Int32 Series { get; set; }
        public Int32 Repetitions { get; set; }
        public Int32 Weight { get; set; }

        #region Parents
        public WorkoutDayExecution WorkoutDay { get; set; } = null!;
        public Excercise Excercise { get; set; } = null!;
        #endregion
    }

    public enum ExcerciseFlags
    {
        None = 0,
        IsSetRestObserved = 1,
        IsExcerciseRestObserved = 2
    }
}
