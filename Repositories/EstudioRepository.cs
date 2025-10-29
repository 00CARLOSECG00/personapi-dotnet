using personapi.Interfaces;
using personapi.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace personapi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly ArqPerDbContext _context;

        public EstudioRepository(ArqPerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Estudio> GetAll()
        {
            return _context.Estudios.ToList();
        }

        public Estudio? GetById(int idProf, int ccPer)
        {
            return _context.Estudios
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);
        }

        public void Add(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            _context.SaveChanges();
        }

        public void Update(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
            _context.SaveChanges();
        }

        public void Delete(int idProf, int ccPer)
        {
            var estudio = GetById(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                _context.SaveChanges();
            }
        }

        public int Count()
        {
            return _context.Estudios.Count();
        }
    }
}
