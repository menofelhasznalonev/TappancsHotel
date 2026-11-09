using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TappancsHotel.Models
{
    public class PetHotel
    {
        public List<Pet> Pets { get; } = new()
        {
            new Dog("Gyere ide"),
            new Cat("Sanyi"),
            new Dog("Feri")
        };

        public int Day { get; private set; } = 1;
        public int Money { get; private set; } = 1800;
        public int Treats { get; private set; } = 2;

        public int AverageHappiness => (int)Pets.Average(p => p.Happiness);

        public bool HasWon => Day >= 7 && Money >= 2500 && AverageHappiness >= 75;

        public string FeedPet(Pet pet)
        {
            const int price = 120;
            if (Money < price)
                return "Nincs elég pénzed az etetéshez!";

            Money -= price;
            pet.Feed();
            return $"{pet.Name} finomat evett. -{price} Ft, +30 jóllakottság";

        }

        public string RestPet(Pet pet)
        {
            pet.Rest();
            return $"{pet.Name}, pihent egyet. +30 energia";
        }

        public string GivePetTreat(Pet pet)
        {
            if (Treats == 0) 
                return "Elfogyott a jutalomfalat! Vegyél a boltból újat!";

            Treats--;
            pet.GiveTreat();
            return $"{pet.Name} jutalomfalatot kapott! +15 jókedv, jóllakottság";
        }

        public bool BuyTreatPack()
        {
            if (Money < 350)
                return false;

            Money -= 350;
            Treats += 3;
            return true;
        }

        public bool BuyParty()
        {
            if (Money < 450)
                return false;

            Money -= 450;
            foreach (Pet pet in Pets)
            {
                pet.EnjoyParty();
            }
            return true;
        }

        public string NextDay()
        {
            int income = Pets.Sum(p => 100 + p.Happiness * 2);
            Money += income;
            Day++;

            foreach (Pet pet in Pets)
            {
                pet.EndDay();
            }

            return $"Új nap kezdődött! Napi bevétel: +{income} Ft";
        }
    }
}
