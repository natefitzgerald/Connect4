using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Game
{
    public class RandomBot : IPlayer
    {
        public string GetName()
        {
            return "sfdalkjasdfl;kjfadsjklfsadjlk;sdafljk;asdflj;kafdsljk;asfdlkj;asdfjkl;sadfkj;lfasdjlk;asdfjk;lfadsjlk;safdkj;lasdfjklsadf";
        }

        private Random random = new Random();
        public int GetMove(Connect4Game game)
        {
            int r = 0;
            do { r = random.Next(7); }while(game.Moves.Count(q => q.Column == r) == 6);
            return r; ;
        }
    }
}
