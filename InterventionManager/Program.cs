using System;
using System.Collections.Generic;
using InterventionManager.Factory;
using InterventionManager.Facade;
using InterventionManager.Models;
using InterventionManager.Proxy;
using InterventionManager.Decorator;
using Observer;

class Program
{
    static void Main()
    {
        Console.Title = "Intervention Manager - ESGI";
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Utilisateur courant avec rôle Ecriture
        IUser utilisateur = new UserProxy("Mohammed", Role.Ecriture);
        GestionnaireInterventions gestionnaire = new GestionnaireInterventions(utilisateur);

        List<Intervention> interventions = new();
        List<Technicien> techniciens = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n=== MENU INTERVENTION MANAGER ===\n");
            Console.WriteLine("1. Créer une intervention");
            Console.WriteLine("2. Lister les interventions");
            Console.WriteLine("3. Assigner un technicien");
            Console.WriteLine("4. Ajouter décorateurs (GPS / PJ)");
            Console.WriteLine("5. Changer état d'une intervention");
            Console.WriteLine("6. Sauvegarder une intervention");
            Console.WriteLine("7. Créer un technicien");
            Console.WriteLine("8. Lister les techniciens");
            Console.WriteLine("Q. Quitter\n");
            Console.Write("Choix : ");
            var choix = Console.ReadLine();

            switch (choix?.ToLower())
            {
                case "1":
                    Console.WriteLine("\nType d'intervention (1 = Maintenance, 2 = Urgence): ");
                    var type = Console.ReadLine();
                    TypeIntervention typeChoisi = type == "2" ? TypeIntervention.Urgence : TypeIntervention.Maintenance;
                    try
                    {
                        var intervention = gestionnaire.CreerIntervention(typeChoisi);
                        Console.Write("Lieu : ");
                        intervention.Lieu = Console.ReadLine();
                        Console.Write("Durée en heures : ");
                        intervention.Duree = TimeSpan.FromHours(double.Parse(Console.ReadLine() ?? "1"));

                        // Ajouter observateurs
                        intervention.Attach(new ConsoleObserver());
                        intervention.Attach(new LogObserver());

                        interventions.Add(intervention);
                        Console.WriteLine("✅ Intervention créée.");
                    }
                    catch (Exception e) { Console.WriteLine($"❌ Erreur : {e.Message}"); }
                    Pause();
                    break;

                case "2":
                    Lister(interventions);
                    Pause();
                    break;

                case "3":
                    if (interventions.Count == 0 || techniciens.Count == 0)
                    {
                        Console.WriteLine("⚠️ Il faut au moins une intervention et un technicien.");
                        Pause();
                        break;
                    }
                    Console.WriteLine("\nSélectionner une intervention :");
                    int indexI = Choisir(interventions);
                    Console.WriteLine("\nSélectionner un technicien :");
                    int indexT = Choisir(techniciens);
                    gestionnaire.AssignerTechnicien(interventions[indexI], techniciens[indexT]);
                    Console.WriteLine("✅ Technicien assigné.");
                    Pause();
                    break;

                case "4":
                    if (interventions.Count == 0) { Console.WriteLine("⚠️ Aucune intervention."); Pause(); break; }
                    Console.WriteLine("\nSélectionner une intervention :");
                    int index = Choisir(interventions);
                    var baseIntervention = interventions[index];

                    Console.WriteLine("Ajouter Suivi GPS ? (o/n)");
                    if (Console.ReadLine()?.ToLower() == "o")
                        baseIntervention = new SuiviGPSDecorator(baseIntervention);

                    Console.WriteLine("Ajouter Pièces Jointes ? (o/n)");
                    if (Console.ReadLine()?.ToLower() == "o")
                        baseIntervention = new PiecesJointesDecorator(baseIntervention);

                    interventions[index] = baseIntervention;
                    Console.WriteLine("✅ Décorateurs appliqués.");
                    Pause();
                    break;

                case "5":
                    if (interventions.Count == 0) { Console.WriteLine("⚠️ Aucune intervention."); Pause(); break; }
                    Console.WriteLine("\nSélectionner une intervention :");
                    int idxEtat = Choisir(interventions);
                    Console.Write("Nouvel état : ");
                    var etat = Console.ReadLine();
                    interventions[idxEtat].ChangerEtat(etat ?? "");
                    Console.WriteLine("✅ État modifié.");
                    Pause();
                    break;

                case "6":
                    if (interventions.Count == 0) { Console.WriteLine("⚠️ Aucune intervention."); Pause(); break; }
                    Console.WriteLine("\nSélectionner une intervention :");
                    int idxS = Choisir(interventions);
                    gestionnaire.Sauvegarder(interventions[idxS]);
                    Pause();
                    break;

                case "7":
                    Console.Write("Nom du technicien : ");
                    var nom = Console.ReadLine();
                    Console.Write("Email : ");
                    var email = Console.ReadLine();
                    techniciens.Add(new Technicien(nom ?? "", email ?? ""));
                    Console.WriteLine("✅ Technicien ajouté.");
                    Pause();
                    break;

                case "8":
                    if (techniciens.Count == 0) Console.WriteLine("(aucun technicien)");
                    else for (int i = 0; i < techniciens.Count; i++)
                            Console.WriteLine($"[{i}] {techniciens[i]}");
                    Pause();
                    break;

                case "q": return;
                default:
                    Console.WriteLine("⛔ Choix invalide.");
                    Pause();
                    break;
            }
        }
    }

    static void Lister(List<Intervention> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("(aucune intervention)");
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write($"[{i}] ");
            list[i].Afficher();
        }
    }

    static int Choisir<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
            Console.WriteLine($"[{i}] {list[i]}");

        Console.Write("Choix : ");
        if (int.TryParse(Console.ReadLine(), out int choix) && choix >= 0 && choix < list.Count)
            return choix;

        Console.WriteLine("⛔ Sélection invalide. Revenir au menu.");
        return 0;
    }

    static void Pause()
    {
        Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
        Console.ReadLine();
    }
}