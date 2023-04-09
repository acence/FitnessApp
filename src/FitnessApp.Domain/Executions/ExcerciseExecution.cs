using FitnessApp.Domain.Base;

namespace FitnessApp.Domain.Executions
{
    public class ExcerciseExecution : BaseModel
	{ 
        public Int32 Series { get; set; }
        public Int32 Repetitions { get; set; }
        public Int32 Weight { get; set; }

        #region Parents
        public WorkoutDayExecution WorkoutDay { get; set; } = null!;
        public WorkoutExcercise Excercise { get; set; } = null!;
        #endregion
    }

    public enum ExcerciseFlags
    {
        None = 0,
        IsSetRestObserved = 1,
        IsExcerciseRestObserved = 2
    }
}
