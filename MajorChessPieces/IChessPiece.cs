namespace UnitTestWorkshop.MajorChessPieces
{
    using System;
    using System.Collections.Generic;
    using UnitTestWorkshop.Utils;

    public interface IChessPiece
    {
        Tuple<int, int> Position { get; }

        bool Move(Tuple<int, int> target);

        List<Tuple<int, int>> PotentialMoves { get; }

        ColorsEnum Color { get; }

        char Symbol { get; }
    }
}
