using FitnessApp.Domain.Base;
using FitnessApp.Domain.Executions;

namespace FitnessApp.Domain
{
	public class WorkoutExcercise : BaseModel
	{
		public Int32 Series { get; set; }
		public Int32 Repetitions { get; set; }
		public TimeSpan Time { get; set; }
		public TimeSpan RestBetweenSets { get; set; }
		public TimeSpan RestUntilNextExcercise { get; set; }


		#region Children
		public ICollection<ExcerciseExecution> ExcerciseExecutions { get; set; } = new List<ExcerciseExecution>();
		#endregion

		#region Parent
		public WorkoutDay WorkoutDay { get; set; } = null!;
		public Excercise Excercise { get; set; } = null!;
		#endregion
	}
}
