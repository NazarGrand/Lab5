using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private double[] ryeData = new double[4] { 15, 10, 9, 7 };
        private double[] oatData = new double[4] { 19, 13, 8, 6 };
        private double[] wheatData = new double[4] { 20, 12, 12, 4 };
        private double[] buckwheatData = new double[4] { 21, 15, 10, 4 };

        private double[] p = new double[4] { 0.1, 0.4, 0.2, 0.3 };

        public double B_Rye()
        {
            double res = 0;
               for(int i = 0; i < ryeData.Length; i++)
              res += ryeData[i] * p[i];
               return res;
        }

        public double B_Oat()
        {
            double res = 0;
            for (int i = 0; i < oatData.Length; i++)
                res += oatData[i] * p[i];
            return res;
        }

        public double B_Wheat()
        {
            double res = 0;
            for (int i = 0; i < wheatData.Length; i++)
                res += wheatData[i] * p[i];
            return res;
        }

        public double B_Buckwheat()
        {
            double res = 0;
            for (int i = 0; i < buckwheatData.Length; i++)
                res += buckwheatData[i] * p[i];
            return res;
        }

        public void MinimumVariance() //мінімальна дисперсія
        {
            double D_Rye=0;
            double b_Rye = B_Rye();

            for(int i = 0; i < ryeData.Length; i++)
                D_Rye += p[i] * Math.Pow((ryeData[i] - b_Rye),2);
            double d_Rye = Math.Sqrt(D_Rye);
            Console.WriteLine(d_Rye);

            double D_Oat = 0;
            double b_Oat = B_Oat();

            for (int i = 0; i < oatData.Length; i++)
                D_Oat += p[i] * Math.Pow((oatData[i] - b_Oat), 2);
            double d_Oat = Math.Sqrt(D_Oat);
            Console.WriteLine(d_Oat);

            double D_Wheat = 0;
            double b_Wheat = B_Wheat();

            for (int i = 0; i < wheatData.Length; i++)
                D_Wheat += p[i] * Math.Pow((wheatData[i] - b_Wheat), 2);
            double d_Wheat = Math.Sqrt(D_Wheat);
            Console.WriteLine(d_Wheat);

            double D_Buckwheat = 0;
            double b_Buckwheat = B_Buckwheat();

            for (int i = 0; i < buckwheatData.Length; i++)
                D_Buckwheat += p[i] * Math.Pow((buckwheatData[i] - b_Buckwheat), 2);
            double d_Buckwheat = Math.Sqrt(D_Buckwheat);
            Console.WriteLine(d_Buckwheat);

            double[] mas = new double[4] { d_Rye, d_Oat, d_Wheat, D_Buckwheat };
            int index = 0;
            double min = mas[0];

            for(int i = 1; i < mas.Length; i++)
                if(min > mas[i])
                {
                    min = mas[i];
                    index = i;
                }

            Console.WriteLine($"Оптимальний варiант {index+1} за критерiєм мiнiмальної дисперсiї");

            Console.WriteLine();
            double[] B = new double[4] { b_Rye, b_Oat, b_Wheat, b_Buckwheat };
            double[] minCoefVariation = new double[4];
            for (int i = 0; i < minCoefVariation.Length; i++)
            {
                minCoefVariation[i] = mas[i] / B[i];
                Console.WriteLine(minCoefVariation[i]);
            }

            index = 0;
            min = minCoefVariation[0];

            for(int i = 1; i < minCoefVariation.Length; i++)
                if(min > minCoefVariation[i])
                {
                    min = minCoefVariation[i];
                    index = i;
                }

            Console.WriteLine($"Оптимальний варiант {index + 1} за критерiєм мiнiмального коефiцiєнта варiацiї");
        }

        static void Main(string[] args)
        {
            new Program().MinimumVariance();

            Console.ReadKey();
        }
    }
}
