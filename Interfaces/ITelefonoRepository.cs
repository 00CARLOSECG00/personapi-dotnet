using personapi.Models.Entities;

namespace personapi.Interfaces
{
    public interface ITelefonoRepository
    {
        IEnumerable<Telefono> GetAll();
        Telefono? GetById(string num);
        void Add(Telefono telefono);
        void Update(Telefono telefono);
        void Delete(string num);
        int Count();
    }
}
