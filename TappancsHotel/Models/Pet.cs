using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TappancsHotel.Models
{
    public class Pet
    {


        public string Name { get; }
        public string Species { get; }
        public string Icon { get; }

        public int Fullness { get; private set; } = 70;
        public int Happiness { get; private set; } = 65;
        public int Energy { get; private set; } = 75;

        public string Mood => Happiness >= 75 ? "Nagyon Boldog" :
                              Happiness >= 45 ? "Jól van" : "Törődésre vár";

        public Pet(string name, string species, string icon)
        {
            Name = name;
            Species = species;
            Icon = icon;
        }

        public virtual string Speak()
        {
            return "Szius";
        }

        public virtual string Play()
        {
            return$"{Name} játszott egy jót!";
        }

        public void Feed()
        {
            ChangeStats(30, 5, 0);
        }

        public void GiveTreat()
        {
            ChangeStats(15, 15, 0);
        }

        public void Rest()
        {
            ChangeStats(-5, 4, 30);
        }

        public void EnjoyParty()
        {
            ChangeStats(-5, 18, -5);
        }

        public void EndDay()
        {
            ChangeStats(-15, -10, -12);
        }

        protected void ChangeStats(int fullness, int happiness, int energy)
        {
            Fullness = Math.Clamp(Fullness + fullness, 0, 100); //a maximum es minimum megadasa
            Happiness = Math.Clamp(Happiness + happiness, 0, 100);
            Energy = Math.Clamp(Energy + energy, 0, 100);
        }
    }
}
