
namespace LifeGame
{
    internal class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }


        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal Cell NextState(int numberOfNeighbours)
        {

            if (numberOfNeighbours == 3 || numberOfNeighbours == 2)
            {
                return new Cell(this.X, this.Y);
            }
            return null;
        }
    }
}