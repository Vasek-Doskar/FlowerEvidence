using FlowerEvidence.Database;
using FlowerEvidence.Interfaces;
using FlowerEvidence.Managers;
using FlowerEvidence.Models;
using FlowerEvidence.Repositories;
using FlowerEvidence.Windows;
using System.Collections.ObjectModel;
using System.Windows;

namespace FlowerEvidence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Flower> Data {  get; set; }
        public IFlowerManager Manager {  get; set; }
        public MainWindow()
        {
            IFlowerRepository repository = new FlowerRepository(new FlowerContext());
            Manager = new FlowerManager(repository);
            Data = new ObservableCollection<Flower>(Manager.GetAll());
            InitializeComponent();
            LV.ItemsSource = Data;
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddNewFlowerWindow AddWindow = new(Manager);
            AddWindow.Owner = this; // jen pokud máte 2 monitory
            AddWindow.Closed += (s, e) => { Data.Add(AddWindow.NewFlower); };
            AddWindow.ShowDialog();          
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

      
    }
}