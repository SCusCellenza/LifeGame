namespace LifeGame
{
    public class UnitTest1
    {
        [Fact]
        public void given_an_empty_grid_the_game_is_finished_after_the_first_round()
        {

            var grid = new Grid();
            var game = new Game(grid);

            game.Run();

            Assert.True(game.IsFinished);
        }

        [Fact]
        public void GivenInitialState_ThenNotFinished()
        {
            var grid = new Grid();
            var game = new Game(grid);

            Assert.False(game.IsFinished);

        }

        [Fact]
        public void GivenA1x1GridWith1Cell_GameIsNotFinishedAfterOneRound()
        {
            var cell = new Cell();
            var grid = new Grid(1, 1, cell);

            var game = new Game(grid);

            game.Run();

            Assert.False(game.IsFinished);
        }

        [Fact]
        public void GivenA1xA1GridWithCell_GameIsFinishedAfterTwoRounds()
        {
            var cell = new Cell();
            var grid = new Grid(1, 1, cell);

            var game = new Game(grid);

            game.Run();
            game.Run();

            Assert.True(game.IsFinished);
        }

        [Fact]
        public void GivenAGridWithoutLine_ExceptionIsThrown()
        {
            var cell = new Cell();

            Assert.Throws<ArgumentException>(() =>
                     new Grid(1, 0, cell)
                 );
        }

        [Fact]
        public void GivenAGridWithoutColumn_ExceptionIsThrown()
        {
            var cell = new Cell();

            Assert.Throws<ArgumentException>(() =>
                     new Grid(0, 1, cell)
                 );
        }

    }
}