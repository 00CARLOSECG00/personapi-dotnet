using personapi.Interfaces;
using personapi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace personapi.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly ArqPerDbContext _context;

        public TelefonoRepository(ArqPerDbContext context)
        {
            _context = context;
        }
        public int Count()
        {
            return _context.Telefonos.Count();
        }


        public IEnumerable<Telefono> GetAll() => _context.Telefonos.ToList();

        public Telefono? GetById(string num) => _context.Telefonos.Find(num);

        public void Add(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            _context.SaveChanges();
        }

        public void Update(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            _context.SaveChanges();
        }

        public void Delete(string num)
        {
            var t = _context.Telefonos.Find(num);
            if (t != null)
            {
                _context.Telefonos.Remove(t);
                _context.SaveChanges();
            }
        }
    }
}
