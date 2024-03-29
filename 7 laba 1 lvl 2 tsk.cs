
using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

class FootBall
{
    private protected string team_;
    protected int point_;
    protected string gender_;

    public FootBall(string team, int point, string gender)
    {
        team_ = team;
        point_ = point;
        gender_ = gender;
    }
    public virtual void Printinf()
    {
        Console.WriteLine(
        " команда {0} \t очки {1}", team_, point_);
    }
    public static void SortByTeam(FootBall[] group1)
    {
        for (int i = 0; i < group1.Length; i++)
        {
            for (int j = i + 1; j < group1.Length; j++)
            {
                if (group1[i].point_ < group1[j].point_)
                {
                    FootBall tewmp = group1[j];
                    group1[j] = group1[i];
                    group1[i] = tewmp;
                }
            }
        }
    }
}
class WomanTeam : FootBall
{
    public WomanTeam(string team, int point, string gender) : base(team, point, gender) 
    {
        gender_ = "женская команда";
    }
    public override void Printinf()
    {
        Console.WriteLine(" {0} команда {1} \t очки {2}", gender_, team_, point_);
    }

}
class MenTeam : FootBall
{
    public MenTeam(string team, int point, string gender) : base(team, point, gender)
    {
        gender_ = "мужская команда";

    }
    public override void Printinf()
    {
        Console.WriteLine(" {0} команда {1} \t очки {2}", gender_, team_, point_);
    }

}
class Program
{
    static void Main(string[] args)
    {
        MenTeam[] groupmen = new MenTeam[]
            {
            new MenTeam("Форвард", 11, " "),
            new MenTeam("Темп", 17, " "),
            new MenTeam("Лис", 9, " "),
            new MenTeam("Орел", 10, " "),
            new MenTeam("Тула", 15, " "),
            new MenTeam("Авангард", 6, " "),
            new MenTeam("Динамо", 13, " "),
            new MenTeam("Югра", 12, " "),
            new MenTeam("Ритм", 8, " "),
            new MenTeam("Скорость", 14, " "),
            new MenTeam("Снайперы", 7, " "),
            new MenTeam("Космос", 6, " "),
            };
        WomanTeam[] groupwom = new WomanTeam[]
            {
            new WomanTeam ("Авто", 9, " "),
            new WomanTeam("Даль", 13, " "),
            new WomanTeam("Кот", 11, " "),
            new WomanTeam("Арес", 18, " "),
            new WomanTeam("Спартак", 17, " "),
            new WomanTeam("Ястреб", 6, " "),
            new WomanTeam("Мотор", 10, " "),
            new WomanTeam("Снег", 7, " "),
            new WomanTeam("Ашан", 8, " "),
            new WomanTeam("Трактор", 14, " "),
            new WomanTeam("Мяч", 12, " "),
            new WomanTeam("Комета", 6, " "),
            };
      
        WomanTeam.SortByTeam(groupwom);
        MenTeam.SortByTeam(groupmen);

        FootBall[] rez = new FootBall[12];

        for (int i = 0; i < 6; i++)
        {
            rez[i] = groupmen[i];
        }

        for (int i = 0; i < 6; i++)
        {
            rez[i + 6] = groupwom[i];
        }
        FootBall.SortByTeam(rez);
        Console.WriteLine();
        Console.WriteLine("Окончательный список команд: ");

        for (int i = 0; i < 6; i++)
        {
            rez[i].Printinf();
        }
        for (int i = 6; i < 12; i++)
        {
            rez[i].Printinf();
        }
    }
}
