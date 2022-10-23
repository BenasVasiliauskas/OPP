using System.Security.Cryptography.X509Certificates;

namespace TowerDefense.Server.Observer
{
    public abstract class Observer
    {
        private Subject subject;

        public abstract void UpdateUnits();
    }
}
