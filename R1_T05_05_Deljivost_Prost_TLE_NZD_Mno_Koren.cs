// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/mnozenje_i_korenovanje
// https://petlja.org/sr-Latn-RS/kurs/14606/23/2756

using System;

class R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Kor
{
    static long Dopuna_do_punog_kvadrata(long n)
    {
        long m = 1;
        long d = 2;
        while (d * d <= n)
        {
            int k = 0;
            while (n % d == 0)
            {
                n = n / d;
                k++;
                // Console.Write(d + " ");
            }
            if (k % 2 != 0) m = m * d;
            d++;
        }
        if (n > 1) m = m * n;
        return m;
    }

    static void Razmeni(ref long a, ref long b)
    {
        long p = a; a = b; b = p;
    }
    static long NZD(long a, long b)
    {
        if (a < b) Razmeni(ref a, ref b);
        while (b > 0)
        {
            a = a % b;
            Razmeni(ref a, ref b);
        }
        return a;
    }

    static void Obrada()
    {
        long n = long.Parse(Console.ReadLine());    // n = 540 = 2 * 2 * 3 * 3 * 3 * 5 = (2 * 2) * (3 * 3) * 3 * 5 = (2*3)*(2*3) * 3*5 = 6*6 * 3*5
        long m = Dopuna_do_punog_kvadrata(n);       // m = 15 = 3*5
        // Console.WriteLine();
        // Console.WriteLine(m);
        long d = n / m;                             // d = 36 = 540 / 15 = (2*3)*(2*3) = 6*6
        // Console.WriteLine(d);
        long nzd_start_koren = (long)Math.Sqrt(d);  // nzd_start_koren = 6 = Sqrt(2*3*2*3) = Sqrt(6*6) = 2*3
        // Console.WriteLine(nzd_start_koren);
        long nzd = NZD(m, nzd_start_koren);         // nzd = 3 = NZD(15, 6) = NZD (3*5, 2*3)
        // Console.WriteLine(nzd);
        long nzd_desno = m / nzd;                   // nzd_desno = 5 = 15 / 3 = 15 / NZD (15, 6) =  (3*5) / NZD (3*5, 2*3)
        // Console.WriteLine(nzd_desno);
        long manji = nzd_start_koren;               // manji = 6 = Sqrt(2*3*2*3) = Sqrt(6*6) = 2*3
        // if (manji > m) manji = m;
        long nzd_min = manji * nzd_desno;           // nzd_min = 30 = 6 * 5 = (2*3) * NZD(3*5, 2*3)
        Console.WriteLine(nzd_min);
    }

    static void Main()
    {
        // Console.WriteLine(NZD(15, 6));
        Obrada();
    }
}
