
namespace LifeGame
{
    internal class Grid
    {

        public Grid()
        {
        }

        public Grid(int x, int y, List<Cell> cells)
        {
            if (x == 0 || y == 0)
            {
                throw new ArgumentException();
            }
            X = x;
            Y = y;
            Cells = cells;
        }

        public int X { get; }
        public int Y { get; }
        private List<Cell> Cells { get; }

        public bool IsEmpty => Cells == null || Cells.Count == 0;

        internal bool Compare(Grid grid)
        {
            if (IsEmpty && grid.IsEmpty)
                return true;
            if (!IsEmpty && !grid.IsEmpty)
                return true;
            return false;
        }

        internal Grid NextState()
        {
            List<Cell> nextCells = new List<Cell>();

            for(int i = 1; i <= X; i++)
                for(int j = 1; j <= Y; j++)
                {
                    var newCell = new Cell(i, j);
                    var nextCell = newCell.NextState(this.GetNumberOfNeighbours(i,j));
                    if (nextCell != null)
                        nextCells.Add(nextCell);
                }

            return new Grid(X, Y, nextCells);
        }

        private int GetNumberOfNeighbours(Cell cell)
        {
            var cellCount = Cells.Count;
            return cellCount != 0 ? cellCount - 1 : 0;
        }

        private int GetNumberOfNeighbours(int x, int y)
        {
            var neighboursCount = 0;
            foreach(Cell cell in Cells)
            {
                if (cell.X < x - 1 || cell.X > x + 1) continue;
                if (cell.Y < y - 1 || cell.Y > y + 1) continue;
                if(cell.X == x && cell.Y == y) continue;
                neighboursCount++;
            }

            return neighboursCount;
        }


    }
}