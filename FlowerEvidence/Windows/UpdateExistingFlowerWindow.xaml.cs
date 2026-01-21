using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        public UpdateExistingFlowerWindow(int id, IServiceProvider provider)
        {
            _serviceProvider = provider;
            _manager = _serviceProvider.GetRequiredService<IFlowerManager>();
            Flower = _manager.GetById(id);            
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
