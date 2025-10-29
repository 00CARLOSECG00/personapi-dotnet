using personapi.Interfaces;
using personapi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace personapi.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly ArqPerDbContext _context;

        public ProfesionRepository(ArqPerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profesion> GetAll() => _context.Profesions.ToList();

        public Profesion? GetById(int id) => _context.Profesions.Find(id);

        public void Add(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            _context.SaveChanges();
        }
        public int Count()
        {
            return _context.Profesions.Count();
        }

        public void Update(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Profesions.Find(id);
            if (p != null)
            {
                _context.Profesions.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
