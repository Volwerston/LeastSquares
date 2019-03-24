using System;
using System.Collections.Generic;

namespace LeastSquaresAlgorithm
{
    public class LeastSquaresAlgorithm
    {
        public static double[] Calculate(int n, double[] x, double[] y)
        {
            var toReturn = new List<double>();

            double xsum = 0;
            double x2sum = 0;
            double ysum = 0;
            double xysum = 0;      
            
            for (var i = 0; i < n; i++)
            {
                xsum += x[i];                        
                ysum += y[i];                        
                x2sum += Math.Pow(x[i], 2);          
                xysum += x[i] * y[i];                 
            }

            var a = (n * xysum - xsum * ysum) / (n * x2sum - xsum * xsum);            
            var b = (x2sum * ysum - xsum * xysum) / (x2sum * n - xsum * xsum);                                

            for (var i = 0; i < n; i++)
                toReturn.Add(a * x[i] + b); 

            return toReturn.ToArray();
        }
    }
}
