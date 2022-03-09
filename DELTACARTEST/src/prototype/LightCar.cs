using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DELTACARTEST.src.prototype;

namespace DELTACARTEST.src.prototype
{
    internal class LightCar: Car
    {
        private int _passengers;
        public int passengers {
            get => _passengers; 
            set { 
                percent = value*0.06;
                if (percent >= 1|| value > 4)
                    throw new ArgumentException("Слишком много пассажиров!");

                _passengers = value; 
            }
        }

        public LightCar(int passengers, double tankCapacity, double averageFuelCosumption) : base(tankCapacity, averageFuelCosumption, "light")
        {
            this.passengers = passengers;
        }
    }
}
