
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
                    int numberOfNeighbours = this.GetNumberOfNeighbours(columnCount, lineCount);

           
                    if (this.IsInSurvival(numberOfNeighbours, columnCount, lineCount))
                    {
                        nextCells.Add(new Cell(columnCount, lineCount));
                    }
                    else if (this.IsInReproduction(numberOfNeighbours, columnCount, lineCount))
                    {
                        nextCells.Add(new Cell(columnCount, lineCount));
                    }
                }

            return new Grid(NumberOfColumns, NumberOfLines, nextCells);
        }

        private bool IsInOverPopulation(int numberOfNeighbours)
        {
            return numberOfNeighbours > 3;
        }

        private bool IsInUnderPopulation(int numberOfNeighbours)
        {
            return numberOfNeighbours < 2;
        }

        private bool IsInSurvival(int numberOfNeighbours, int columnCount, int lineCount)
        {
            if (!CellIsAliveAtThisPosition(columnCount, lineCount))
                return false;
            
            return !(this.IsInOverPopulation(numberOfNeighbours) || this.IsInUnderPopulation(numberOfNeighbours));
        }
        private bool IsInReproduction(int numberOfNeighbours, int columnCount, int lineCount)
        {
            if (CellIsAliveAtThisPosition(columnCount, lineCount))
                return false;

            return numberOfNeighbours == 3;
        }

        internal bool CellIsAliveAtThisPosition(int columnPosition, int linePosition)
        {
            return Cells.Any(c => c.ColumnPosition == columnPosition && c.LinePosition == linePosition);
        }

        private int GetNumberOfNeighbours(int columnPosition, int linePosition)
        {
            var neighboursCount = 0;
            foreach(Cell cell in Cells)
            {
                if (cell.ColumnPosition < columnPosition - 1 || cell.ColumnPosition > columnPosition + 1) continue;
                if (cell.LinePosition < linePosition - 1 || cell.LinePosition > linePosition + 1) continue;
                if(cell.ColumnPosition == columnPosition && cell.LinePosition == linePosition) continue;
                neighboursCount++;
            }

            return neighboursCount;
        }

    }
}