using FitnessApp.Domain.Base;

namespace FitnessApp.Domain.Executions
{
    public class ExcerciseExecution : BaseObject
    {
        #region Foreign keys
        public int WorkoutDayId { get; set; }
        public int ExcerciseId { get; set; }
        #endregion

        public int Series { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }

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
