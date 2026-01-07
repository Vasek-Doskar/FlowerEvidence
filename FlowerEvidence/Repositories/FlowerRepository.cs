using FlowerEvidence.Database;
using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerEvidence.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly FlowerContext _context;

        public FlowerRepository(FlowerContext context)
        {
            _context = context;
        }

        public void Add(Flower flower)
        {
            _context.Add(flower);
            _context.SaveChanges(); // TOTO reálně uloží změny do DB
        }

        public void Delete(Flower flower)
        {
            if(!_context.Flowers.Any(f => f.Id == flower.Id))
            {
                return;
            }
            try
            {
                _context.Remove(flower);
                _context.SaveChanges();
            }
            catch
            {    // v případě neúspěchu vrátíme změny entity flower
                _context.Entry(flower).State = EntityState.Unchanged; 
                throw;
            }
        }

        public Flower Get(int? id)
        {
            if (id == null)
                throw new Exception("Id must be inserted!");
            return _context.Flowers.Find(id) ?? null;
        }

        public IList<Flower> GetAll()
        {
            return _context.Flowers.AsNoTracking().ToList();
        }

        public void Update(Flower flower)
        {
            _context.Entry(flower).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
