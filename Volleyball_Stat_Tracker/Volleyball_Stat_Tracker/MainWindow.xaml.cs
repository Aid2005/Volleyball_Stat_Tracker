using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Volleyball_Stat_Tracker
{
    public partial class MainWindow : Window
    {
        List<Player> playerList = new List<Player>();
        Player selectedPlayer = null;
        private readonly string filePath = "players.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists(filePath))
            {
                string jsonText = File.ReadAllText(filePath);
                playerList = JsonSerializer.Deserialize<List<Player>>(jsonText) ?? new List<Player>();

                RefreshPlayerList();

                if (playerList.Count > 0)
                {
                    TxtListTitle.Visibility = Visibility.Visible;
                    LstPlayers.Visibility = Visibility.Visible;
                }
            }
        }

        public void SaveData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonText = JsonSerializer.Serialize(playerList, options);
            File.WriteAllText(filePath, jsonText);
        }

        public void AddPlayer(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("Please enter a player name!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string playerName = TxtName.Text;
            int.TryParse(TxtAge.Text, out int playerAge);
            int.TryParse(TxtMinutes.Text, out int playerMinutes);
            int.TryParse(TxtPoints.Text, out int points);
            string clubName = TxtClub.Text;

            if (selectedPlayer == null)
            {
                BtnAdd.Content = "Add Player";
                Player player = new Player(playerName, playerAge, playerMinutes, points, clubName);
                playerList.Add(player);
            }
            else
            {
                selectedPlayer.PlayerName = TxtName.Text;
                selectedPlayer.PlayerAge = playerAge;
                selectedPlayer.PlayerMinutes = playerMinutes;
                selectedPlayer.Points = points;
                selectedPlayer.ClubName = TxtClub.Text;
                BtnAdd.Content = "Add Player";
            }

            SaveData();
            RefreshPlayerList();
            ClearFields();

            TxtListTitle.Visibility = Visibility.Visible;
            LstPlayers.Visibility = Visibility.Visible;
        }

        public void RefreshPlayerList()
        {
            LstPlayers.ItemsSource = null;
            LstPlayers.ItemsSource = playerList;
        }

        public void ClearFields()
        {
            TxtName.Clear();
            TxtAge.Clear();
            TxtMinutes.Clear();
            TxtPoints.Clear();
            TxtClub.Clear();

            selectedPlayer = null;
            BtnAdd.Content = "Add Player";
        }

        public void DeletePlayer(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Player playerToDelete = btn?.DataContext as Player;

            if (playerToDelete != null)
            {
                playerList.Remove(playerToDelete);
                SaveData();
                RefreshPlayerList();

                if (playerList.Count == 0)
                {
                    TxtListTitle.Visibility = Visibility.Collapsed;
                    LstPlayers.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void UpdatePlayer(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            selectedPlayer = btn?.DataContext as Player;

            if (selectedPlayer != null)
            {
                TxtName.Text = selectedPlayer.PlayerName;
                TxtAge.Text = selectedPlayer.PlayerAge.ToString();
                TxtMinutes.Text = selectedPlayer.PlayerMinutes.ToString();
                TxtPoints.Text = selectedPlayer.Points.ToString();
                TxtClub.Text = selectedPlayer.ClubName;
                BtnAdd.Content = "Update";
            }
        }
    }
}