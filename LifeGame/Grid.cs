
using System.Collections.Generic;

namespace LifeGame
{
    internal class Grid
    {

        public int NumberOfColumns { get; }
        public int NumberOfLines { get; }
        private List<Cell> Cells { get; }

        public bool IsEmpty => Cells == null || Cells.Count == 0;

        private Grid(int numberOfColumns, int lines, List<Cell> cells)
        {
            NumberOfColumns = numberOfColumns;
            NumberOfLines = lines;
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

        //TODO : clean this

        internal Grid NextState()
        {
            List<Cell> nextCells = new List<Cell>();

            for(int columnCount = 1; columnCount <= NumberOfColumns; columnCount++)
                for(int lineCount = 1; lineCount <= NumberOfLines; lineCount++)
                {
                    if (CellIsAliveAtThisPosition(columnCount, lineCount))
                    {
                        int numberOfNeighbours = this.GetNumberOfNeighbours(columnCount, lineCount);
                        if (numberOfNeighbours == 3 || numberOfNeighbours == 2)
                        {
                            nextCells.Add(new Cell(columnCount, lineCount));
                        }
                    }
                }

            return new Grid(NumberOfColumns, NumberOfLines, nextCells);
        }

        internal bool CellIsAliveAtThisPosition(int columnPosition, int linePosition)
        {
            return Cells.Any(c => c.X == columnPosition && c.Y == linePosition);
        }

        private int GetNumberOfNeighbours(int columnPosition, int linePosition)
        {
            var neighboursCount = 0;
            foreach(Cell cell in Cells)
            {
                if (cell.X < columnPosition - 1 || cell.X > columnPosition + 1) continue;
                if (cell.Y < linePosition - 1 || cell.Y > linePosition + 1) continue;
                if(cell.X == columnPosition && cell.Y == linePosition) continue;
                neighboursCount++;
            }

            return neighboursCount;
        }

    }
}