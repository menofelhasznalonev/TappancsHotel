using System;
using System.Collections.Generic;
using System.Text;

namespace TappancsHotel.Models
{
    public class Dog :Pet
    {
        public Dog(string name) : base(name, "Kuyta", "🐶")
        {

        }

        public override string Speak()
        {
            return "Vau vau";
        }

        public override string Play()
        {
            ChangeStats(-14, 30, -24);
            return $"{Name} boldogan labdázott! +30 jókedv";
        }
    }
}
