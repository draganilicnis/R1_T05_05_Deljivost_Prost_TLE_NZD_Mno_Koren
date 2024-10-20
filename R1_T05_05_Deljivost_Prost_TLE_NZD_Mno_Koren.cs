// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/mnozenje_i_korenovanje
// https://petlja.org/sr-Latn-RS/kurs/14606/23/2756
// https://github.com/draganilicnis/R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Koren/blob/main/R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Koren.cs

using System;
using System.Collections.Generic;
using System.Linq;

class R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Kor
{
    //static void Razmeni(ref long a, ref long b)
    //{
    //    long p = a; a = b; b = p;
    //}
    //static long NZD(long a, long b)
    //{
    //    if (a < b) Razmeni(ref a, ref b);
    //    while (b > 0)
    //    {
    //        a = a % b;
    //        Razmeni(ref a, ref b);
    //    }
    //    return a;
    //}
    //static long Dopuna_do_punog_kvadrata(long n)
    //{
    //    long m = 1;                     // Rezultat: Inicijalna vrednost: 1
    //    long d = 2;                     // Prvi delilac: 2
    //    while (d * d <= n)              // Uslov za kraj petlje je kada je delilac > Sqrt(n)
    //    {
    //        long k = 0;                  // Prebrojavanje koliko puta je broj n deljiv sa deliocem d
    //        while (n % d == 0)          // Sve dok je broj n deljiv sa d
    //        {
    //            n = n / d;              // Vrednost broja n smanjujemo, odnosno delimo deliocem d
    //            k++;                    // Evidentiramo broj deljenja deliocem d
    //            // Console.Write(d + " ");
    //        }
    //        if (k % 2 != 0) m = m * d;  // Ako je broj delioca d paran onda mnozimo Dopunu do punog kvadrata tim deliocem
    //        d++;                        // Uzimamo sledeci delilac
    //    }
    //    if (n > 1) m = m * n;           // Ako je ostao poslednji najveci delilac (jedan, poslednji, svakako neparan)
    //    return m;
    //}


    //static void Obradi()
    //{
    //    long N = long.Parse(Console.ReadLine());    // N = 540 = 2 * 2 * 3 * 3 * 3 * 5 = (2 * 2) * (3 * 3) * 3 * 5 = (2*3)*(2*3) * 3*5 = 6*6 * 3*5
    //    long P = Dopuna_do_punog_kvadrata(N);       // P = 15 = 3*5
    //    // Console.WriteLine();
    //    // Console.WriteLine(P);
    //    long z = N / P;                             // z = 36 = 540 / 15 = (2*3)*(2*3) = 6*6
    //    // Console.WriteLine(z);
    //    long z_koren = (long)Math.Sqrt(z);          // z_koren = 6 = Sqrt(2*3*2*3) = Sqrt(6*6) = 2*3
    //    // Console.WriteLine(z_koren);
    //    long nzd = NZD(P, z_koren);                 // nzd = 3 = NZD(15, 6) = NZD (3*5, 2*3)
    //    // Console.WriteLine(nzd);
    //    long nzd_desno = P / nzd;                   // nzd_desno = 5 = 15 / 3 = 15 / NZD (15, 6) =  (3*5) / NZD (3*5, 2*3)
    //    // Console.WriteLine(nzd_desno);
    //    long nzd_min = z_koren * nzd_desno;         // nzd_min = 30 = 6 * 5 = (2*3) * NZD(3*5, 2*3)
    //    // Console.WriteLine(nzd_min);
    //    if (nzd_min * nzd_min < N) nzd_min = nzd_min * nzd; // Ako je rezultat manji od korena od N ( < Sqrt(N) )
    //    Console.WriteLine(nzd_min);
    //}

    //static void Main()
    //{
    //    // Console.WriteLine(NZD(15, 6));
    //    Obradi();
    //}

    static List<long> Factorize(long n)
    {
        List<long> factors = new List<long>();
        for (long i = 2; i <= Math.Sqrt(n); i++)
        {
            while (n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
        }
        if (n > 1) factors.Add(n);
        return factors;
    }

    static bool IsPerfectSquare(long num)
    {
        long root = (long)Math.Sqrt(num);
        return root * root == num;
    }

    static long SmallestNumber(long n)
    {
        List<long> factors = Factorize(n);
        var factorCounts = factors.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        long multiplyFactor = 1;
        foreach (var kvp in factorCounts)
        {
            if (kvp.Value % 2 != 0)
            {
                multiplyFactor *= kvp.Key;
            }
        }

        long result = n * multiplyFactor;

        while (IsPerfectSquare(result))
        {
            result = (int)Math.Sqrt(result);
        }

        return result;
    }

    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(SmallestNumber(n));
    }
}
