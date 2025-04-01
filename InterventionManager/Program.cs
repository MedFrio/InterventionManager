using System;
using InterventionManager.Factory;
using InterventionManager.Models;
using InterventionManager.Proxy;

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

        // Simulation des rôles via Proxy
        IUser userLecture = new UserProxy("Nadia", Role.Lecture);
        IUser userEcriture = new UserProxy("Yassine", Role.Ecriture);

        // Tentative de sauvegarde avec chaque utilisateur
        userLecture.Sauvegarder(intervention);   // ❌ refusé
        userEcriture.Sauvegarder(intervention);  // ✅ accepté
    }
}
