using System;
using InterventionManager.Models;

namespace InterventionManager.Decorator
{
    public class PiecesJointesDecorator : InterventionDecorator
    {
        public PiecesJointesDecorator(Intervention intervention) : base(intervention) { }

        public override void Afficher()
        {
            _intervention.Afficher();
            Console.WriteLine("📎 Pièces jointes ajoutées à l'intervention.");
        }
    }
}
