using System;

namespace lab3
{
    public static class SquadExtension
    {
        public static void GetAllInfo(this Squad<Unit> units)
        {
            foreach (Unit unit in units)
                Console.WriteLine(unit);
        }
        
        public static Unit GetFastestUnit(this Squad<Unit> units)
        {
            Unit fastestUnit = units[0];
            foreach (Unit unit in units)
            {
                if (unit.Speed > fastestUnit.Speed)
                    fastestUnit = unit;
            }
            return fastestUnit;
        }
    }
}