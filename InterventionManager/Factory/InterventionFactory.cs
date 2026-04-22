using InterventionManager.Models;

namespace InterventionManager.Factory
{
    public class InterventionFactory
    {
        public Intervention CreerIntervention(TypeIntervention type)
        {
            switch (type)
            {
                case TypeIntervention.Maintenance:
                    return new MaintenanceIntervention();
                case TypeIntervention.Urgence:
                    return new UrgenceIntervention();
                default:
                    throw new ArgumentException("Type d’intervention inconnu");
            }
        }
    }
}
