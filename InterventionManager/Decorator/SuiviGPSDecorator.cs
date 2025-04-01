using System;
using Models;

namespace Decorator
{
    public class SuiviGPSDecorator : InterventionDecorator
    {
        public SuiviGPSDecorator(Intervention intervention) : base(intervention) { }

        public override void Sauvegarder()
        {
            Console.WriteLine("[SuiviGPS] Position GPS enregistrée.");
            _intervention.Sauvegarder();
        }
    }
}