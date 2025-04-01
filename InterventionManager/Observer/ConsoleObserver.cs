using System;
using Models;

namespace Observer
{
    public class ConsoleObserver : IObserver
    {
        public void MettreAJour(Intervention intervention)
        {
            Console.WriteLine($"[Console] Intervention mise à jour : État = {intervention.Etat}, Technicien = {intervention?.TechnicienAssigne?.Nom ?? "Aucun"}");
        }
    }
}