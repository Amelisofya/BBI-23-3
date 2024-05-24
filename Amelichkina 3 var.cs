
//public struct Dot
//{
//    public int X;
//    public int Y;
//    public int Z;

//    public Dot(int[] coordinates)
//    {
//        X = coordinates[0];
//        Y = coordinates[1];
//        Z = coordinates[2];
//    }
//}

//public struct Vector
//{
//    public Dot Dot1;
//    public Dot Dot2;

//    public Vector(int[,] coordinates)
//    {
//        int[] m = new int[] { coordinates[0, 0], coordinates[0, 1], coordinates[0, 2] };
//        int[] n = new int[] { coordinates[1, 0], coordinates[1, 1], coordinates[1, 2] };
//        Dot1 = new Dot(m);
//        Dot2 = new Dot(n);
//    }

//    public double Length
//    {
//        get
//        {
//            return Math.Sqrt(
//                Math.Pow(Dot2.X - Dot1.X, 2) +
//                Math.Pow(Dot2.Y - Dot1.Y, 2) +
//                Math.Pow(Dot2.Z - Dot1.Z, 2));
//        }
//    }

//    public override string ToString()
//    {
//        return $"Первая точка: ({Dot1.X}, {Dot1.Y}, {Dot1.Z})\n" +
//               $"Вторая точка: ({Dot2.X}, {Dot2.Y}, {Dot2.Z})\n" +
//               $"Длина вектора: {Length:F2}";
//    }
//}
// class Program
//{
//    public static void Main()
//    {
//        Vector[] vectors = new Vector[]
//        {
//            new Vector(new int[,] { { 1, 6, 13 }, { -5, 10, 8 } }),
//            new Vector(new int[,] { { 29, 4, 11 }, { 0, -17, 12 } }),
//            new Vector(new int[,] { { 1, -4, 30 }, { 6, 2, 1 } }),
//            new Vector(new int[,] { { 22, 8, -1 }, { 12, 3, 0 } }),
//            new Vector(new int[,] { { 5, -10, 9 }, { 9, 13, -3 } })
//        };


//        SortVectors(vectors);

//        foreach (var vector in vectors)
//        {
//            Console.WriteLine(vector);
//            Console.WriteLine();
//        }
//    }

//    private static void SortVectors(Vector[] vectors)
//    {
//        for (int i = 0; i < vectors.Length - 1; i++)
//        {
//            for (int j = i + 1; j < vectors.Length; j++)
//            {
//                if (vectors[i].Length < vectors[j].Length)
//                {
//                    Vector temp = vectors[i];
//                    vectors[i] = vectors[j];
//                    vectors[j] = temp;
//                }
//            }
//        }
//    }
//}

public abstract class Shape
{
    public abstract double Volume { get; }

    public abstract void Calculate();

    public abstract void PrintInfo();
}

public class Sphere : Shape
{
    public double Radius { get; set; }

    public Sphere(double radius)
    {
        Radius = radius;
    }
    public override double Volume => (4 / 3) * (3.14) * Math.Pow(Radius, 3);

    public override void Calculate()
    {
        Console.WriteLine("Объем сферы: " + Volume);
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Сфера с радиусом: " + Radius);
    }
}

public class Cube : Shape
{
    public double Length { get; set; }

    public Cube(double length)
    {
        Length = length;
    }

    public override double Volume => Math.Pow(Length, 3);

    public override void Calculate()
    {
        Console.WriteLine("Объем куба: " + Volume);
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Куб с длиной: " + Length);
    }
}

public class Cylinder : Shape
{
    public double Radius { get; set; }
    public double Height { get; set; }

    public Cylinder(double radius, double height)
    {
        Radius = radius;
        Height = height;
    }

    public override double Volume => (3.14) * Math.Pow(Radius, 2) * Height;

    public override void Calculate()
    {
        Console.WriteLine($"Объем цилиндра: {Volume}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Цилиндр с радиусом {Radius} и высотой {Height}");
    }
}

public class Program
{
    public static void Main()
    {
        Sphere[] spheres = new Sphere[]
        {
            new Sphere(3),
            new Sphere(10),
            new Sphere(5),
            new Sphere(12),
            new Sphere(9)
        };

        Cube[] cubes = new Cube[]
        {
            new Cube(13),
            new Cube(8),
            new Cube(11),
            new Cube(2),
            new Cube(7)
        };

        Cylinder[] cylinders = new Cylinder[]
        {
            new Cylinder(9, 1),
            new Cylinder(4, 5),
            new Cylinder(1, 18),
            new Cylinder(14, 9),
            new Cylinder(10, 2)
        };

        SortShapes(spheres);
        SortShapes(cubes);
        SortShapes(cylinders);

        Console.WriteLine("Сферы:");
        foreach (var sphere in spheres)
        {
            sphere.PrintInfo();
            Console.WriteLine();
        }

        Console.WriteLine("Кубы:");
        foreach (var cube in cubes)
        {
            cube.PrintInfo();
            Console.WriteLine();
        }

        Console.WriteLine("Цилиндры:");
        foreach (var cylinder in cylinders)
        {
            cylinder.PrintInfo();
            Console.WriteLine();
        }

        List<Shape> allShapes = new List<Shape>();
        allShapes.AddRange(spheres);
        allShapes.AddRange(cubes);
        allShapes.AddRange(cylinders);

        SortShapes(allShapes);

        Console.WriteLine("Все фигуры:");
        foreach (var shape in allShapes)
        {
            shape.PrintInfo();
            Console.WriteLine();
        }
    }

    private static void SortShapes<Sh>(Sh[] shapes) where Sh : Shape
    {
        for (int i = 0; i < shapes.Length - 1; i++)
        {
            for (int j = i + 1; j < shapes.Length; j++)
            {
                if (shapes[i].Volume < shapes[j].Volume)
                {
                    Sh temp = shapes[i];
                    shapes[i] = shapes[j];
                    shapes[j] = temp;
                }
            }
        }
    }

    private static void SortShapes(List<Shape> shapes)
    {
        for (int i = 0; i < shapes.Count - 1; i++)
        {
            for (int j = i + 1; j < shapes.Count; j++)
            {
                if (shapes[i].Volume < shapes[j].Volume)
                {
                    Shape temp = shapes[i];
                    shapes[i] = shapes[j];
                    shapes[j] = temp;
                }
            }
        }
    }
}