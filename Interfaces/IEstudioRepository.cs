using personapi.Models.Entities;
using System.Collections.Generic;

namespace personapi.Interfaces
{
    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetAll();
        Estudio? GetById(int idProf, int ccPer); 
        void Add(Estudio estudio);
        void Update(Estudio estudio);
        void Delete(int idProf, int ccPer);
        int Count(); 
    }
}
