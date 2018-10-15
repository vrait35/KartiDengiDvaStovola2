using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    public class Player
    {
        public Queue<Karta> Queue { get; set; }
        public int Index { get; set; }
        public int Number { get; set; }
        public Karta GetKarta()
        {
            return Queue.Dequeue();
        }
        public Player(Player player)
        {
            Queue = new Queue<Karta>(player.Queue);
            Index = player.Index;
            Number = player.Number;
        }
        public Player() { }
    }
}
