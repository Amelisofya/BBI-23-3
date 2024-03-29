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
    public virtual void Print()
    {
        Console.WriteLine(
        "Фамилия {0} \t Группа {1} \t Тренер {2} \t Результат {3:f2} ",
        famile_, group_, trener_);
    }
}
class Sto:Cross
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


        static void SortByNorm(Cross[] five)
        {
            for (int i = 0; i < five.Length - 1; i++)
            {
                for (int j = i + 1; j < five.Length; j++)
                {
                    if (five[j].rez < five[i].rez)
                    {
                        Cross temp = five[j];
                        five[j] = five[i];
                        five[i] = temp;
                    }
                }
            }
        }
        SortByNorm(five);
        SortByNorm(sto);

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