using System;

namespace InterventionManager.Models
{
    public abstract class Intervention
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Lieu { get; set; }                      // <-- nullable
        public TimeSpan Duree { get; set; }
        public Technicien? TechnicienAssigne { get; set; }    // <-- nullable

        public Intervention()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public abstract void Afficher();
    }
}
