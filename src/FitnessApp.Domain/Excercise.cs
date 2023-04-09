using FitnessApp.Domain.Base;
using FitnessApp.Domain.Executions;

namespace FitnessApp.Domain
{
    public class Excercise : BaseModel
    {
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public String Image { get; set; } = null!;
		public ExcerciseFlags Flags { get; set; }

        #region Connections
        public ICollection<BodyPart> BodyParts { get; set; } = new List<BodyPart>();
		#endregion

		#region Children
		public ICollection<WorkoutExcercise> WorkoutExcercises { get; set; } = new List<WorkoutExcercise>();
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
