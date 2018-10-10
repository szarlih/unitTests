namespace UnitTestWorkshop
{
    using System;
    using UnitTestWorkshop.Board;
    using UnitTestWorkshop.MajorChessPieces;

    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            board.SetPiece(new Tuple<int, int>(0, 7), new Knight(Utils.ColorsEnum.Black, new Tuple<int, int>(0,7)));
            board.ShowBoard();

            board.MovePiece(new Tuple<int, int>(0, 7), new Tuple<int, int>(2, 6));

            board.ShowBoard();

            board.MovePiece(new Tuple<int, int>(0, 7), new Tuple<int, int>(2, 3));

            board.ShowBoard();

            Console.ReadLine();
        }
    }
}
