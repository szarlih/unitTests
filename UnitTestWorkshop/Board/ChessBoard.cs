
namespace UnitTestWorkshop.Board
{
    using System;
    using UnitTestWorkshop.MajorChessPieces;

    class ChessBoard : IChessBoard
    {
        private const int size = 8;
        private IChessPiece[,] squares;

        public ChessBoard()
        {
            squares = new IChessPiece[size, size];
        }

        public IChessPiece GetSquare(Tuple<int, int> target)
        {
            if(target.Item1 < size && target.Item2 < size && target.Item1 > -1 && target.Item2 > -1)
            {
                return squares[target.Item1, target.Item2];
            }

            throw new ArgumentException("Invalid square coordinates.");
        }

        public bool MovePiece(Tuple<int, int> source, Tuple<int, int> target)
        {
            if(!IsEmpty(target) || IsEmpty(source))
            {
                return false;
            }

            var result = squares[source.Item1, source.Item2].Move(target);

            if (result)
            {
                squares[target.Item1, target.Item2] = squares[source.Item1, source.Item2];
                squares[source.Item1, source.Item2] = null;
            }

            return result;
        }

        public bool SetPiece(Tuple<int, int> target, IChessPiece piece)
        {
            if (!IsEmpty(target))
            {
                return false;
            }

            squares[target.Item1, target.Item2] = piece;
            return true;
        }

        public void ShowBoard()
        {
            for(int x = 0; x <= squares.GetUpperBound(0); x++)
            {
                for(int y = 0; y <= squares.GetUpperBound(1); y++)
                {
                    if (squares[x,y] == null)
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        Console.Write(string.Format("[{0}]", squares[x, y].Symbol));
                    }
                }

                Console.WriteLine(string.Empty);
            }

            Console.WriteLine(string.Empty);
        }

        private bool IsEmpty(Tuple<int, int> target)
        {
            if (target.Item1 >= size || target.Item2 >= size)
            {
                return false;
            }

            return squares[target.Item1, target.Item2] == null;
        }
    }
}
