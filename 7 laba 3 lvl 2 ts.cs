using System;
using System.Text.RegularExpressions;
abstract class Cross
{
    protected string famile_;
    protected int group_;
    protected string trener_;


    protected double rez_;
    public double rez => rez_;
    public Cross(string famile, int group, string trener, double rez)
    {
        famile_ = famile;
        group_ = group;
        trener_ = trener;
        rez_ = rez; 
    }
    static void SortByNorm(Cross[] a, int l, int m, int r)

    {
        int i, j;

        int n1 = m - l + 1;
        int n2 = r - m;

        Cross[] left = new Cross[n1];
        Cross[] right = new Cross[n2];

        for (i = 0; i < n1; i++)
        {
            left[i] = a[l + i];
        }

        for (j = 1; j <= n2; j++)
        {
            right[j - 1] = a[m + j];
        }


        i = 0;
        j = 0;

        int k = l;
        while (i < n1 && j < n2)
        {
            if (left[i].rez <= right[j].rez)
            {
                a[k] = left[i];
                i++;
            }
            else
            {
                a[k] = right[j];
                j++;
            }
            k++;
        }
        while (i < n1)
        {
            a[k] = left[i];
            i++;
            k++;
        }
        while (j < n2)
        {
            a[k] = right[j];
            j++;
            k++;

        }
    }
    public static void MergeSort(Cross[] a, int l, int r)
    {
        int q;

        if (l < r)
        {
            q = (l + r) / 2;
            MergeSort(a, l, q);
            MergeSort(a, q + 1, r);
            SortByNorm(a, l, q, r);
        }
    }
    public virtual void Print()
    {
        Console.WriteLine(
        "Фамилия {0} \t Группа {1} \t Тренер {2} \t Результат {3:f2} ",
        famile_, group_, trener_);
    }
}
class Sto : Cross
{
    public Sto(string famile, int group, string trener, double rez) : base (famile, group, trener, rez)
    {

    }
    public override void Print()
    {
        Console.WriteLine(
        "Фамилия {0} \t Группа {1} \t Тренер {2} \t Результат {3:f2} ",
        famile_, group_, trener_, rez_);
    }
}
class Five : Cross
{
    public Five(string famile, int group, string trener, double rez) : base(famile, group, trener, rez)
    {

    }
      public override void Print()
    {
        Console.WriteLine(
        "Фамилия {0} \t Группа {1} \t Тренер {2} \t Результат {3:f2} ",
        famile_, group_, trener_, rez_);
    }
    
}

class Program
{
    static void Main()
    {
        Five[] five = new Five[5]
        {
            new Five("Макеева", 5, "Грачев", 55.2),
                new Five("Щербакова", 1, "Калодко", 63.3),
                new Five("Минина", 4, "Табулина", 58.9),
                new Five("Акинина ", 6, "Ермакова", 57.5),
                new Five("Рыбина", 2, "Бычков", 60.7)

        };
        Sto[] sto= new Sto[5]
       {
            new Sto("Макеева", 5, "Грачев", 21.2),
                new Sto("Щербакова", 1, "Калодко", 19.3),
                new Sto("Минина", 4, "Табулина", 20.9),
                new Sto("Акинина ", 6, "Ермакова", 18.5),
                new Sto("Рыбина", 2, "Бычков", 20.7)

       };

        Cross.MergeSort(five, 0, 4);
        Cross.MergeSort(sto, 0, 4);

        Console.WriteLine("Пятьсот метров : ");
        Console.WriteLine();
        for (int i = 0; i < 5; i++)
        {
            five[i].Print();
        }
        Console.WriteLine();
        Console.WriteLine("Сто метров : ");

        Console.WriteLine();
        for (int i = 0; i < 5; i++)
        {
            sto[i].Print();
        }
    }
}