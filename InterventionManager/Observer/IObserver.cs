using Models;

namespace Observer
{
    public interface IObserver
    {
        void MettreAJour(Intervention intervention);
    }
}