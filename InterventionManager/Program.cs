using System;
using InterventionManager.Factory;
using InterventionManager.Models;

class Program
{
    static void Main()
    {
        var factory = new InterventionFactory();
        var intervention = factory.CreerIntervention(TypeIntervention.Maintenance);

        intervention.Lieu = "Paris";
        intervention.Duree = TimeSpan.FromHours(2);
        intervention.TechnicienAssigne = new Technicien("Med", "Med@esgi.fr");

        intervention.Afficher();
    }
}
