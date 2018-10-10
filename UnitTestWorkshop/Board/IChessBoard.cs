namespace UnitTestWorkshop.Board
{
    using System;
    using UnitTestWorkshop.MajorChessPieces;

    interface IChessBoard
    {
        void ShowBoard();
        bool MovePiece(Tuple<int, int> source, Tuple<int, int> target);

        bool SetPiece(Tuple<int, int> target, IChessPiece piece);
    }
}
