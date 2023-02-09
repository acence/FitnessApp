using FitnessApp.Domain.Base;
using FitnessApp.Domain.Executions;

namespace FitnessApp.Domain
{
    public class Excercise : BaseModel
    {
        #region Foreign keys
        public int WorkoutDayId { get; set; }
        #endregion

        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public String Image { get; set; } = null!;
        public Int32 Series { get; set; }
        public Int32 Repetitions { get; set; }
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
