using FlowerEvidence.Database;
using FlowerEvidence.Interfaces;
using FlowerEvidence.Managers;
using FlowerEvidence.Models;
using FlowerEvidence.Repositories;
using System.Collections.ObjectModel;
using System.Windows;

namespace FlowerEvidence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IFlowerManager Manager {  get; set; }
        public MainWindow()
        {
            Owner = this;
            IFlowerRepository repository = new FlowerRepository(new FlowerContext());
            Manager = new FlowerManager(repository);
            InitializeComponent();

            LV.ItemsSource = new ObservableCollection<Flower>(Manager.GetAll());
        }
    }
}