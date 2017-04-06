namespace Prodavalnik.Services
{
    using Data.Contracts;

    public class Service
    {
        protected IProdavalnikData data;

        public Service(IProdavalnikData data)
        {
            this.data = data;
        }
    }
}