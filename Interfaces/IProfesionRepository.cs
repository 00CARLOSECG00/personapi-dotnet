using personapi.Models.Entities;

namespace personapi.Interfaces
{
    public interface IProfesionRepository
    {
        IEnumerable<Profesion> GetAll();
        Profesion? GetById(int id);
        void Add(Profesion profesion);
        void Update(Profesion profesion);
        void Delete(int id);
        int Count();
    }
}
