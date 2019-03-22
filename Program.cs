namespace UnitTestWorkshop
{
    using System;
    using UnitTestWorkshop.Board;
    using UnitTestWorkshop.MajorChessPieces;

    class Program
    {
        private static string input;
        private static IChessPiece selected;

        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            Demo(board);
            ParticipantWork();

            ProgramLoop(board);
        }

        private static void Demo(IChessBoard board)
        {
            board.SetPiece(new Tuple<int, int>(0, 7), new Knight(Utils.ColorsEnum.Black, new Tuple<int, int>(0, 7)));
            board.ShowBoard();

            board.MovePiece(new Tuple<int, int>(0, 7), new Tuple<int, int>(2, 6));

            board.ShowBoard();

            board.MovePiece(new Tuple<int, int>(0, 7), new Tuple<int, int>(2, 3));

            board.ShowBoard();
        }

        private static void ParticipantWork()
        {
            // add code here
        }

        private static void ProgramLoop(IChessBoard board)
        {
            Console.WriteLine("To move select your chess piece by command 'select x,y' where x is column and y is row.");
            Console.WriteLine("Next move by command 'move x,y' where x is column and y is row.");
            Console.WriteLine("Move:");
            input = string.Empty;

            while (!input.Equals("exit"))
            {
                input = Console.ReadLine().Trim().ToLower();

                if (input.Contains("move"))
                {
                    if (selected == null)
                    {
                        Console.WriteLine("No chess piece selected.");
                        continue;
                    }

                    if(!board.MovePiece(selected.Position, GetCoordinates(input)))
                    {
                        Console.WriteLine("Invalid move.");
                    }

                    board.ShowBoard();
                    selected = null;
                    continue;
                }
                else if (input.Contains("select"))
                {
                    try
                    {
                        selected = board.GetSquare(GetCoordinates(input));
                        if(selected == null)
                        {
                            Console.WriteLine("No chess piece selected.");
                        }
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    continue;
                }

                if (input.Contains("exit"))
                {
                    break;
                }

                Console.WriteLine("Invalid command. Try again.");
            }
        }

        private static Tuple<int, int> GetCoordinates(string input)
        {
            char[] parameters = { ' ', ',' };
            string[] splited = input.Split(parameters);
            if(splited.Length != 3)
            {
                return new Tuple<int, int>(-1, -1);
            }

            int x = int.Parse(splited[1]);
            int y = int.Parse(splited[2]);

            return new Tuple<int, int>(x, y);
        }
    }
}
