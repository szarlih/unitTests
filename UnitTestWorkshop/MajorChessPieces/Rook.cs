namespace UnitTestWorkshop.MajorChessPieces
{
    using System;
    using System.Collections.Generic;
    using UnitTestWorkshop.Utils;

    class Rook : IChessPiece
    {
        public Tuple<int, int> Position => throw new NotImplementedException();

        public List<Tuple<int, int>> PotentialMoves => throw new NotImplementedException();

        public ColorsEnum Color => throw new NotImplementedException();

        public char Symbol => throw new NotImplementedException();

        public bool Move(Tuple<int, int> target)
        {
            throw new NotImplementedException();
        }
    }
}
