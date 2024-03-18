

namespace LifeGame
{
    public class GridTest
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenTryingToCreateAGridWithoutColumn_ExceptionIsThrown(int columnNumber)
        {
            int lineNumber = 1;
            var cell = new Cell(1, 1);

            Action action = () => Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell });

            Assert.Throws<ArgumentException>(action);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenTryingToCreateAGridWithoutLine_ExceptionIsThrown(int lineNumber)
        {
            int columnNumber = 1;
            var cell = new Cell(1, 1);

            Action action = () => Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell });

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void WhenTryingToCreateA1x1Grid_AGridWithOneColumnAndOneLineIsCreated()
        {
            int columnNumber = 1;
            int lineNumber = 1;
            var cell = new Cell(1, 1);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell });

            Assert.Equal(columnNumber, grid.X);
            Assert.Equal(lineNumber, grid.Y);
            Assert.False(grid.IsEmpty);

        }

    }
}
