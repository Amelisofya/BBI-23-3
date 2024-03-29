using System;
using System.Security.Cryptography;

class People
{
    protected string famile_;
    private double math_;
    private double phi_;
    private double rus_;
    private double sred_;
    public double sred => sred_;

    public People(string famile, double x, double y, double z)
    {
        famile_ = famile;
        math_ = x;
        phi_ = y;
        rus_ = z;
        if (math_ > 2 && rus_ > 2 && phi_ > 2)
        {
            sred_ = (math_ + phi_ + rus_) / 3;
        }
        else
        {
            sred_ = 0;
        }
    }
 public virtual void Print()
    {
        Console.WriteLine("Фамилия :{0}\t Средний балл :{1:f2}", famile_, sred);
    }
}
class Student : People
{
    private static int _id;
    private readonly int ID;
    public Student(string famile, double x, double y, double z) : base(famile, x, y, z)
    {
        _id++;
        ID = _id;
    }
    public override void Print()
    {
        Console.WriteLine("Фамилия :{0}\t Средний балл :{1:f2}\t ID :{2}", famile_, sred, ID);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] cl = new Student[5];
        cl[0] = new Student("Веров", 4, 2, 4);
        cl[1] = new Student("Гостев", 5, 5, 5);
        cl[2] = new Student("Пупкин", 3, 4, 3);
        cl[3] = new Student("Фролов", 4, 5, 3);
        cl[4] = new Student("Горбачев", 2, 3, 3);

        static void SortBySred(People[] cl)
        {
            for (int i = 0; i < cl.Length - 1; i++)
            {
                for (int j = i + 1; j < cl.Length; j++)
                {
                    if (cl[j].sred > cl[i].sred)
                    {
                        People temp = cl[j];
                        cl[j] = cl[i];
                        cl[i] = temp;
                    }
                }
            }
        }

        SortBySred(cl);

        for (int i = 0; i < 5; i++)
        {
            cl[i].Print();
        }


        Console.WriteLine();

        for (int i = 0; i < 5; i++)
        {
            if (cl[i].sred != 0)
            {
                cl[i].Print();
            }
        }
    }


}