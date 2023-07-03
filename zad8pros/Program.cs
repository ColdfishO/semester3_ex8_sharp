using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad7pros
{
    class Program
    {

        public delegate void ostrzezenie(string tekst);
        public interface serwis
        {
            public int sprawdz(int kola);
            
        }
        public abstract class pojazd : serwis
        {
            private int ilekol;
            private string naped;
            private int czaskol;
            public int Ilekol
            {
                get
                {
                    return ilekol;
                }
                set
                {
                    ilekol = value;
                }
            }
            public string Naped
            {
                get
                {
                    return naped;
                }
                set
                {
                    naped = value;
                }
            }
            public int Czaskol
            {
                get
                {
                    return czaskol;
                }
                set
                {
                    czaskol = value;
                }
            }
            public event ostrzezenie wypadek;
            public void uwaga()
            {
                wypadek("Wypadek na trasie! ");
            }
            public void ruch(string t)
            {
                Console.WriteLine(t + "Zatrzymuję się");
            }
            public abstract void poruszanie();
            public int sprawdz(int kola)
            {
                Console.WriteLine("Przeprowadzam przegląd");
                if (kola > 3)
                {
                    Console.WriteLine("Koła do wymiany");
                    kola = 0;
                    Console.WriteLine("Koła wymienione");
                    return kola;
                }
                else
                {
                    Console.WriteLine("Koła w dobrym stanie");
                    return kola;
                }
            }
}
        public class traktor : pojazd
        {
            public traktor()
            {
                Ilekol = 4;
                Naped = "spalinowy";
                Czaskol = 5;
            }
            public override void poruszanie()
            {
                Console.WriteLine("Przeciążenie metody abstrakcyjnej. Pojazd jedzie naprzód");
            }


        }
        public class skuter : pojazd
        {
            public skuter()
            {
                Ilekol = 2;
                Naped = "elektryczny";
                Czaskol = 2;
            }
            public override void poruszanie()
            {
                Console.WriteLine("Przeciążenie metody abstrakcyjnej. Pojazd jedzie naprzód");
            }

        }
        static void Main(string[] args)
        {
            traktor ursus = new traktor();
            skuter skuterek = new skuter();
            ursus.poruszanie();
            skuterek.poruszanie();
            Console.WriteLine("\nWiek opon traktora: "+ursus.Czaskol);
            ursus.Czaskol=ursus.sprawdz(ursus.Czaskol);
            Console.WriteLine("Wiek opon traktora: " + ursus.Czaskol+"\n");
            Console.WriteLine("Wiek opon skutera: " + skuterek.Czaskol);
            skuterek.Czaskol = skuterek.sprawdz(skuterek.Czaskol);
            Console.WriteLine("Wiek opon skutera: " + skuterek.Czaskol +"\n");
            Console.ReadKey();
        }
    }
}