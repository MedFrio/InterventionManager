using System;
using InterventionManager.Models;

namespace InterventionManager.Decorator
{
    public class SuiviGPSDecorator : InterventionDecorator
    {
        public SuiviGPSDecorator(Intervention intervention) : base(intervention) { }

        public override void Afficher()
        {
            _intervention.Afficher();
            Console.WriteLine("📡 Suivi GPS activé pour cette intervention.");
        }
    }
}
