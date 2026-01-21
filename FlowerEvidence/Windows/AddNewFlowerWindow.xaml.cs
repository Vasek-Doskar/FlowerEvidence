using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlowerEvidence.Windows
{
    /// <summary>
    /// Interaction logic for AddNewFlowerWindow.xaml
    /// </summary>
    public partial class AddNewFlowerWindow : Window
    {
        IFlowerManager _manager;
        public Flower NewFlower {  get; private set; }
        public AddNewFlowerWindow(IFlowerManager manager)
        {
            _manager = manager;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewFlower = GetFlower();
                _manager.Add(NewFlower);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Flower GetFlower()
        {
            string name = NameInput.Text;
            string genus = GenusInput.Text;
            string color = ColorInput.Text;

            if (name.Length > 2 && genus.Length > 2 && ColorInput.SelectedIndex != -1)
            {
                return new Flower { Name = name, Genus = genus, Color = color };
            }
            throw new Exception("The input data are incorrect!");
        }
    }
}
