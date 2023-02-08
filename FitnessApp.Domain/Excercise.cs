using FitnessApp.Domain.Base;
using FitnessApp.Domain.Executions;

namespace FitnessApp.Domain
{
    public class Excercise : BaseObject
    {
        #region Foreign keys
        public int WorkoutDayId { get; set; }
        #endregion

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public TimeSpan RestBetweenSets { get; set; }
        public TimeSpan RestUntilNextExcercise { get; set; }

        #region Children
        public ICollection<ExcerciseExecution> ExcerciseExecutions { get; set; } = new List<ExcerciseExecution>();
        #endregion

        #region Connections
        public ICollection<BodyPart> BodyParts { get; set; } = new List<BodyPart>();
        #endregion

        #region Parent
        public WorkoutDay WorkoutDay { get; set; } = null!;
        #endregion
    }
}
