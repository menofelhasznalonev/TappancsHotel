using System;
using System.Collections.Generic;
using System.Text;

namespace TappancsHotel.Models
{
    public class Cat : Pet
    {
        public Cat(string name) : base(name, "Macska", "😾")
        {

        }

        public override string Speak()
        {
            return "Miau! kutya vagyok";
        }

        public override string Play()
        {
            ChangeStats(-8, 20, -10);
            return $"{Name} a fonalgombolyaggal játszott";
        }
    }
}
