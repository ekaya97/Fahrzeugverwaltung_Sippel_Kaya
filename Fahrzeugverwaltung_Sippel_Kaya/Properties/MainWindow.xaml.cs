using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using FahrzeugVerwaltungGUI.Properties;
using System.Globalization;

namespace Fahrzeugverwaltung_Sippel_Kaya
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 


    public class EnumConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Enum)value).ToString();
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }


    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FahrzeugVerwaltungGUI.Program.Second();

            //GetData() creates a collection of Customer data from a database
            ObservableCollection<Fahrzeugverwaltung.Fahrzeug> fahrzeugData = GetData();

            //Bind the DataGrid to the customer data
            DG1.DataContext = fahrzeugData;

        }




        private ObservableCollection<Fahrzeugverwaltung.Fahrzeug> GetData()
        {
            ObservableCollection<Fahrzeugverwaltung.Fahrzeug> fahrzeuge = new ObservableCollection<Fahrzeugverwaltung.Fahrzeug>();
            Fahrzeugverwaltung.Fahrzeug a = new Fahrzeugverwaltung.Fahrzeug("BMW", "3", "K-LS-131", 42000, 1924);
            Fahrzeugverwaltung.PKW pkw = new Fahrzeugverwaltung.PKW("VW", "Golf", "K-LS-32", 45000, 2019, 3000, 245, Fahrzeugverwaltung.Schadstoffklasse.Normal);
            FahrzeugVerwaltungGUI.Program.fahrzeuge.Add(pkw);
            FahrzeugVerwaltungGUI.Program.fahrzeuge.Add(a);

            foreach (Fahrzeugverwaltung.Fahrzeug f in FahrzeugverwaltungGUI.Program.fahrzeuge)
            {
                fahrzeuge.Add(f);
            }

            return fahrzeuge;
        }

       

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Show message box when button is clicked.
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


