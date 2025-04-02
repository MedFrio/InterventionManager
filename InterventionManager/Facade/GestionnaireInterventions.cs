using InterventionManager.Models;

using InterventionManager.Factory;

using InterventionManager.Facade;

using InterventionManager.Proxy;

namespace InterventionManager.Facade
{
    public class GestionnaireInterventions
    {
        private readonly IUser _user;
        private readonly InterventionFactory _factory = new InterventionFactory();

        public GestionnaireInterventions(IUser user)
        {
            _user = user;
        }

        public Intervention CreerIntervention(TypeIntervention type)
        {
            if (_user.Role != Role.Ecriture)
                throw new UnauthorizedAccessException("L'utilisateur n'a pas le droit de créer une intervention.");

            return _factory.CreerIntervention(type);
        }

        public void AssignerTechnicien(Intervention intervention, Technicien technicien)
        {
            if (_user.Role != Role.Ecriture)
                throw new UnauthorizedAccessException("L'utilisateur n'a pas le droit de modifier une intervention.");

            intervention.AssignerTechnicien(technicien);
        }

        public void Sauvegarder(Intervention intervention)
        {
            if (_user.Role == Role.Lecture || _user.Role == Role.Ecriture)
                _user.Sauvegarder(intervention);
            else
                throw new UnauthorizedAccessException("L'utilisateur ne peut pas sauvegarder l'intervention.");
        }
    }
}