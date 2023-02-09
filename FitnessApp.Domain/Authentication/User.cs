using FitnessApp.Domain.Base;

namespace FitnessApp.Domain.Authentication
{
    public class User : BaseModel
    {
        public String Name { get; set; } = null!;
        public String Email { get; set; } = null!;
        public String Password { get; set; } = null!;
    }
}
