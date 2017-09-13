using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace HelloWorld.Examples
{
    public class RegressionExample
    {
        public static void TryMultipleRegression()
        {
            var x0 = new[] { 1.0, 1.0, 1.0 };
            var x1 = new[] { 1.0, 2.0, 3.0 };
            var x2 = new[] { 4.0, 5.0, 2.0 };
            var y = new[] { 15.0, 20, 10 };
            var inputMatrix = CreateMatrix.DenseOfColumnArrays(x0, x1, x2);
            var targetVector = CreateVector.Dense(y);

            var p = MultipleRegression.QR(
                inputMatrix,
                targetVector);
            
            foreach (var item in p)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(GoodnessOfFit.RSquared(inputMatrix * p, targetVector));
            Console.WriteLine(GoodnessOfFit.RSquared(x1, x2));
        }
    }
}
