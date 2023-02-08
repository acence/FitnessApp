using FitnessApp.Domain.Base;

namespace FitnessApp.Domain
{
    public class BodyPart : BaseObject
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public Intensity Intensity { get; set; }

        #region Connections
        public ICollection<Excercise> Excercises { get; set; } = new List<Excercise>();
        #endregion
    }
    public enum Intensity
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }
}
