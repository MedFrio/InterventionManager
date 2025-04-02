using System;
using InterventionManager.Factory;
using InterventionManager.Models;
using InterventionManager.Proxy;
using InterventionManager.Decorator;
using Observer;

class Program
{
    static void Main()
    {
        // Création via Factory
        var factory = new InterventionFactory();
        var intervention = factory.CreerIntervention(TypeIntervention.Maintenance);

        intervention.Lieu = "Paris";
        intervention.Duree = TimeSpan.FromHours(2);
        intervention.TechnicienAssigne = new Technicien("Med", "Med@esgi.fr");

        // Affichage de l'intervention
        intervention.Afficher();

        Console.WriteLine();

         // Décorateurs
        intervention = new SuiviGPSDecorator(intervention);
        intervention = new PiecesJointesDecorator(intervention);

        // Observateurs
        var consoleObs = new ConsoleObserver();
        var logObs = new LogObserver();
        intervention.Attach(consoleObs);
        intervention.Attach(logObs);
        
        // Changer l'état
        intervention.ChangerEtat("En cours");
        intervention.ChangerEtat("Terminé");

        // Affichage de l'intervention
        intervention.Afficher();

        Console.WriteLine();

        // Simulation des rôles via Proxy
        IUser userLecture = new UserProxy("Nadia", Role.Lecture);
        IUser userEcriture = new UserProxy("Yassine", Role.Ecriture);

        // Tentative de sauvegarde avec chaque utilisateur
        userLecture.Sauvegarder(intervention);   // ❌ refusé
        userEcriture.Sauvegarder(intervention);  // ✅ accepté
    }
}
