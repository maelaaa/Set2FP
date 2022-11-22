using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set2FP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Se da o secventa de n numere. Sa se determine cate din ele sunt pare");
            Console.WriteLine("2. Se da o secventa de n numere. Sa se determina cate sunt negative, cate sunt zero si cate sunt pozitive");
            Console.WriteLine("3. Calculati suma si produsul numerelor de la 1 la n");
            Console.WriteLine("4. Determinati pe ce pozitie se afla in secventa un numara a. Elementele sunt indexate de la 0");
            Console.WriteLine("5. Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa. Se considera ca primul element din secventa este pe pozitia 0.");
            Console.WriteLine("6. Se da o secventa de n numere. Sa se determine daca numerele din secventa sunt in ordine crescatoare");
            Console.WriteLine("7. Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa");
            Console.WriteLine("8. Determianti al n-lea numar din sirul lui Fibonacci.");
            Console.WriteLine("9. Sa se determine daca o secventa de n numere este monotona. ");
            Console.WriteLine("10. Se da o secventa de n numere. Care este numarul maxim de numere consecutive egale din secventa. ");
            Console.WriteLine("11. Se da o secventa de n numere. Se cere sa se caculeze suma inverselor acestor numere. ");
            Console.WriteLine("12. Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere. ");
            Console.WriteLine("13. Determina daca o secventa este \"crescatoare rotita\"");
            Console.WriteLine("14. Determinati daca o secventa de n numere este o secventa monotona rotita.");
            Console.WriteLine("15. Sa se determine daca este o secventa bitonica. ");
            Console.WriteLine("16. Sa se determine daca este o secventa bitonica rotita.");
            Console.WriteLine("17. Determinati daca secventa reprezinta o secventa de paranteze corecta si,daca este, determinati nivelul maxim de incuibare a parantezelor.Obs: 0==( si 1==) ");

            int p = int.Parse(Console.ReadLine());
            switch (p)
            {
                case 1:
                    P1();
                    break;
                case 2:
                    P2();
                    break;
                case 3:
                    P3();
                    break;
                case 4:
                    P4();
                    break;
                case 5:
                    P5();
                    break;
                case 6:
                    P6();
                    break;
                case 7:
                    P7();
                    break;
                case 8:
                    P8();
                    break;
                case 9:
                    P9();
                    break;
                case 10:
                    P10();
                    break;
                case 11:
                    P11();
                    break;
                case 12:
                    P12();
                    break;
                case 13:
                    P13();
                    break;
                case 14:
                    P14();
                    break;
                case 15:
                    P15();
                    break;
                case 16:
                    P16();
                    break;
                case 17:
                    P17();
                    break;
                default: 
                    Console.WriteLine($"Problema cu numarul {p} nu exista"); 
                    break;
            }
            }
        /// <summary>
        /// Se da o secventa de 0 si 1, unde 0 inseamna paranteza deschisa si 1 inseamna paranteza inchisa. 
        /// Determinati daca secventa reprezinta o secventa de paranteze corecta si,
        ///daca este, determinati nivelul maxim de incuibare a parantezelor. 
        ///De exemplu 0 1 0 0 1 0 1 1 este corecta si are nivelul maxim de incuibare 2 pe cand 0 0 1 1 1 0 este incorecta. 
        /// </summary>
        private static void P17()
        {
            Console.WriteLine("Introduceti secventa de paranteze cu valorile aferente: 0 pt ( si 1 pt )");
            var secv = StringToInt();
            int p= 0,nr=0,nrmax=-1;
            bool ok = true;
            for(int i=0; i<secv.Length; i++)
            {
                if (secv[i] == 0)
                {
                    p++;
                    nr++;
                    if (nr > nrmax)
                        nrmax = nr;
                }
                else
                {
                    if (p == 0)
                    {
                        ok = false;
                        break;
                    }
                    p--;
                    nr = 0;
                }
                
            }
            if(p>0)
                ok = false;

            if (ok == true)
            {
                Console.WriteLine("corect");
                Console.WriteLine($"cea mai lunga secventa de incuibare este {nrmax}");
            }
            else
                Console.WriteLine("incorect");
        }

        /// <summary>
        /// O <secventa "bitonica rotita" este o secventa bitonica sau una ca poate fi transformata intr-o secventa bitonica prin rotiri succesive 
        /// (rotire = primul element devine ultimul). Se da o secventa de n numere.
        /// Se cere sa se determine daca este o secventa bitonica rotita. 
        /// </summary>
        private static void P16()
        {
            Console.WriteLine("Introduceti valoarea n si pe cea de a2a linie cele n numere, separate prin spatiu sau virgula");
            int n = Convert.ToInt32(Console.ReadLine());

            var secv = StringToInt();
            bool bitonic = false, ok = false;
            int ultim = secv[secv.Length - 1];
            while (secv[0] != ultim)
            {
                bitonic = false;
                Bitonica(secv,ref bitonic);
                if (bitonic==true)
                {
                    ok = true;
                    break;
                }
                else
                    laStanga(ref secv);

            }
            bitonic = false;
            Bitonica(secv, ref bitonic);

            if (bitonic == true)
                ok = true;

            if (ok == true)
                Console.WriteLine("este secenta bitonica rotita");
            else
                Console.WriteLine("nu este secventa bitonica rotita");
        }
        /// <summary>
        /// O secventa bitonica este o secventa de numere care incepe monoton crescator si continua monoton descrecator. 
        /// Se da o secventa de n numere. Sa se determine daca este bitonica. 
        /// </summary>
        /// <example>De ex. 1,2,2,3,5,4,4,3 este o secventa bitonica. </example>
        private static void P15()
        {
            Console.WriteLine("Introduceti valoarea n si pe cea de a2a linie cele n numere, separate prin spatiu sau virgula");
            int n = Convert.ToInt32(Console.ReadLine());

            var secv = StringToInt();
            bool bitonic = false;
            Bitonica(secv,ref bitonic);
            if (bitonic == true)
                Console.WriteLine("este secventa bitonica");
            else
                Console.WriteLine("nu este secventa bitonica");
        }
        static void Bitonica(int[] v,ref bool este)
        {
            este = false;
            int i = 1;
            bool cresc, descresc;
            cresc = descresc = true;
            while(cresc==true && i<v.Length)
            {
                if (v[i] < v[i - 1])
                    cresc = false;
                i++;
            }
            while(descresc==true && i<v.Length)
            {
                if (v[i] > v[i - 1])
                    descresc = false;
                i++;
            }
            if(cresc==false && descresc==true)
                este=true;
        }
        /// <summary>
        /// O <secventa "monotona rotita" este o secventa de numere monotona sau poate fi transformata 
        /// intr-o secventa montona prin rotiri succesive.
        /// Determinati daca o secventa de n numere este o secventa monotona rotita. 
        /// </summary>
        private static void P14()
        {
            Console.WriteLine("Introduceti valoarea n si pe cea de a2a linie cele n numere, separate prin spatiu sau virgula");
            int n = Convert.ToInt32(Console.ReadLine());

            var secv = StringToInt();
            bool c = false, d = false;
            bool ok = false;
            int ultim = secv[secv.Length - 1];
            while (secv[0] != ultim)
            {
                c = false;
                d = false;
                monoton(secv, ref c, ref d);
                if (c == true || d==true)
                {
                    ok = true;
                    break;
                }
                else
                    laStanga(ref secv);

            }
            c = false; d = false;
            monoton(secv, ref c, ref d);
            if (c == true || d==true)
                ok = true;

            if (ok == true)
                Console.WriteLine("este secenta monotona rotita");
            else
                Console.WriteLine("nu este secventa monotona rotita");

        }
        /// <summary>
        /// O <secventa ,,crescatoare rotita" este o secventa de numere care este
        /// in ordine crescatoare sau poate fi transformata intr-o secventa in 
        /// ordine crescatoare prin rotiri succesive
        /// (rotire cu o pozitie spre stanga = toate elementele se muta cu o pozitie spre stanga
        /// si primul element devine ultimul).
        /// Determinati daca o secventa de n numere este o secventa crescatoare rotita. 
        /// </summary>
        /// <example>DA
        /// 4
        /// 4 10 16 2=>10 16 2 4=>16 2 4 10=>2 4 10 16
        /// </example>
        private static void P13()
        {
            Console.WriteLine("Introduceti valoarea n si pe cea de a2a linie cele n numere, separate prin spatiu sau virgula");
            int n = Convert.ToInt32(Console.ReadLine());

            var secv = StringToInt();
            bool c = false, d = false;
            bool ok = false;
            int ultim = secv[secv.Length-1];
            while (secv[0]!=ultim)
            {
                c = false;
                d=false;
                monoton(secv, ref c,ref d);
                if (c == true)
                {
                    ok = true;
                    break;
                }
                else
                    laStanga(ref secv);

            }
            c = false;
            monoton(secv, ref c, ref d);//trebuie sa se verifice separat pentru cand ultimul element ajunge pe prima pozitie
            if (c == true)
                ok = true;
            
            if (ok == true)
                Console.WriteLine("este secenta crescatoare rotita");
            else
                Console.WriteLine("nu este secventa crescatoare rotita");


        }
        static void monoton(int[] v, ref bool cresc, ref bool descresc)
        {
            cresc = true;
            descresc = true;

            for (int i = 1; i < v.Length; i++)
                if (v[i] < v[i-1])
                    cresc = false;
            for (int i = 1; i < v.Length; i++)
                if (v[i] > v[i-1])
                    descresc = false;
        }

        public static void laStanga(ref int[] v)
        {
            int first = v[0];
            for (int i = 1; i < v.Length; i++)
                v[i - 1] = v[i];
            v[v.Length-1] = first;
        }
        static int[] StringToInt()
        {
            //basic reading

            char[] separators = { ' ', ',' };
            string[] line = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] secv = Array.ConvertAll(line, int.Parse);
            return secv;
        }

        /// <summary>
        /// Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere.
        /// Considerati fiecare astfel de grup ca fiind un cuvant, zero fiind delimitator de cuvinte
        /// </summary>
        /// <example>pentru secventa 1, 2, 0, 3, 4, 5, 0, 0, 6, 7, 0, 0 raspunsul este 3. </example>
        private static void P12()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int nr = 0,nrz=0;

            int ante = int.Parse(Console.ReadLine());

            for (int i = 1; i < n-1; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (x == 0)
                {
                    nrz++;
                    if(ante != 0)
                        nr++;

                }
                ante = x;
            }
            int z = int.Parse(Console.ReadLine());
            if (nrz == 0)
                Console.WriteLine($"o singura secventa");
            else
            {
                if (z != 0 && ante == 0)
                    nr++;
                Console.WriteLine($"{nr} secvente");
            }
        }
        /// <summary>
        /// Se da o secventa de n numere.
        /// Se cere sa se caculeze suma inverselor acestor numere. 
        /// </summary>
        private static void P11()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int sum = 0, inv;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                inv = 0;
                while (x != 0)
                {
                    inv = inv * 10 + x % 10;
                    x /= 10;
                }
                sum += inv;
            }
            Console.WriteLine(sum);
        }
        /// <summary>
        /// Se da o secventa de n numere. 
        /// Care este numarul maxim de numere consecutive egale din secventa. 
        /// </summary>
        private static void P10()
        {
            int nr = 1, nrmax = -1;
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());

            int ante = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if(x == ante)
                {
                    nr++;
                }
                else
                {
                    if(nr>nrmax)
                    {
                        nrmax = nr;
                    }
                    nr = 1;
                }
                ante = x;
            }
            if (nr > nrmax)
            {
                nrmax = nr;
            }
            Console.WriteLine($"lungimea maxima a secventei de nr egale este {nrmax}");
        }
        /// <summary>
        /// Sa se determine daca o secventa de n numere este monotona. 
        /// Secventa monotona = secventa monoton crescatoare sau monoton descrescatoare. 
        /// </summary>
        private static void P9()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            bool cresc = true, desc=true;
            int ante = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (ante > x)//nu e ordonat crescator
                {
                    cresc = false;
                }
                if(ante<x)//nu e ordonat descrescator
                {
                    desc = false;
                }
                ante = x;
            }
            if (cresc == true || desc==true)
                Console.WriteLine("secventa monotona");
            else 
                Console.WriteLine("secventa nu este monotona");
        }
        /// <summary>
        /// Determianti al n-lea numar din sirul lui Fibonacci.
        /// Sirul lui Fibonacci se construieste astfel: f1 = 0, f2 = 1, f_n = f_(n-1) + f(n-2). Exemplu: 0, 1, 1, 2, 3, 5, 8
        /// </summary>
        private static void P8()
        {
            Console.WriteLine("Introduceti rangul termenului");
            int n=int.Parse(Console.ReadLine());
            int ante = 0, prec = 1, tc=0, nr=2;
            if (n == 1)
                Console.WriteLine("0");
            else
                if (n == 2)
                     Console.WriteLine("1");
                else
                {
                    while (n != nr)
                    {
                        tc = ante + prec;
                        ante = prec;
                        prec = tc;
                        nr++;
                    }
                    Console.WriteLine($"al {n} termen este {tc}");
                }


        }
        /// <summary>
        /// Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa. 
        /// </summary>
        private static void P7()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int maxim=int.MinValue, minim=int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int x=int.Parse(Console.ReadLine());
                if (x < minim)
                    minim = x;
                if (x > maxim)
                    maxim = x;
            }
            Console.WriteLine($"valoarea maxima este: {maxim}");
            Console.WriteLine($"valoarea minima este: {minim}");
        }
        /// <summary>
        /// Se da o secventa de n numere. 
        /// Sa se determine daca numerele din secventa sunt in ordine crescatoare. 
        /// </summary>
        private static void P6()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            bool cresc = true;
            int x = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int y = int.Parse(Console.ReadLine());
                if(x>y)//nu e ordonat crescator
                {
                    cresc=false;
                    break;
                }
                x = y;
            }
            if (cresc == true)
                Console.WriteLine("nr sunt ordonate crescator");
            else
                Console.WriteLine("nr nu sunt ordonate crescator");
        }
        /// <summary>
        /// Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa.
        /// Se considera ca primul element din secventa este pe pozitia 0. 
        /// </summary>
        private static void P5()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int nr = 0;
            for (int i = 0; i < n; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (k==i)
                    nr++;
            }
            Console.WriteLine($"{nr} numere egale cu pozitia lor");
        }
        /// <summary>
        /// Se da o secventa de n numere. Determinati pe ce pozitie se afla in secventa un numara a
        /// Elementele sunt indexate de la 0
        /// Daca numarul nu se afla in secventa raspunsul va fi -1. 
        /// </summary>
        private static void P4()
        {
            Console.WriteLine("Introduceti n si valoarea cautata k, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("introduceti cele n numere, fiecare pe cate un rand nou");
            int p = -1;
            for (int i = 0; i < n; i++)
            {
                int x=int.Parse(Console.ReadLine());
                if (x == k)
                    p = i;
            }
            Console.WriteLine($"numarul {k} se afla pe pozitia {p}");
        }
        /// <summary>
        /// determina suma si produsul nr de la 1, n
        /// </summary>
        private static void P3()
        {
            Console.WriteLine("Introduceti n");
            long n = long.Parse(Console.ReadLine());
            bool oversuma, overprod;
            oversuma = overprod = false;
            long p = 1, s = 0; ;
            for (int i = 1; i <= n; i++)
            {
                checked
                {
                    try
                    {
                        p *= i;

                    }
                    catch (OverflowException)
                    {
                        overprod = true;
                    }
                    
                    try
                    {
                        s += i;
                    }
                    catch (OverflowException)
                    {
                        oversuma = true;
                    }


                }
            }
            if (oversuma == false)
                Console.WriteLine($"Suma este: {s}");
            else
                Console.WriteLine($"suma: overflow");
            if (overprod == false)
                Console.WriteLine($"produsul este: {p}");
            else
                Console.WriteLine($"produs: overflow");
        }
        /// <summary>
        /// determina cate zerouri, cate nr pozitive si nr cate negative sunt in secventa
        /// </summary>
        private static void P2()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int nrz=0, nrn=0, nrp = 0;
            for (int i = 0; i < n; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (k == 0)
                    nrz++;
                else
                    if (k < 0)
                        nrn++;
                    else
                        nrp++;
            }
            Console.WriteLine($"zerouri: {nrz}");
            Console.WriteLine($"numere pozitive: {nrp}");
            Console.WriteLine($"numere negative: {nrn}");
        }

        /// <summary>
        /// afiseaza cate elemente pare sunt in secventa
        /// </summary>
        private static void P1()
        {
            Console.WriteLine("Introduceti n si cele n nr din secventa, fiecare pe cate un rand nou");
            int n = int.Parse(Console.ReadLine());
            int nr = 0;
            for(int i = 0; i < n; i++)
            {
                int k=int.Parse(Console.ReadLine());
                if (k % 2 == 0)
                    nr++;
            }
            Console.WriteLine($"{nr} numere pare");

        }
    }
}
