using System;
using System.Collections.Generic;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<double> list = new LinkedList<double>();

            string s;
            Console.WriteLine("Напиши stop, чтобы закончить заполнение списка");
            do
            {
                Console.Write("Введи число: ");
                s = Console.ReadLine();
                double value;
                if (double.TryParse(s, out value))
                    list.AddLast(value);
            }
            while (s.IndexOf("stop") < 0);
            
            Console.WriteLine("наш список: \n" + ShowLinkedList(list));
            QuickSort(list, 0, list.Count-1);
            Console.WriteLine("наш отсортированный список: \n" + ShowLinkedList(list));
            Console.ReadLine();
        }

        static string ShowLinkedList(LinkedList<double> list)
        {
            string s = "";
            foreach (var item in list)
            {
                s += item.ToString() + " "; 
            }
            s = s.Remove(s.Length-1,1);
            return s;
        }

        static int Partition(LinkedList<double> list, int start, int end)
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

        static void QuickSort(LinkedList<double> list, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(list, start, end);
            QuickSort(list, start, pivot - 1);
            QuickSort(list, pivot + 1, end);
        }

        static double GetItem(LinkedList<double> list, int index)
        {
            if (list.Count < index)
                return -10000f;
            double result=-1;
            int count = 0;
            foreach (var item in list)
            {
                if (count == index)
                    result = item;
                count++;
            }
            return result;
        }
        
        static void ChangeItem(LinkedList<double> list, int index, double value)
        {
            if (list.Count < index)
                return;
            LinkedList<double> tmpList = new LinkedList<double>();
            for (int i = 0; i < index; i++)
            {
                tmpList.AddLast(list.First.Value);
                list.RemoveFirst();
            }
            list.First.Value = value;
            int count = tmpList.Count;
            for (int i = 0; i < count; i++)
            {
                list.AddFirst(tmpList.Last.Value);
                tmpList.RemoveLast();
            }
        }

    }
}
