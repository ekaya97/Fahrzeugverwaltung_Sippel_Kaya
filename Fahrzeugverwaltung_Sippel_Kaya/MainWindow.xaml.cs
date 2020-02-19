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
using System.Globalization;

namespace Fahrzeugverwaltung_Sippel_Kaya
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 


    /*  public class enumconverter : ivalueconverter
      {

          public object convert(object value, type targettype, object parameter, cultureinfo culture)
          {
              return ((enum)value).tostring();
          }


          public object convertback(object value, type targettype, object parameter, cultureinfo culture)
          {
              return null;
          }

          <DataGridComboBoxColumn Header="Schadtstoffklasse" SelectedItemBinding="{Binding Schadstoffklasse}" ItemsSource="{Binding Source={StaticResource ResourceKey= EnumConverter}}" />


      }*/

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Fahrzeugverwaltung.Program.Second();

            //GetData() creates a collection of Customer data from a database
            ObservableCollection<Fahrzeugverwaltung.Fahrzeug> fahrzeugData = GetData();

            //Bind the DataGrid to the customer data
            DG1.DataContext = fahrzeugData;

        }




        private ObservableCollection<Fahrzeugverwaltung.Fahrzeug> GetData()
        {
            ObservableCollection<Fahrzeugverwaltung.Fahrzeug> fahrzeuge = new ObservableCollection<Fahrzeugverwaltung.Fahrzeug>();
            Fahrzeugverwaltung.PKW a = new Fahrzeugverwaltung.PKW("BMW", "3", "K-LS-131", 42000, 1924, 3000, 245, Fahrzeugverwaltung.Schadstoffklasse.Normal);
            Fahrzeugverwaltung.PKW pkw = new Fahrzeugverwaltung.PKW("VW", "Golf", "K-LS-32", 45000, 2019, 3000, 245, Fahrzeugverwaltung.Schadstoffklasse.Normal);
            Fahrzeugverwaltung.Program.fahrzeuge.Add(pkw);
            Fahrzeugverwaltung.Program.fahrzeuge.Add(a);

            foreach (Fahrzeugverwaltung.Fahrzeug f in Fahrzeugverwaltung.Program.fahrzeuge)
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
            Fahrzeugverwaltung.Fahrzeug f = (Fahrzeugverwaltung.Fahrzeug)DG1.SelectedItem;
            kennzeichenEingabe.Text = f.Kennzeichen;
            fahrzeugDatenAnzeigen();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                fahrzeugDatenAnzeigen();

            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fahrzeugDatenAnzeigen();
        }

        private void fahrzeugDatenAnzeigen()
        {
            fahrzeugDaten.Text = Fahrzeugverwaltung.Program.ausgabeFahrzeugDaten(kennzeichenEingabe.Text) + "Steuerschuld: "+  Fahrzeugverwaltung.Program.steuerschuldAusgabe(kennzeichenEingabe.Text) + "€";


        }

        private void FahrzeugDaten_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KennzeichenEingabe_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


