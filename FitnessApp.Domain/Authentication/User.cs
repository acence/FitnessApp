using FitnessApp.Domain.Base;

namespace FitnessApp.Domain.Authentication
{
    public class User : BaseObject
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
