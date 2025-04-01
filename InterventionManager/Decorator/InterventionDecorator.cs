using Models;

namespace Decorator
{
    public abstract class InterventionDecorator : Intervention
    {
        protected Intervention _intervention;

        public InterventionDecorator(Intervention intervention)
        {
            _intervention = intervention;
        }

        public override void AssignerTechnicien(Technicien technicien)
        {
            _intervention.AssignerTechnicien(technicien);
        }

        public override void ChangerEtat(string nouvelEtat)
        {
            _intervention.ChangerEtat(nouvelEtat);
        }

        public override void Attach(Observer.IObserver observer)
        {
            _intervention.Attach(observer);
        }

        public override void Detach(Observer.IObserver observer)
        {
            _intervention.Detach(observer);
        }
    }
}