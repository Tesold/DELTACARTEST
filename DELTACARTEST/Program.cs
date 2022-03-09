using DELTACARTEST.src.prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELTACARTEST
{
    internal class Program
    {
        static void Main()
        {
            LightCar audi = new LightCar(4, 60, 7);
            audi.currentTankFill = 50;
            audi.speed = 80;

            audi.drawInfo();

            Console.WriteLine("Время в пути: "+audi.WayTime(400)+"ч");

            Console.Read();
        }
    }
}
