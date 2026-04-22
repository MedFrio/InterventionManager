using System;
using System.Collections.Generic;
using Observer;

namespace InterventionManager.Models
{
    public abstract class Intervention
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Lieu { get; set; }
        public TimeSpan Duree { get; set; }
        public Technicien? TechnicienAssigne { get; set; }
        public string Etat { get; private set; } = "Créée";

        private readonly List<IObserver> _observers = new();

        public Intervention()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);

        protected void Notifier()
        {
            foreach (var obs in _observers)
                obs.MettreAJour(this);
        }

        public void ChangerEtat(string nouvelEtat)
        {
            Etat = nouvelEtat;
            Notifier();
        }

        public void AssignerTechnicien(Technicien technicien)
        {
            TechnicienAssigne = technicien;
            Notifier();
        }
        public override string ToString()
        {
            return $"{GetType().Name} - {Lieu} - {Date:dd/MM/yyyy HH:mm} - {Etat}";
        }


        public abstract void Afficher();
    }
}