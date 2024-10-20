// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/mnozenje_i_korenovanje
// https://petlja.org/sr-Latn-RS/kurs/14606/23/2756
// https://github.com/draganilicnis/R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Koren/blob/main/R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Koren.cs
// https://onlinegdb.com/dwCUJylrGO

using System;

class R1_T05_05_Deljivost_Prost_TLE_NZD_Mno_Koren
{
    static long NZD_235(long n)
    {
        long m = 1;                     // Rezultat: Inicijalna vrednost: 1
        long d = 2;                     // Prvi delilac: 2
        while (d * d <= n)              // Uslov za kraj petlje je kada je delilac > Sqrt(n)
        {
            long k = 0;                 // Prebrojavanje koliko puta je broj n deljiv sa deliocem d
            while (n % d == 0)          // Sve dok je broj n deljiv sa d
            {
                n = n / d;              // Vrednost broja n smanjujemo, odnosno delimo deliocem d
                if (k <= 0) m = m * d;  // Ako je prvi put delimo tim deliocem
                k++;                    // Evidentiramo broj deljenja deliocem d
                // Console.Write(d + " ");
            }
            // if (k % 2 != 0) m = m * d;  // Ako je broj delioca d paran onda mnozimo Dopunu do punog kvadrata tim deliocem
            d++;                        // Uzimamo sledeci delilac
        }
        if (n > 1) m = m * n;           // Ako je ostao poslednji najveci delilac (jedan, poslednji, svakako neparan)
        return m;
    }

    static void Main()
    {
        long N = long.Parse(Console.ReadLine());    // N = 540 = 2 * 2 * 3 * 3 * 3 * 5 = (2 * 2) * (3 * 3) * 3 * 5 = (2*3)*(2*3) * 3*5 = 6*6 * 3*5
        long P = NZD_235(N);                        // P = 30  = 2 * 3 * 5
        Console.WriteLine(P);
    }
}
