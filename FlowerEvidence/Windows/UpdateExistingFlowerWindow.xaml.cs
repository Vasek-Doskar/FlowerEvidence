using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;
using System.Windows;

namespace FlowerEvidence.Windows
{
    /// <summary>
    /// Interaction logic for UpdateExistingFlowerWindow.xaml
    /// </summary>
    public partial class UpdateExistingFlowerWindow : Window
    {
        public Flower Flower { get; set; }
        private readonly IFlowerManager _manager;
        public UpdateExistingFlowerWindow(Flower flower, IFlowerManager manager)
        {
            Flower = flower;
            _manager = manager;
            InitializeComponent();
            DataContext = Flower;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string color = ColorInput.Text;
            Flower.Color = color;
            _manager.Update(Flower);            
            DialogResult = true;
            Close();
        }
    }
}
