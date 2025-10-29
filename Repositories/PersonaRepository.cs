using personapi.Interfaces;
using personapi.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace personapi.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ArqPerDbContext _context;

        public PersonaRepository(ArqPerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Persona? GetById(int cc)
        {
            return _context.Personas.Find(cc);
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public void Delete(int cc)
        {
            var persona = _context.Personas.Find(cc);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }
        public int CountPersonas()
        {
            return _context.Personas.Count();
        }

    }
}
