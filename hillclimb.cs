using System;

public class AckleyFunction
{
    private const double MinX = -5.0;
    private const double MaxX = 5.0;
    private const double MinY = -5.0;
    private const double MaxY = 5.0;

    private static readonly Random random = new Random();


    public static double Ackley(double x, double y)
    {
        double a = 20;
        double b = 0.2;
        double c = 2 * Math.PI;
        double sum1 = x * x + y * y;
        double sum2 = Math.Cos(c * x) + Math.Cos(c * y);
        double term1 = -a * Math.Exp(-b * Math.Sqrt(sum1));
        double term2 = -Math.Exp(sum2);
        return term1 + term2 + a + Math.Exp(1);
    }
    public static double hillclimb()
    {
        //first step

        double current_x = random.NextDouble() * (MaxX - MinX) + MinX;
        double current_y = random.NextDouble() * (MaxY - MinY) + MinY;
        double current_point = Ackley(current_x, current_y);

        //second and third step

        for (int i = 0; i < 1000; i++)
        {
            //random step
            double stepSize = random.NextDouble() * 0.5;
            //random x
            double next_x = random.NextDouble() - 0.5 * stepSize;
            //random y
            double next_y = random.NextDouble() - 0.5 * stepSize;
            //calculating again
            double new_point = Ackley(next_x, next_y);
            if (new_point > current_point)
            {
                current_x = next_x;
                current_y = next_y;
                current_point = new_point;
            }
        }
        return current_point;
    }
    public static void Main()
    {
        double best_x = 0.0;
        double best_y = 0.0;
        double best_point = 0.0;

        for (int i = 0; i < 1000; i++)
        {
            double main_point = hillclimb();
            if (main_point > best_point)
            {
                best_point = main_point;
            }

        }
        Console.WriteLine("THE BEST POINT IS " + best_point);
    }
}
