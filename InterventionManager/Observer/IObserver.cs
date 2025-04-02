using InterventionManager.Models;

/// <summary>
/// Interface pour tout composant observateur qui souhaite être notifié
/// lors d’un changement d’état d’une intervention.
/// </summary>
public interface IObserver
{
    void MettreAJour(Intervention intervention);
}
