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

namespace Volleyball_Stat_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> lisPlayer = new List<Player> { };
        public MainWindow()
        {
            InitializeComponent();
        }

        public void DodajIgraca(object sender, RoutedEventArgs e)
        {
            if (TxtIme != null)
            {
                string imeIgraca = TxtIme.Text;
                int godineIgraca = int.Parse(TxtGodine.Text);
                int minutazaIgraca = int.Parse(TxtMinutaza.Text);
                int brojPoena = int.Parse(TxtPoeni.Text);
                string imeKluba = TxtKlub.Text;

                Player player = new Player(imeIgraca,godineIgraca,minutazaIgraca,brojPoena,imeKluba);

                lisPlayer.Add(player);
                ListaIgraca();
                Ciscenje();

                TxtNaslovListe.Visibility = Visibility.Visible;
                LstIgraci.Visibility = Visibility.Visible;
            }
        }

        public void ListaIgraca()
        {
            LstIgraci.ItemsSource = null;
            LstIgraci.ItemsSource = lisPlayer;
        }

        public void Ciscenje()
        {
            TxtIme.Clear();
            TxtGodine.Clear();
            TxtMinutaza.Clear();
            TxtPoeni.Clear();
            TxtKlub.Clear();
        }

        public void Brisanje(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Player igracZaBrisanje = btn?.DataContext as Player;

            if (igracZaBrisanje != null)
            {
                // Uklanjamo igrača iz naše liste
                lisPlayer.Remove(igracZaBrisanje);

                // Osvježavamo prikaz u ListView-u
                ListaIgraca();

                // Ako je lista ostala prazna, ponovo sakrivamo naslov i tabelu
                if (lisPlayer.Count == 0)
                {
                    TxtNaslovListe.Visibility = Visibility.Collapsed;
                    LstIgraci.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}