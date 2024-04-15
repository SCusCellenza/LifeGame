
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

        //TODO : make this run until the grid is stable : implement oscillators and gliders to test https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
        internal void Run()
        {
            Grid nextGrid = _grid.NextState();

            if (_grid.AreGridsEqual(nextGrid))
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