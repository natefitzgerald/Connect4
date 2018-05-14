using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Game
{
    public partial class Connect4Game
    {
        public int[,] Board;
        public List<Move> Moves;
    }

    public struct Move
    {
        public int Column { get; private set; }
        public int Row { get; private set; }
        public int Player { get; }
        public Move(int column, int row, int player)
        {
            this.Column = column;
            this.Row = row;
            this.Player = player;
        }
    }
    public interface IPlayer
    {
        int GetMove(Connect4Game game);
        string GetName();
    }
}
