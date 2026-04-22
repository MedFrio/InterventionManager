using System.IO;
using InterventionManager.Models;

namespace Observer
{
    public class LogObserver : IObserver
    {
        private readonly string _logFile = "intervention.log";

        public void MettreAJour(Intervention intervention)
        {
            var ligne = $"[Log] Intervention changée : État = {intervention.Etat}, Technicien = {intervention?.TechnicienAssigne?.Nom ?? "Aucun"}";
            File.AppendAllText(_logFile, ligne + System.Environment.NewLine);
        }
    }
}