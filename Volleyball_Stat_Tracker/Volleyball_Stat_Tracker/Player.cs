using System;

namespace Volleyball_Stat_Tracker
{
    class Player
    {
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public int PlayerMinutes { get; set; }
        public int Points { get; set; }
        public string ClubName { get; set; }

        public Player() { }

        public Player(string _playerName, int _playerAge, int _playerMinutes, int _points, string _clubName)
        {
            PlayerName = _playerName;
            PlayerAge = _playerAge;
            PlayerMinutes = _playerMinutes;
            Points = _points;
            ClubName = _clubName;
        }

        public string PrintInfo()
        {
            string text = $"Club: {ClubName} | Age: {PlayerAge} | Minutes: {PlayerMinutes} | Points: {Points}";
            return text;
        }
    }
}