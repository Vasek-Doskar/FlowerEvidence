using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;

namespace FlowerEvidence.Managers
{
    public class FlowerManager : IFlowerManager
    {
        private readonly IFlowerRepository _repository;

        public FlowerManager(IFlowerRepository repository)
        {
            _repository = repository;
        }

        public void Add(Flower flower)
        {
            _repository.Add(flower);
        }

        public IList<Flower> GetAll()
        {
            return _repository.GetAll();
        }

        public Flower GetById(int? id)
        {
            return _repository.Get(id);
        }

        public void Remove(Flower flower)
        {
            _repository.Delete(flower);
        }

        public void Update(Flower flower)
        {
            _repository.Update(flower);
        }
    }
}
