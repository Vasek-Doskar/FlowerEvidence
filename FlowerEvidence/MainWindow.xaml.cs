using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;
using FlowerEvidence.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace FlowerEvidence
{
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        ObservableCollection<Flower> Data { get; set; }
        public IFlowerManager Manager { get; set; }
        private readonly IFlowerFactory _factory;
        public MainWindow(IServiceProvider serviceProvider, IFlowerFactory factory)
        {
            _factory = factory;
            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            Manager = scope.ServiceProvider.GetRequiredService<IFlowerManager>();

            Data = new ObservableCollection<Flower>(Manager.GetAll());
            InitializeComponent();
            LV.ItemsSource = Data;            
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddNewFlowerWindow AddWindow = _factory.CreateAddWindow();
            AddWindow.Owner = this; // jen pokud máte 2 monitory
            if(AddWindow.ShowDialog() == true) Data.Add(AddWindow.NewFlower);
        }

        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            Flower? toRemove = LV.SelectedItem as Flower;
            if (toRemove != null)
            {
                Manager.Remove(toRemove);
                Data.Remove(toRemove);
            }
        }

        private void OnUpdateClick(object sender, RoutedEventArgs e)
        {
            Flower? flower = LV.SelectedItem as Flower;
            if(flower != null)
            {
                UpdateExistingFlowerWindow updateWindow = _factory.CreateUpdateWindow(flower.Id);
                updateWindow.Owner = this;
                if(updateWindow.ShowDialog() == true)
                {
                    //int index = Data.IndexOf(flower);
                    //Data[index] = Manager.GetById(flower.Id);

                    Data = new ObservableCollection<Flower>(Manager.GetAll());
                    LV.ItemsSource = Data;
                }

            }
        }



    }
}