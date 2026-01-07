using FlowerEvidence.Models;

namespace FlowerEvidence.Interfaces
{
    public interface IFlowerManager
    {
        public void Add(Flower flower);
        public void Remove(Flower flower);
        public Flower GetById(int? id);
        public IList<Flower> GetAll();
        public void Update(Flower flower);
    }
}
