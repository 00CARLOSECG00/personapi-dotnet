namespace personapi.Interfaces
{
    using global::personapi.Models.Entities;
    using personapi.Models.Entities;

    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona? GetById(int cc);
        void Add(Persona persona);
        void Update(Persona persona);
        void Delete(int cc);
        int CountPersonas();

    }
}
