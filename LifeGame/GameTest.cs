namespace LifeGame
{
    public class GameTest
    {
        [Fact]
        public void GivenAnGridWithAllCellsDead_TheGameIsFinishedAfterThFirstRound()
        {

            var grid = Grid.TryCreate(1, 1, new List<Cell> { });
            var game = new Game(grid);

            game.Run();

            Assert.True(game.IsFinished);
        }

        [Fact]
        public void GivenInitialState_ThenNotFinished()
        {
            var grid = Grid.TryCreate(1, 1, new List<Cell> { });
            var game = new Game(grid);

            Assert.False(game.IsFinished);

        }

        [Fact]
        public void GivenA1xA1GridWith1Cell_GameIsNotFinishedAfterOneRound()
        {
            var cell = new Cell(1,1);
            var grid = Grid.TryCreate(1, 1, new List<Cell> { cell });

            var game = new Game(grid);

            game.Run();

            Assert.False(game.IsFinished);
        }

        [Fact]
        public void GivenA1xA1GridWithCell_GameIsFinishedAfterTwoRounds()
        {
            var cell = new Cell(1,1);
            var grid = Grid.TryCreate(1, 1, new List<Cell> { cell });

            var game = new Game(grid);

            game.Run();
            game.Run();

            Assert.True(game.IsFinished);
        }



        [Fact]
        public void GivenA2xA2GridWith2Cells_GameIsFinishedAfterTwoRounds()
        {
            var cell1 = new Cell(1,1);
            var cell2 = new Cell(1,1);
            var grid = Grid.TryCreate(2, 2, new List<Cell> { cell1,cell2 });

            var game = new Game(grid);
            game.Run();
            game.Run();
            Assert.True(game.IsFinished);

        }

        [Fact]
        public void GivenA2xA2GridWith3Cells_GameIsFinishedAfterTwoRounds()
        {
            var cell1 = new Cell(1,1);
            var cell2 = new Cell(1,2);
            var cell3 = new Cell(2,1);
            var grid = Grid.TryCreate(2, 2, new List<Cell> { cell1, cell2, cell3 });

            var game = new Game(grid);
            game.Run();
            game.Run();
            Assert.True(game.IsFinished);
            Assert.False(game.GridIsEmpty());

        }


    }
}