namespace UnitTestWorkshop.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
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

            Assert.AreEqual(new System.Tuple<int, int>(2, 6), knight.Position);
            Assert.IsTrue(knight.Move(new System.Tuple<int, int>(2, 6)));    
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
    }
}
