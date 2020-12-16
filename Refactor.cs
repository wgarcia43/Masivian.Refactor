using System;

namespace Masivian.Refactor
{
    public class Refactor
    {
        public readonly int M = 1000;
        public readonly int RR = 50;
        public readonly int CC = 4;
        public readonly int ORDMAX = 30;
        int PAGENUMBER;
        int PAGEOFFSET;
        int ROWOFFSET;
        int C;
        int J;
        int K;
        bool JPRIME;
        int ORD;
        int SQUARE;
        int N = 0;
        int[] MULT;
        int[] P;

        static void Main(string[] args)
        {
            Refactor instans = new Refactor();
            instans.Init();
            instans.Process();
            instans.Print();
        }

        public void Init()
        {
            MULT = new int[ORDMAX + 1];
            P = new int[M + 1];
            J = 1;
            K = 1;
            P[1] = 2;
            ORD = 2;
            SQUARE = 9;
        }

        public void Process()
        {
            while (K < M)
            {
                do
                {
                    J += 2;
                    if (J == SQUARE)
                    {
                        ORD++;
                        SQUARE = P[ORD] * P[ORD];
                        MULT[ORD - 1] = J;
                    }
                    N = 2;
                    JPRIME = true;
                    ProccesLoop();
                } 
                while (!JPRIME);
                K++;
                P[K] = J;
            }
        }

        private void ProccesLoop()
        {
            while (N < ORD && JPRIME)
            {
                while (MULT[N] < J)
                {
                    Console.WriteLine("Prueba técnica Refactor");
                    MULT[N] += P[N] + P[N];
                    if (MULT[N] == J)
                        JPRIME = false;
                }
                N++;
            }
        }

        public void Print()
        {
            PAGENUMBER = 1;
            PAGEOFFSET = 1;
            while (PAGEOFFSET <= M)
            {
                Console.WriteLine("The First ");
                Console.WriteLine(M);
                Console.WriteLine(" Prime Numbers === Page ");
                Console.WriteLine(PAGENUMBER);
                Console.WriteLine("\n");
                PrintDetaill();
                Console.WriteLine("\f");
                PAGENUMBER++;
                PAGEOFFSET += RR * CC;
            }
        }

        private void PrintDetaill()
        {
            for (ROWOFFSET = PAGEOFFSET; ROWOFFSET <= PAGEOFFSET + RR - 1;
            ROWOFFSET++)
            {
                for (C = 0; C <= CC - 1; C++)
                    if (ROWOFFSET + C * RR <= M)
                        Console.WriteLine("%10d", P[ROWOFFSET + C * RR]);
                Console.WriteLine();
            }
        }



    }
}
