namespace UnitTestWorkshop.MajorChessPieces
{
    using System;
    using System.Collections.Generic;
    using UnitTestWorkshop.Utils;

    public class Knight : IChessPiece
    {
        public Knight(ColorsEnum color, Tuple<int, int> position = null)
        {
            Color = color;
            Position = position != null ? position : new Tuple<int, int>(-1, -1);
            Symbol = '1';
        }

        public Tuple<int, int> Position { get; private set; }

        public List<Tuple<int, int>> PotentialMoves
        {
            get
            {
                var list = new List<Tuple<int, int>>();

                list.Add(new Tuple<int, int>(Position.Item1 - 1, Position.Item2 - 2));
                list.Add(new Tuple<int, int>(Position.Item1 + 1, Position.Item2 - 2));
                list.Add(new Tuple<int, int>(Position.Item1 + 2, Position.Item2 - 1));
                list.Add(new Tuple<int, int>(Position.Item1 + 2, Position.Item2 + 1));
                list.Add(new Tuple<int, int>(Position.Item1 + 1, Position.Item2 + 2));
                list.Add(new Tuple<int, int>(Position.Item1 - 1, Position.Item2 + 2));
                list.Add(new Tuple<int, int>(Position.Item1 - 2, Position.Item2 + 1));
                list.Add(new Tuple<int, int>(Position.Item1 - 2, Position.Item2 - 1));

                return list;
            }
        }

        public ColorsEnum Color { get; private set; }

        public char Symbol { get; private set; }

        public bool Move(Tuple<int, int> target)
        {
            if(PotentialMoves.Contains(target))
            {
                Position = target;
                return true;
            }

            return false;
        }
    }
}
