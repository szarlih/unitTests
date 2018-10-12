namespace UnitTestWorkshop.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UnitTestWorkshop.Board;
    using UnitTestWorkshop.MajorChessPieces;

    [TestClass]
    public class MovingUnitTest
    {
        [TestMethod]
        public void KnightProperMoveTest()
        {
            MockRepository repository = new MockRepository(MockBehavior.Loose);

            // manual
            var knightMock = repository.Create<IChessPiece>();

            knightMock.SetupGet(c => c.Color).Returns(Utils.ColorsEnum.Black);

            knightMock.Setup(m => m.Move(new System.Tuple<int, int>(2, 6))).Returns(true);
            knightMock.SetupGet(p => p.Position).Returns(new System.Tuple<int, int>(2, 6));

            var knight = knightMock.Object;

            Assert.IsTrue(knight.Move(new System.Tuple<int, int>(2, 6)));

            Assert.AreEqual(new System.Tuple<int, int>(2, 6), knight.Position);
        }

        [TestMethod]
        public void KnightWrongMoveTest()
        {
            MockRepository repository = new MockRepository(MockBehavior.Loose);

            var knightMock = repository.Create<IChessPiece>();
            knightMock.SetupAllProperties();
            knightMock.SetupGet(p => p.Position).Returns(new System.Tuple<int, int>(0, 7));

            var knight = knightMock.Object;

            Assert.IsFalse(knight.Move(null));

            Assert.AreEqual(new System.Tuple<int, int>(0, 7), knight.Position);
        }

        [TestMethod]
        public void NewTest()
        {
            var knight = new Knight(Utils.ColorsEnum.Black, new System.Tuple<int, int>(0,5));
            Assert.AreEqual(new System.Tuple<int, int>(0,5), knight.Position);

            Assert.IsTrue(knight.Move(new System.Tuple<int, int>(2, 6)));

            Assert.AreEqual(new System.Tuple<int, int>(2, 6), knight.Position);
        }

        [TestMethod]
        public void MoveFail()
        {
            var knight = new Knight(Utils.ColorsEnum.Black, new System.Tuple<int, int>(0, 4));
            Assert.AreEqual(new System.Tuple<int, int>(0, 4), knight.Position);

            Assert.IsFalse(knight.Move(new System.Tuple<int, int>(2, 6)));

            Assert.AreNotEqual(new System.Tuple<int, int>(2, 6), knight.Position);
        }


        [TestMethod]
        public void MoveOnBoard()
        {
            MockRepository repository = new MockRepository(MockBehavior.Loose);
            var knightMock = repository.Create<IChessPiece>();

            knightMock.SetupGet(c => c.Color).Returns(Utils.ColorsEnum.Black);

            knightMock.Setup(m => m.Move(new System.Tuple<int, int>(1,1))).Returns(true);
            knightMock.SetupGet(p => p.Position).Returns(new System.Tuple<int, int>(1,1));

            var knight = knightMock.Object;

            var board = new ChessBoard();
            board.SetPiece(new System.Tuple<int, int>(0, 5), knight);

            Assert.IsNotNull(board.GetSquare(new System.Tuple<int, int>(0, 5)));

            Assert.IsTrue(board.MovePiece(new System.Tuple<int, int>(0, 5), new System.Tuple<int, int>(1, 1)));
            Assert.AreEqual(board.GetSquare(new System.Tuple<int, int>(1, 1)).Position, knight.Position);
        }

        [TestMethod]
        public void WrongMoveOnBoard()
        {
            MockRepository repository = new MockRepository(MockBehavior.Loose);
            var knightMock = repository.Create<IChessPiece>();

            knightMock.SetupGet(c => c.Color).Returns(Utils.ColorsEnum.Black);

            knightMock.Setup(m => m.Move(new System.Tuple<int, int>(1, 1))).Returns(false);
            knightMock.SetupGet(p => p.Position).Returns(new System.Tuple<int, int>(0,5));

            var knight = knightMock.Object;

            var board = new ChessBoard();
            board.SetPiece(new System.Tuple<int, int>(0, 5), knight);

            Assert.IsNotNull(board.GetSquare(new System.Tuple<int, int>(0, 5)));

            Assert.IsFalse(board.MovePiece(new System.Tuple<int, int>(0, 5), new System.Tuple<int, int>(1, 1)));
            Assert.IsNull(board.GetSquare(new System.Tuple<int, int>(1, 1)));
            Assert.AreEqual(new System.Tuple<int, int>(0,5), knight.Position);
        }
    }
}
