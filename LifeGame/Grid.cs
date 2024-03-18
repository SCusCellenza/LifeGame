
using System.Collections.Generic;

namespace LifeGame
{
    internal class Grid
    {

        public int X { get; }
        public int Y { get; }
        private List<Cell> Cells { get; }

        public bool IsEmpty => Cells == null || Cells.Count == 0;

        private Grid(int x, int y, List<Cell> cells)
        {
            X = x;
            Y = y;
            Cells = cells;
        }

        // TO DO : implement the full try pattern with a bool and the out 
        internal static Grid TryCreate(int columnNumber, int lineNumber, List<Cell> cells)
        {
            if (columnNumber <= 0 || lineNumber <= 0)
            {
                throw new ArgumentException();
            }

            return new Grid(columnNumber, lineNumber, cells);
        }

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

        // TODO : to be tested with multiple tests --> delete everything and do it again
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