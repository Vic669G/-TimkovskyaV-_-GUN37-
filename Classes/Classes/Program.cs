namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();
        }
    }
    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }

    public struct Interval
    {
        private static Random random = new Random();
        public float Min { get; }
        public float Max { get; }

        public Interval(int minValue, int maxValue)
        {
            if (minValue < 0)
            {
                Console.WriteLine("[Warning] Минимальное значение меньше 0. Установлено в 0.");
                minValue = 0;
            }
            if (maxValue < 0)
            {
                Console.WriteLine("[Warning] Максимальное значение меньше 0. Установлено в 0.");
                maxValue = 0;
            }

            if (minValue > maxValue)
            {
                Console.WriteLine("[Warning] minValue > maxValue. Значения были поменяны местами.");
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            if (minValue == maxValue)
            {
                Console.WriteLine("[Warning] minValue == maxValue. maxValue увеличен на 10.");
                maxValue += 10;
            }

            Min = minValue;
            Max = maxValue;
        }

        public float Get()
        {
            return (float)(Min + random.NextDouble() * (Max - Min));
        }

        public override string ToString()
        {
            return $"[{Min} - {Max}]";
        }
    }

}
