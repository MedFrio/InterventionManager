using System;
using Models;

namespace Decorator
{
    public class PiecesJointesDecorator : InterventionDecorator
    {
        public PiecesJointesDecorator(Intervention intervention) : base(intervention) { }

        public override void Sauvegarder()
        {
            Console.WriteLine("[PiècesJointes] Ajout de pièces jointes simulé.");
            _intervention.Sauvegarder();
        }
    }
}