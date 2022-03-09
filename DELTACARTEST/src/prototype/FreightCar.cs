using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELTACARTEST.src.prototype
{
    internal class FreightCar: Car
    {
        private int _cargoWeight;
        public int cargoWeight
        {
            get => _cargoWeight;
            set
            {

                percent = value * 0.04 / 200;

                if (percent >=1)
                    throw new ArgumentException("Слишком тяжелый груз!");

                _cargoWeight = value;
            }
        }

        public FreightCar(int cargoWeight, double tankCapacity, double averageFuelCosumption) : base(tankCapacity, averageFuelCosumption, "Freight")
        {
            this.cargoWeight = cargoWeight;
        }
    }
}
