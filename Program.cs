using System;
using System.Collections.Generic;

namespace LogicWaggon
{
    class Waggon
    {
        public bool isLight;
        public Waggon(bool isLight)
        {
            this.isLight = isLight;
        }
    }
    class Observer
    {
        //кол-во пройденных вагонов
        public int countWaggon = 0;

        //Метод, для переключения света в вагоне
        public void Update(Waggon waggon)
        {
            waggon.isLight = false;


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            //кол-во вагонов
            int countWaggon = random.Next(6, 20);

            //Создание объекта наблюдателя
            Observer observer = new Observer();

            List<Waggon> waggons = new List<Waggon>();

            //цикл рандомного добавления состояния света в вагоны
            for (int i = 0; i < countWaggon; i++)
            {
                waggons.Add(new Waggon(random.Next(2)==0?false:true));
            }

            //включаю свет в первом вагоне, если он выключен
            if (waggons[0].isLight == false)
            {
                waggons[0].isLight = true;
            }

            for (int i = 1; i < waggons.Count; i++)
            {

                if (waggons[i].isLight==false)
                {
                    observer.countWaggon++;
                }
                //выключаем свет, если находимся в вагоне с включенным светом
                else if (waggons[i].isLight == true)
                {
                    observer.Update(waggons[i]);

                    //идем назад до кол-ва пройденных вагонов
                    while (i >= observer.countWaggon)
                    {
                        i--;
                    }
                }
                
            }

            Console.WriteLine("Кол-во вагонов от рандома: {0}",countWaggon);
            Console.WriteLine("Кол-во вагонов посчитанные наблюдателем: {0}",observer.countWaggon);
        }

    }
}
