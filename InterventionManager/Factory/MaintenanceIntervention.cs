using System;
using InterventionManager.Models;

namespace InterventionManager.Factory
{
    public class MaintenanceIntervention : Intervention
    {
        public override void Afficher()
        {
            Console.WriteLine($"[MAINTENANCE] - {Date} � {Lieu}, Dur�e: {Duree}, Technicien: {TechnicienAssigne?.Nom}");
        }
    }
}
