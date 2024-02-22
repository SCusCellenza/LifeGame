
namespace LifeGame
{
    internal class Grid
    {

        public Grid()
        {
        }

        public Grid(int x, int y, Cell cell)
        {
            if (x==0 || y == 0)
            {
                throw new ArgumentException();
            }
            X = x;
            Y = y;
            Cell = cell;
        }

        public int X { get; }
        public int Y { get; }
        private Cell Cell { get; }

        public bool IsEmpty => Cell == null;

        internal bool Compare(Grid grid)
        {
            if(IsEmpty && grid.IsEmpty)
                return true;
            if (!IsEmpty && !grid.IsEmpty)
                return true;
            return false;
        }

        internal Grid NextState()
        {
           Cell nextCell = Cell.NextState();
            return new Grid(X,Y,nextCell);  
        }

    }
}