using System;

// Батьківський клас Triangle
class Triangle
{
    protected double a;
    protected double b;
    protected double c;
    protected double kutrad;
    protected double p;

    // Конструктор
    public Triangle(double a, double b, double kutgrad)
    {
        this.a = a;
        this.b = b;
        this.kutrad = kutgrad * Math.PI / 180.0;
        this.c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(kutrad));
        this.p = (a + b + c) / 2.0;
    }

    public void Print()
    {
        Console.WriteLine($"Сторона A = {a}");
        Console.WriteLine($"Сторона B = {b}");
        Console.WriteLine($"Кут мiж сторонами = {kutrad:F3} рад");
        Console.WriteLine($"Сторона C = {c:F3}");
        Console.WriteLine($"Напiвпериметр = {p:F3}");
    }

    public virtual double Sqr()
    {
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));  /////находження площі трикутника за формулою Герона
        return s;
    }

    public double Radius()
    {
        double r = (Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / p); /////знаходження радіуса вписаного кола трикутника S/P
        return r;
    }
}

class Rectangular : Triangle
{
    public Rectangular(double a, double b) : base(a, b, 90.0)
    {
    }

    public override double Sqr()
    {
        double s = (a * b) / 2; // площа прямокутного трикутника 
        return s;
    }

    public double Radiusop()
    {
        double r = Math.Sqrt(a * a + b * b) / 2; // радiус описаного кола
        return r;
    }
}

class Program
{
    static void Main(string[] args)
    {
        double p, s, r = 0;
        Random random = new Random();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\n Трикутник №{i + 1}:");
            double A = random.Next(2, 10);
            double B = random.Next(2, 10);
            double kutgrad = random.Next(5, 175);

            Triangle t; // Оголошуємо змінну базового класу

            if (kutgrad == 90.0)
            {
                t = new Rectangular(A, B); // якщо кут 90 градусів, то створюємо об'єкт дочірнього класу
                Rectangular t1 = new Rectangular(A, B);
                r = t1.Radiusop();
            }
            else
            {
                t = new Triangle(A, B, kutgrad); // інакше створюємо об'єкт базового класу Triangle
            }
            t.Print();
            Console.WriteLine($"Площа трикутника: {t.Sqr():F2}");
            Console.WriteLine($"Радiус вписаного кола: {t.Radius():F2}");
            if (kutgrad == 90.0) Console.WriteLine($"Радiус описаного кола: {r:F2}");
        }
    }
}
