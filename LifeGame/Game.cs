
namespace LifeGame
{
    internal class Game
    {

        private Grid _grid;
        public bool IsFinished { get; private set; }

        public Game(Grid grid)
        {
            _grid = grid;
            IsFinished = false;
        }

        //TODO : make this run until the grid is stable
        internal void Run()
        {
            Grid nextGrid = _grid.NextState();

            if (_grid.Compare(nextGrid))
            {
                IsFinished = true;
            }
            _grid = nextGrid;
        }

        internal bool GridIsEmpty()
        {
            return _grid.IsEmpty;
        }
    }
}