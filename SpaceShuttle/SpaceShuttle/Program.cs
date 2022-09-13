using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceShuttle
{
    internal class Program
    {
        public class urhajo
        {
            public string kuldetes;
            public DateTime kilovesdatum;
            public string ursikloneve;
            public int napokszama;
            public int orakszama;
            public string landolashelye;
            public int legenyseg;

            public urhajo(string adat) 
            {
                string[] kesz = adat.Split(';');
                this.kuldetes = kesz[0];
                this.kilovesdatum = DateTime.Parse(kesz[1]);
                this.ursikloneve = kesz[2];
                this.napokszama = int.Parse(kesz[3]);
                this.orakszama = int.Parse(kesz[4]);
                this.landolashelye = kesz[5];
                this.legenyseg=int.Parse(kesz[6]);
            }
        }
        public static List<urhajo> urhajolista = new List<urhajo>();
        static void Main(string[] args)
        {
            feladat2();
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            feladat8();
            feladat9();
            Console.ReadKey();
        }

        private static void feladat9()
        {
            int landolasokk = 0;
            for (int i = 0; i < urhajolista.Count; i++)
            {
                if (urhajolista[i].landolashelye== "Kennedy")
                {
                    landolasokk++;
                }
            }
            double eredmeny = urhajolista.Count/ landolasokk;
            Console.WriteLine($"9.Feldat:\n\tA küldetések {eredmeny}%-a fejeződött be a Kennedy űrközpontban");
        }

        private static void feladat8()
        {
            Console.Write($"8.Feldat:\n\tÉvszám: ");
            int evszam = int.Parse(Console.ReadLine());
            int alkalom = 0;
            for (int i = 0; i < urhajolista.Count; i++)
            {
                if (urhajolista[i].kilovesdatum.Year==evszam)
                {
                    alkalom++;
                }
            }
            if (alkalom!=0)
            {
                Console.WriteLine($"\tEbben az évben {alkalom} küldetés volt.");
            }
            else
            {
                Console.WriteLine("Ebben  az évben nem indult küldetés");
            }
        }

        private static void feladat7()
        {
            int idooraban = (urhajolista[0].napokszama * 24) +urhajolista[0].orakszama;
            int index = 0;
            for (int i = 1; i < urhajolista.Count; i++)
            {
                int temp = (urhajolista[i].napokszama * 24) + urhajolista[i].orakszama;
                if (idooraban < temp)
                {
                    idooraban = temp;
                    index = i;
                }
            }
            Console.WriteLine($"7. Feldat:\n\tA leghosszabb ideig a {urhajolista[index].ursikloneve} volt az űrben a {urhajolista[index].kuldetes} küldetés során.\n\tÖsszesen {idooraban} órát volt távol a Földtől");
        }

        private static void feladat6()
        {
            int utolsocol = 0; ;
            for (int i = 0; i < urhajolista.Count; i++)
            {
                if (urhajolista[i].ursikloneve== "Columbia")
                {
                    utolsocol = urhajolista[i].legenyseg;
                }
            }
            Console.WriteLine($"6. Feldat:\n\t{utolsocol} asztronauta volt a Columbai fedélzetén annak utlsó útján");
        }

        private static void feladat5()
        {
            int kevesebbot = 0;
            for (int i = 0; i < urhajolista.Count; i++)
            {
                if (urhajolista[i].legenyseg<5)
                {
                    kevesebbot++;
                }
            }
            Console.WriteLine($"5. Feldat:\n\tÖsszesen {kevesebbot} alakalommal küldtek kevesebb, mint 5 embert az űrbe.");
        }

        private static void feladat4()
        {
            int osszutas = 0;
            for (int i = 0; i < urhajolista.Count; i++)
            {
                osszutas += urhajolista[i].legenyseg;
            }
            Console.WriteLine($"4. Feldat:\n\t{osszutas} indult az űrbe összesen");
        }

        private static void feladat3()
        {
            Console.WriteLine($"3. Feldat:\n\tÖsszesen {urhajolista.Count} alkalommal indítottak űrhajót.");
        }

        public static void feladat2() 
        {
            StreamReader sr = new StreamReader("kuldetesek.csv");
            int i = 0;
            while (!sr.EndOfStream)
            {
                urhajolista.Add(new urhajo(sr.ReadLine()));
                i++;
            }
        }
    }
}
