using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    class Program
    {
        static void Main(string[] args)
        {
            //("Предупреждения! Иногда игра может бесконечно продолжаться! ");            
            const int  countKart = 36;
            Game game = new Game();
            game.Reshuffle(); // peretasovka
            for(int i=0;i<countKart;i++)
                Console.WriteLine(game.ArrayKarta[i].Type+" "+game.ArrayKarta[i].Mast);
            Console.WriteLine("введите количество игроков: ");
            bool bol = false;
            int countPlayer = 0;
            while (!bol)
            {
                bol = Game.IsNumber(Console.ReadLine(),ref countPlayer);
                if (countPlayer < 2) bol = false;
            }
            bol = false;

            Player[] arrayPlayer = new Player[countPlayer];
            for(int i = 0; i < countPlayer; i++)
            {
                arrayPlayer[i] = new Player();
                arrayPlayer[i].Queue = new Queue<Karta>();
                arrayPlayer[i].Index = i;
                arrayPlayer[i].Number = i;
            }            
            for(int i = 0,j=0; i < countKart; i++,j++) //razdacha kart
            {
                arrayPlayer[j].Queue.Enqueue(new Karta( game.ArrayKarta[i]));             
                if (j == countPlayer - 1) j = -1;
            }
            //start test

            for(int i = 0; i < countPlayer; i++)
            {
                Console.WriteLine(" у игрока №"+arrayPlayer[i].Number+"  "+arrayPlayer[i].Queue.Count+" карт");             
            }
            Console.WriteLine("НАЖМИТЕ ЧЕНИТЬ");
            Console.ReadKey();
            //end test
            int countPlayerInGame = countPlayer;
           
            while (true)
            {
                Karta[] karta = new Karta[countPlayerInGame];// создаю стол карт
                for(int i = 0; i < countPlayerInGame; i++)
                {
                    karta[i] = new Karta();                    
                }

                for(int i = 0,w=0; i < countPlayer; i++)// игроки по очереди типа по часовой стрелочки
                {                                        // кладут карты                
                    for(int j = 0; j < countPlayerInGame; j++)
                    {
                        if (arrayPlayer[j].Index == i)
                        {
                            Console.Write(" №"+arrayPlayer[j].Number+" = ");
                            karta[w] = arrayPlayer[j].Queue.Dequeue();                            
                            Console.Write(karta[w].Type + " " + karta[w].Mast+" ,    ");
                            w++;
                        }
                    }
                }
                // убираем из очереди первого игрока и заносим его в конец очереди
                for (int i = 0; i < countPlayerInGame; i++)
                {
                    if (arrayPlayer[i].Index == 0) {
                        arrayPlayer[i].Index = countPlayerInGame - 1;
                        continue;
                    }
                    arrayPlayer[i].Index--;
                }

                Karta winKarta = karta[0];
                for(int i = 0; i < countPlayerInGame; i++)
                {
                    if (winKarta.Type <karta[i].Type) winKarta = karta[i];
                }
                int indexPlayerWin=0;
                for(int i = 0; i < countPlayerInGame; i++)
                {
                    if (winKarta.Type == karta[i].Type) {
                        indexPlayerWin = i;
                        break;
                    }
                }
                Console.WriteLine("игрок с номером "+arrayPlayer[indexPlayerWin].Number+" поднял все карты ");
                for (int i = 0; i < countPlayerInGame; i++)
                    arrayPlayer[indexPlayerWin].Queue.Enqueue(karta[i]);

                //Console.WriteLine("  игрок под номером : "+indexPlayerWin+"  поднял все карты ");

                int countKartNull = 0;
                for(int i = 0; i < countPlayerInGame; i++)
                {
                    if (!arrayPlayer[i].Queue.Any() )
                    {
                        Console.WriteLine("игрок под номером "+arrayPlayer[i].Number+"  ПОКИНУЛ ИГРУ");
                        countKartNull++;
                    }
                }
                if (countKartNull > 0)
                {                         
                    countPlayerInGame -= countKartNull;
                    Player[] arrayPlayerBufArray = new Player[countPlayerInGame];                   
                    for(int i = 0,j=0; i < countPlayerInGame + countKartNull; i++)
                    {
                        if (arrayPlayer[i].Queue.Any()  )
                        {
                            // arrayPlayerBufArray[j] = arrayPlayer[i];
                            arrayPlayerBufArray[j] = new Player(arrayPlayer[i]);
                            j++;
                        }
                    }
                    arrayPlayer = arrayPlayerBufArray;
                }

                if (countPlayerInGame<2) {
                    Console.WriteLine("игра закончилась");
                    Console.WriteLine("Победитель игрок № : "+arrayPlayer[0].Number);
                    Console.ReadKey();
                    break;
                }  
            }            

        }
    }
}
