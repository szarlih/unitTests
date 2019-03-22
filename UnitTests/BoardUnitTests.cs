namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UnitTestWorkshop.MajorChessPieces;
    using UnitTestWorkshop.Board;
    using System;

    [TestClass]
    public class BoardUnitTests
    {
        [TestMethod]
        public void SetChessPieceProperly()
        {
            Tuple<int, int> target = new Tuple<int, int>(3,3);

            MockRepository repository = new MockRepository(MockBehavior.Loose);

            var boardMock = repository.Create<IChessBoard>();

            var knightMock = repository.Create<IChessPiece>();
            knightMock.SetupGet(p => p.Position).Returns(target);
            knightMock.Setup(m => m.Move(target)).Returns(true);
            var knight = knightMock.Object;

            var board = new ChessBoard();

            Assert.IsTrue(board.SetPiece(target, knight));
        }

        [TestMethod]
        public void SetChessPieceWrong()
        {
            Tuple<int, int> target = new Tuple<int, int>(9, 9);

            MockRepository repository = new MockRepository(MockBehavior.Loose);

            var boardMock = repository.Create<IChessBoard>();

            var knightMock = repository.Create<IChessPiece>();
            knightMock.SetupGet(p => p.Position).Returns(new Tuple<int, int>(-1, -1));
            knightMock.Setup(m => m.Move(target)).Returns(true);
            var knight = knightMock.Object;

            var board = new ChessBoard();

            Assert.IsFalse(board.SetPiece(target, knight));
        }
    }
}
