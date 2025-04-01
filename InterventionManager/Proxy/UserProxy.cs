using System;
using InterventionManager.Models;

namespace InterventionManager.Proxy
{
    public enum Role
    {
        Lecture,
        Ecriture
    }

    public class UserProxy : IUser
    {
        private readonly string _nom;
        public Role Role { get; }

        public UserProxy(string nom, Role role)
        {
            _nom = nom;
            Role = role;
        }

        public void Sauvegarder(Intervention intervention)
        {
            if (Role == Role.Ecriture)
            {
                Console.WriteLine($" {_nom} a sauvegard� l'intervention {intervention.Id}");
                // Simuler la sauvegarde dans un fichier ou base
            }
            else
            {
                Console.WriteLine($" {_nom} n'a pas les droits pour sauvegarder l'intervention.");
            }
        }
    }
}
