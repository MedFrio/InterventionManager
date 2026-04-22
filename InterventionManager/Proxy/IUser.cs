using InterventionManager.Models;

namespace InterventionManager.Proxy
{
    public interface IUser
    {
        public Role Role { get; }
        void Sauvegarder(Intervention intervention);
    }
}
