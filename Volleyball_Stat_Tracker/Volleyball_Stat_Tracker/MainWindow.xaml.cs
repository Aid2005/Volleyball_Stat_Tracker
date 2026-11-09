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
        Player player = new Player();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void DodajIgraca()
        {
            if (this.player != null)
            {
                player.imeIgraca = TxtIme.Text;
                player.godineIgraca = int.Parse(TxtGodine.Text);
                player.minutazaIgraca = int.Parse(TxtMinutaza.Text);
                player.brojPoena = int.Parse(TxtPoeni.Text);
                player.imeKluba = TxtKlub.Text;
            }
        }
    }
}