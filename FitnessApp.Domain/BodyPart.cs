using FitnessApp.Domain.Base;

namespace FitnessApp.Domain
{
    public class BodyPart : BaseModel
    {
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public String Image { get; set; } = null!;
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
