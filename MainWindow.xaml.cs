using DotNetDz2;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotNetDz2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Phone> phones;

        public MainWindow()
        {
            InitializeComponent();
            phones = new List<Phone>
            {
                new Phone { Company = "Apple", Title = "iPhone 10", Price = 58000 },
                new Phone { Company = "Xiaomi", Title = "Redmi Note 10S", Price = 28000 },
                new Phone { Company = "Apple", Title = "iPhone 12 Pro Max Super IDOL", Price = 158000 },
                new Phone { Company = "Nokia", Title = "Nokia 3310", Price = 800 }

            };
            mainListBox.ItemsSource = phones;


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrEmpty(modelTextBox.Text) || string.IsNullOrEmpty(companyTextBox.Text))
            {
                MessageBox.Show("Заполните поля Модель и Производитель в правой колонке");
                return;
            }

           
            if (!decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Введите корректную цену в поле Цена");
                return;
            }

           
            phones.Add(new Phone
            {
                Company = companyTextBox.Text,
                Title = modelTextBox.Text,
                Price = Convert.ToDecimal(price)
            });

            mainListBox.Items.Refresh();

          
            modelTextBox.Clear();
            companyTextBox.Clear();
            priceTextBox.Clear();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var selectedPhone = mainListBox.SelectedItem as Phone;

            if (selectedPhone == null)
            {
                MessageBox.Show("Выберите телефон для удаления.");
                return;
            }

            phones.Remove(selectedPhone);
            mainListBox.Items.Refresh();
            modelTextBox.Clear();
            companyTextBox.Clear();
            priceTextBox.Clear();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPhone = mainListBox.SelectedItem as Phone;

            if (selectedPhone != null)
            {
                modelTextBox.Text = selectedPhone.Title;
                companyTextBox.Text = selectedPhone.Company;
                priceTextBox.Text = selectedPhone.Price.ToString();
            }
        }
    }
}


      