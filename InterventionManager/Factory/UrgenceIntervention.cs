using System;
using InterventionManager.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterventionManager.Factory
{
    public class UrgenceIntervention : Intervention
    {
        public override void Afficher()
        {
            Console.WriteLine($"[URGENCE] - {Date} � {Lieu}, Dur�e: {Duree}, Technicien: {TechnicienAssigne?.Nom}");
        }
    }
}
