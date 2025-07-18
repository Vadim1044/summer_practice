namespace task14;
using System;
using System.Threading;

public class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> func, double step, int threadCount)
    {
        double result = 0;
        object lockObj = new object();
        int finished = 0;

        double chunk = (b-a)/threadCount;

        for (int i = 0; i<threadCount;i++)
        {
            double start = a + i *chunk;
            double end = (i == threadCount -1)?b:start+chunk;

            new Thread(()=>
            {
                double sum = 0;
                for (double x = start; x<end; x+=step)
                {
                    double nextX = Math.Min(x+step, end);
                    sum += (func(x)+func(nextX))*(nextX - x)/2;
                }
                lock (lockObj)
                {
                    result+=sum;
                    finished++;
                }
            }).Start();
        }
        while (true)
        {
            lock (lockObj)
            {
                if (finished==threadCount)
                    break;
            }
            Thread.Sleep(10);
        }

        return result;
    }
}
