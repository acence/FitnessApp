using FitnessApp.Domain.Base;
using FitnessApp.Domain.Executions;

namespace FitnessApp.Domain
{
    public class Excercise : BaseModel
    {
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public String Image { get; set; } = null!;
        public Int32 Series { get; set; }
        public Int32 Repetitions { get; set; }
		public TimeSpan Time { get; set; }
        public TimeSpan RestBetweenSets { get; set; }
        public TimeSpan RestUntilNextExcercise { get; set; }


        #region Children
        public virtual ICollection<ExcerciseExecution> ExcerciseExecutions { get; set; } = new List<ExcerciseExecution>();
        #endregion

        #region Connections
        public virtual ICollection<BodyPart> BodyParts { get; set; } = new List<BodyPart>();
        #endregion

        #region Parent
        public virtual WorkoutDay WorkoutDay { get; set; } = null!;
		#endregion
	}

	[Flags]
	public enum ExcerciseFlags
	{
		None = 0,
		IsWeightExcercise = 1,
		IsTimeExcercise = 2
	}
}
