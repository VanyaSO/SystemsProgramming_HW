namespace HW_3;

public class World
{
    public readonly int Width;
    public readonly int Height;
    public char[,] Map;
    public readonly char MapChar;
    public readonly char KillChar = 'x';
    public List<Ant.Ant> Ants = new List<Ant.Ant>();
    public List<(int x, int y)> KillPlaces = new List<(int x, int y)>();

    public World(int width = 7, int height = 7, char charMap = '_')
    {
        Width = width;
        Height = height;
        Map = new char[width, height];
        MapChar = charMap;
        InitMap();
    }
    private void InitMap()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Map[x, y] = MapChar;
            }
        }
    }
    public void PrintMap()
    {
        while (true)
        {
            Console.Clear();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (KillPlaces.Contains((x, y))) Map[x, y] = KillChar;
                    Console.Write(Map[x,y]);
                }
                Console.WriteLine();
            }

            PrintAnts();
            Thread.Sleep(1000);
        }
    }
    public bool IsPlaceTaken(int x, int y) => Map[x, y] == MapChar;
    public Ant.Ant? FindAntByPosition(int x, int y)
    {
        return Ants.FirstOrDefault(e => e.X == x && e.Y == y);
    }

    private void PrintAnts()
    {
        int top = 0;
        foreach (var ant in Ants)
        {
            Console.SetCursorPosition(20, top++);
            Console.WriteLine($"Symbol: {ant.AntSettings.Symbol}; Health: {ant.AntSettings.Hp}; Damage: {ant.AntSettings.Damage}");
        }
    }
}