using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;
using System.Windows;

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
                DialogResult = true;
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
