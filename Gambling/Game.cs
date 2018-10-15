using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    public class Game
    {
        public Karta[] ArrayKarta { get; set; }
        public Game()
        {
            int size = 36;            
            ArrayKarta = new Karta[size];
            string mast = "A";            
            for(int i = 0,type=6; i < size; i++)
            {
                ArrayKarta[i] = new Karta();
                ArrayKarta[i].Mast = mast;
                ArrayKarta[i].Type = type;
                if (mast.CompareTo("A") == 0) mast = "B";
                else if (mast.CompareTo("B") == 0) mast = "C";
                else if (mast.CompareTo("C") == 0) mast = "D";
                else if (mast.CompareTo("D") == 0) { mast = "A";type++; }
            }
        }
        public void Reshuffle()
        {            
            int min = 0, max = 35;           
            int r1,r2;          
            for (int i = 0; i < 1000; i++)
            {
                Random rand = new Random();
                r1 =rand.Next(min,max);
                r2 = rand.Next(min, max);
               // Console.WriteLine("  ПЕРЕТАСОВКА : " + r1 + " , " + r2);
                Karta karta = null;              
                karta = ArrayKarta[r1];
                ArrayKarta[r1] = ArrayKarta[r2];
                ArrayKarta[r2] = karta;
            }
            Console.Clear();
        }
        public static bool IsNumber(string numberAsString, ref int number)
        {
            try
            {
                number = int.Parse(numberAsString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
