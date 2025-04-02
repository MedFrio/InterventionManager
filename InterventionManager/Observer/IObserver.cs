using InterventionManager.Models;

/// <summary>
/// Interface pour tout composant observateur qui souhaite �tre notifi�
/// lors d�un changement d��tat d�une intervention.
/// </summary>
public interface IObserver
{
    void MettreAJour(Intervention intervention);
}
