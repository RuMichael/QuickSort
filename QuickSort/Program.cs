using System;
using System.Collections.Generic;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<double> list = new LinkedList<double>();     //наш список 

            string s;                                               // строка для сбора информации из консоли
            Console.WriteLine("Напиши stop, чтобы закончить заполнение списка");
            do
            {
                Console.Write("Введи число: ");
                s = Console.ReadLine();                             // запоминаем то что ввели в консоли
                double value;
                if (double.TryParse(s, out value))                  // проверяем что мы ввели в консоли, если соответствует типа double то передаем значение в переменную value и добавляем в наш список
                    list.AddLast(value);
            }
            while (s.IndexOf("stop") < 0);                          // цикл для ввода значений в наш спискок, будет работать пока не введешь "stop"
            
            Console.WriteLine("наш список: \n" + ShowLinkedList(list));
            QuickSort(list, 0, list.Count-1);
            Console.WriteLine("наш отсортированный список: \n" + ShowLinkedList(list));
            Console.ReadLine();
        }

        static string ShowLinkedList(LinkedList<double> list)       // возвращает строку типа string с значениями в списке list через пробел
        {
            string s = "";
            foreach (var item in list)
            {
                s += item.ToString() + " "; 
            }
            s = s.Remove(s.Length-1,1);
            return s;
        }

        static int Partition(LinkedList<double> list, int start, int end)   //лучше почитать как это работает на вики, часть сортировки QuickSort
        {
            double temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (GetItem(list,i) < GetItem(list, end))
                {
                    temp = GetItem(list, marker);
                    ChangeItem(list, marker, GetItem(list, i));
                    ChangeItem(list, i, temp);
                    marker += 1;
                }
            }
            temp = GetItem(list, marker);
            ChangeItem(list, marker, GetItem(list, end));
            ChangeItem(list, end, temp);            
            return marker;
        }

        static void QuickSort(LinkedList<double> list, int start, int end)// сортировка QuickSort
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(list, start, end);
            QuickSort(list, start, pivot - 1);
            QuickSort(list, pivot + 1, end);
        }

        static double GetItem(LinkedList<double> list, int index)       //возращает значение из списка list по значению index, если список меньше чем значение index вернет -10000
        {
            double result = -10000f;
            int count = 0;
            foreach (var item in list)
            {
                if (count == index)
                    result = item;
                count++;
            }
            return result;
        }
        
        static void ChangeItem(LinkedList<double> list, int index, double value)    // изменяет значение в списке list в позиции index на значение value
        {
            if (list.Count < index)
                return;
            LinkedList<double> tmpList = new LinkedList<double>();                  // временный список, необходим для хранения первой части списка
            for (int i = 0; i < index; i++)                                         // в цикле удаляем из списка пока не дойдем до позиции index и сохраняем первую часть в временном списке tmpList
            {
                tmpList.AddLast(list.First.Value);
                list.RemoveFirst();
            }
            list.First.Value = value;                                               //меняем значение в позиции index
            int count = tmpList.Count;                                              
            for (int i = 0; i < count; i++)                                         //записываем значения из временного списка обратно в наш список
            {
                list.AddFirst(tmpList.Last.Value);
                tmpList.RemoveLast();
            }                                                                       // LinkedList является ссылочным типом данных, в связи с этим нам не шужно его пересохранять, изменения в методе вносятся сразу в передаваемый список
        }

    }
}
