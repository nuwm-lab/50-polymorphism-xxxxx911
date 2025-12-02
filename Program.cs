using System;

namespace LabWork
{
    // Базовий клас для полярної системи координат
    abstract class CoordinateSystem
    {
        public abstract double GetX();
        public abstract double GetY();
        public abstract void SetCoordinates(double first, double second);
        public abstract string GetCoordinatesDescription();
    }

    // Полярна система координат
    class PolarCoordinateSystem : CoordinateSystem
    {
        private double radius;
        private double angle;

        public PolarCoordinateSystem(double r, double a)
        {
            radius = r;
            angle = a;
        }

        public override double GetX() => radius * Math.Cos(angle * Math.PI / 180);
        public override double GetY() => radius * Math.Sin(angle * Math.PI / 180);

        public override void SetCoordinates(double r, double a)
        {
            radius = r;
            angle = a;
        }

        public override string GetCoordinatesDescription() 
            => $"Полярні координати: r={radius:F2}, φ={angle:F2}°";
    }

    // Декартова система координат
    class CartesianCoordinateSystem : CoordinateSystem
    {
        private double x;
        private double y;

        public CartesianCoordinateSystem(double xCoord, double yCoord)
        {
            x = xCoord;
            y = yCoord;
        }

        public override double GetX() => x;
        public override double GetY() => y;

        public override void SetCoordinates(double xCoord, double yCoord)
        {
            x = xCoord;
            y = yCoord;
        }

        public override string GetCoordinatesDescription() 
            => $"Декартові координати: x={x:F2}, y={y:F2}";
    }

    // Циліндрична система координат
    class CylindricalCoordinateSystem : CoordinateSystem
    {
        private double rho;
        private double phi;
        private double z;

        public CylindricalCoordinateSystem(double r, double p, double zCoord)
        {
            rho = r;
            phi = p;
            z = zCoord;
        }

        public override double GetX() => rho * Math.Cos(phi * Math.PI / 180);
        public override double GetY() => rho * Math.Sin(phi * Math.PI / 180);

        public override void SetCoordinates(double r, double p)
        {
            rho = r;
            phi = p;
        }

        public override string GetCoordinatesDescription() 
            => $"Циліндричні координати: ρ={rho:F2}, φ={phi:F2}°, z={z:F2}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("=== Демонстрація віртуальних методів ===\n");
            Console.WriteLine("Виберіть режим роботи:");
            Console.WriteLine("1 - Полярна система координат");
            Console.WriteLine("2 - Декартова система координат");
            Console.WriteLine("3 - Циліндрична система координат");
            Console.Write("\nВведіть вибір (1-3): ");
            
            string userChoose = Console.ReadLine();

            if (userChoose == "1")
            {
                // Працюємо з одним об'єктом
                CoordinateSystem polar = new PolarCoordinateSystem(5, 45);
                DemonstrateConversion(polar, "Полярна система");
            }
            else if (userChoose == "2")
            {
                // Працюємо з іншим об'єктом
                CoordinateSystem cartesian = new CartesianCoordinateSystem(3, 4);
                DemonstrateConversion(cartesian, "Декартова система");
            }
            else if (userChoose == "3")
            {
                // Працюємо з третім об'єктом
                CoordinateSystem cylindrical = new CylindricalCoordinateSystem(5, 45, 10);
                DemonstrateConversion(cylindrical, "Циліндрична система");
            }
            else
            {
                Console.WriteLine("Помилка: невірний вибір!");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        static void DemonstrateConversion(CoordinateSystem coords, string systemName)
        {
            Console.WriteLine($"\n--- {systemName} ---");
            Console.WriteLine(coords.GetCoordinatesDescription());
            Console.WriteLine($"Декартові координати: x={coords.GetX():F2}, y={coords.GetY():F2}");
        }
    }
}