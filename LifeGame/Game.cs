
namespace LifeGame
{
    internal class Game
    {

        private Grid grid;

        public Game(Grid grid)
        {
            this.grid = grid;
            IsFinished = false;
        }

        public bool IsFinished { get; private set; }
        internal void Run()
        {
            if (grid.IsEmpty)
            {
                IsFinished = true;
                return;
            }
          

            Grid nextGrid = grid.NextState();

            if (grid.Compare(nextGrid))
            {
                IsFinished = true;
            }
            grid = nextGrid;
        }

        internal bool GridIsEmpty()
        {
            return grid.IsEmpty;
        }
    }
}