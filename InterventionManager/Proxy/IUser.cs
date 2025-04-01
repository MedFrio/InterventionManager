using InterventionManager.Models;

namespace InterventionManager.Proxy
{
    public interface IUser
    {   
        Role Role { get; }
        void Sauvegarder(Intervention intervention);
    }
}
