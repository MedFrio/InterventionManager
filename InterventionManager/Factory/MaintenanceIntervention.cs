using System;
using InterventionManager.Models;

namespace InterventionManager.Factory
{
    public class MaintenanceIntervention : Intervention
    {
        public override void Afficher()
        {
            Console.WriteLine($"[MAINTENANCE] - {Date} à {Lieu}, Durée: {Duree}, Technicien: {TechnicienAssigne?.Nom}");
        }
    }
}
