namespace InterventionManager.Models
{
    public class Technicien
    {
        public string Nom { get; set; }
        public string Email { get; set; }

        public Technicien(string nom, string email = "")
        {
            Nom = nom;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Nom} ({Email})";
        }
    }
}
