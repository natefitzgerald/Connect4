using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Game
{
    public class GameRunner
    {
        public static void Main()
        {
            var p1 = new RandomBot();
            var p2 = new RandomBot();


            PlayGame(p1, p2);
        }
        public static int PlayGame(IPlayer player1, IPlayer player2)
        {
            var game = new Connect4Game();
            for(int i = 0; i < 21; i++)
            {
                var m = player1.GetMove(game);
                var move = new Move(m, game.Moves.Where(q => q.Column == m).OrderByDescending(q => q.Row).Select(q => q.Row).Aggregate(-1, (q, w) => q > w ? q : w) + 1, 0);
                game.MakeMove(move);

                if (game.Winner != 0) break;

                m = player2.GetMove(game); ;
                move = new Move(m, game.Moves.Where(q => q.Column == m).OrderByDescending(q => q.Row).Select(q => q.Row).Aggregate(-1, (q, w) => q > w ? q : w) + 1, 0);
                game.MakeMove(move);

                if (game.Winner != 0) break;
            }
            return game.Winner;
        }
    }
    public partial class Connect4Game
    {
        public int Winner
        {
            get => this.Moves.GroupBy(q => q.Player).SingleOrDefault(r => r.GroupBy(w => w.Column).Any(w => w.OrderBy(q => q.Column).Aggregate(0, (line, current) => current.Column != 0 ? line + 1 : line > 3 ? 4 : 0) >= 4 || w.OrderBy(q => q.Row).Aggregate(0, (line, current) => current.Row != 0 ? line + 1 : line > 3 ? 4 : 0) >= 4))?.Key ?? 0;

        }
        public Connect4Game()
        {
            this.Board = new int[7, 6];
            this.Moves = new List<Move>();
        }

        public void MakeMove(Move m)
        {
            this.Moves.Add(m);
            this.Board[m.Column, m.Row] = m.Player;
        }
    }
}
