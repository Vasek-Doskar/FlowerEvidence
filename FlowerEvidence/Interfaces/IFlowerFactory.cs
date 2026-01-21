using FlowerEvidence.Windows;

namespace FlowerEvidence.Interfaces
{
    public interface IFlowerFactory
    {
        public AddNewFlowerWindow CreateAddWindow();
        public UpdateExistingFlowerWindow CreateUpdateWindow(int id);
    }
}
