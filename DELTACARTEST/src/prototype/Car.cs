using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELTACARTEST.src.prototype
{
    internal abstract class Car
    {
        readonly string type;
        readonly double tankСapacity;
        protected double percent; //Доп. переменная, обозначающая процент снижения запаса хода.

        protected double _currentTankFill;
        public double currentTankFill
        {
            get { return _currentTankFill; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество топлива не может быть отрицательным!");
                if(value>tankСapacity)
                    throw new ArgumentOutOfRangeException("Бак не может столько вместить", nameof(currentTankFill));

                _currentTankFill = value;
            }
        } //доп. переменная, обозначающая количество топлива на текущий момент.

        protected int _speed;
        public int speed { get { return _speed; } set { 
                if(value < 0)
                    throw new ArgumentOutOfRangeException("Скорость на спидометре всегда больше или равна нулю!;)");

                _speed = value;
            } }

        protected double _averageFuelConsumption;
        public double averageFuelConsumption
        {
            get { return _averageFuelConsumption; }
            set{
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Расход должен быть больше нуля! Это автомобиль, а не вечный двигатель, и он не создает топливо, а расходует!");

                _averageFuelConsumption = value;
            }
        }

        public Car(double tankCapacity, double averageFuelConsumption, string type)
        {
            this.type = type;

            this.tankСapacity = tankCapacity;

            if (tankСapacity <= 0)
                throw new ArgumentOutOfRangeException("Объем бака должен быть больше нуля!");

            

            this.averageFuelConsumption = averageFuelConsumption;
        }


        //Метод высчитывает какую дистанцию автомобиль может проехать, учитывая пассажиров/груз и топливо на данный момент.
        //Процент снижения дистанции передаёт дочерний класс.
        protected double ReserveState()
        {
            double distance = (currentTankFill/averageFuelConsumption)*(1-percent)*100;

            if (distance < 0)
                if (percent % 1 == 0)
                    throw new ArgumentException("Слишком много пассажиров!", nameof(percent));
                else throw new ArgumentException("Слишком много груза!", nameof(percent));

            return distance;
        }

        public double WayTime(double dist)
        {
            if (dist<=0)
                throw new ArgumentException("Дистанция должна быть больше нуля!");

            if(dist > ReserveState())
                throw new ArgumentException("Не хватает топлива!",nameof(dist));

            double time = dist/speed;

            return time;
        }

        public void drawInfo()
        {
            Console.WriteLine("Осталось пути: "+ReserveState()+"км");
            Console.WriteLine("Осталось топлива: " + this.currentTankFill + "л");
            Console.WriteLine("Текущая скорость: " + this.speed + "км/ч");
        }

    }
}
