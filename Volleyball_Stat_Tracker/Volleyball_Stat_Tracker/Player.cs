using System;
namespace Volleyball_Stat_Tracker;

class Igrac
{
    public string imeIgraca { get; set; }
    public int godineIgraca { get; set; }
    public int minutazaIgraca { get; set; }
    public int brojPoena { get; set; }

    public string imeKluba { get; set; }

    public Igrac() { }

    public Igrac(string _imeIgraca, int _godIgraca, int _minutazaIgraca, int _brojPoena, string _imeKluba)
    {
        imeIgraca = _imeIgraca;
        godineIgraca = _godIgraca;
        minutazaIgraca = _minutazaIgraca;
        brojPoena = _brojPoena;
        imeKluba = _imeKluba;
    }
}
