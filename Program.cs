using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Petrik_elmenyfurdo
{
    internal class Program
    {
        static void MenuKiir()
        {
            Console.WriteLine("=== PETRIK ELMÉNYFÜRDŐ ===");
            Console.WriteLine();

            Console.WriteLine("1.) Belépőjegy vásárlása");
            Console.WriteLine("2.) Csúszdapark ellenőrzés");
            Console.WriteLine("3.) Éttermi kedvezmény kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés Választás");

            Console.WriteLine();

            Console.Write("Választás:");
        }

        static string JegyTipus(int eletkor)
        {
            if (eletkor < 6)
            {
                return "Baba jegy";
            }
            else if (eletkor < 14)
            {
                return "Gyerekjegy";
            }
            else if (eletkor < 18)
            {
                return "Diákjegy";
            }
            else if (eletkor < 65)
            {
                return "Felnőtt jegy";
            }
            else
            {
                return "Nyugdíjas jegy";
            }
        }
        static int JegyAr(int eletkor)
        {
            if (eletkor < 6)
            {
                return 0;
            }
            else if (eletkor < 14)
            {
                return 1800;
            }
            else if (eletkor < 18)
            {
                return 2400;
            }
            else if (eletkor < 65)
            {
                return 3900;
            }
            else
            {
                return 2000;
            }
        }

        static void CsuszdaparkEllenorzes()
        {
            Console.Clear();

            Console.WriteLine("=== CSÚSZDAPARK ===");
            Console.WriteLine();

            Console.WriteLine("1.) Mini Csúszda");
            Console.WriteLine("2.) Kamikaze");
            Console.WriteLine("3.) Black Hole");
            Console.WriteLine("");

            Console.Write("Melyik csúszdát választod? ");

            int csuszda = Convert.ToInt32(Console.ReadLine());

            Console.Write("Milyen magas vagy? ");
            int magas = Convert.ToInt32(Console.ReadLine());

            switch (csuszda)
            {
                case 1:
                    if (magas >= 100)
                    {
                        Console.WriteLine("Használhatod a Mini csúszdát!");
                    }
                    else
                    {
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    }
                    break;

                case 2:
                    if (magas >= 140)
                    {
                        Console.WriteLine("Használhatod a Kamikaze csúszdát!");
                    }
                    else
                    {
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    }
                    break;

                case 3:
                    if (magas >= 120)
                    {
                        Console.WriteLine("Használhatod a Black Hole csúszdát!");
                    }
                    else
                    {
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    }
                    break;

                default:
                    Console.WriteLine("Nincs ilyen csúszda!");
                    break;
            }
        }
        static int KedvezmenyesAr(int osszeg, int kedvezmeny)
        {
            switch (kedvezmeny)
            {
                case 1:
                    return osszeg;
                case 2:
                    return osszeg - (osszeg * 15 / 100);
                case 3:
                    return osszeg - (osszeg * 20 / 100);
                default:
                    return osszeg;
            }
        }


        static void EttermiKalkulator()
        {
            Console.Clear();
            Console.WriteLine("=== ÉTTERMI KEDVEZMÉNY ===");

            Console.WriteLine("1.) Nincs kedvezmény");
            Console.WriteLine("2.) Diákkedvezmény - 15%");
            Console.WriteLine("3.) Családi kedvezmény - 20%");

            Console.WriteLine();

            Console.Write("Eredeti összeg: ");
            int osszeg = Convert.ToInt32(Console.ReadLine());

            Console.Write("Kedvezmény típusa: ");
            int kedvezmeny = Convert.ToInt32(Console.ReadLine());

            if (osszeg == 1 || osszeg == 2 || osszeg == 3)
            {
                int fizetendo = KedvezmenyesAr(osszeg, kedvezmeny);

                Console.WriteLine($"Fizetendő: {fizetendo} Ft");
            }
            else
            {
                Console.WriteLine("Nincs ilyen kedvezmény!");
            }
        }
        static void Main(string[] args)
        {
            int bevetel = 0;
            int valasztas = 0;

            do
            {
                Console.Clear();

                MenuKiir();

                try
                {
                    valasztas = Convert.ToInt32(Console.ReadLine());

                    switch (valasztas)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("===Jegy vásárlás===");
                            Console.WriteLine();

                            Console.Write("Név: ");
                            string nev = Console.ReadLine();

                            Console.Write("Életkor: ");
                            int eletkor = Convert.ToInt32(Console.ReadLine());

                            if (eletkor < 0 || eletkor > 120)
                            {
                                Console.WriteLine("Hibás életkor!");
                            }
                            else
                            {
                                string jegyTipus = JegyTipus(eletkor);
                                int osszeg = JegyAr(eletkor);

                                Console.WriteLine();

                                Console.WriteLine($"Jegytípus: {jegyTipus}");

                                Console.WriteLine($"Fizetendő: {osszeg} Ft");

                                bevetel += osszeg;
                            }
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            CsuszdaparkEllenorzes();
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            EttermiKalkulator();
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("===Bevétel===");
                            Console.WriteLine();
                            Console.WriteLine($"A fürdő mai bevétele: {bevetel} Ft");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Viszlát!");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Válassz az 1-5 lehetőség közül!");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Hiba! Számot kell megadni!");
                    Console.ReadLine();
                }
            } while (valasztas != 5);
        }

    }
}



