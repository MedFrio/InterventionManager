using InterventionManager.Models;

namespace InterventionManager.Decorator
{
    public abstract class InterventionDecorator : Intervention
    {
        protected Intervention _intervention;

        protected InterventionDecorator(Intervention intervention)
        {
            _intervention = intervention;
        }

        public override void Afficher()
        {
            _intervention.Afficher();
        }
    }
}
