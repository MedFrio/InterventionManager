using Factory;
using Models;
using Proxy;

namespace Facade
{
    public class GestionnaireInterventions
    {
        private readonly IUser _user;
        private readonly InterventionFactory _factory = new InterventionFactory();

        public GestionnaireInterventions(IUser user)
        {
            _user = user;
        }

        public Intervention CreerIntervention(string type)
        {
            if (!_user.PeutEcrire())
                throw new UnauthorizedAccessException("L'utilisateur n'a pas le droit de créer une intervention.");

            return _factory.Creer(type);
        }

        public void AssignerTechnicien(Intervention intervention, Technicien technicien)
        {
            if (!_user.PeutEcrire())
                throw new UnauthorizedAccessException("L'utilisateur n'a pas le droit de modifier une intervention.");

            intervention.AssignerTechnicien(technicien);
        }

        public void Sauvegarder(Intervention intervention)
        {
            if (!_user.PeutLire())
                throw new UnauthorizedAccessException("L'utilisateur n'a pas le droit de lire/sauvegarder une intervention.");

            intervention.Sauvegarder();
        }
    }
}