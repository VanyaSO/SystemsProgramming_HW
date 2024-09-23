using static HW_3.Program;

namespace HW_3.Ant;

public abstract class Ant
{
    public AntSettings AntSettings { get; set; }
    public bool IsLive { get; set; } = true;
    public int X;
    public int Y;
    protected Thread _thread;
    public static List<AntSettings> AntSettingsList = new List<AntSettings>();
    
    protected static void RandomPosition(ref int x, ref int y)
    {
        do
        {
            // гененрируем рандомную позицию в диапазоне карты, пока не найдем свободное место
            x = Program.Random.Next(Program.World.Width);
            y = Program.Random.Next(Program.World.Height);
        } while (!Program.World.IsPlaceTaken(x,y));
    }
    protected void Live()
    {
        while (IsLive)
        {
            Move();
            Thread.Sleep(1000);
        }
    }
    protected void Move()
    {
        int oldX = X, oldY = Y;
        
        // рандомный ход в одну из сторон
        bool isFindPalce = true;
        while (isFindPalce && IsLive)
        {
            switch (Program.Random.Next(4))
            {
                case 0:
                    if (X > 0)
                    {
                        if (CheckPlace(X-1, Y)) break;
                        X--;
                        isFindPalce = false;
                    }
                    break;
                case 1:
                    if (Y > 0)
                    {
                        if (CheckPlace(X, Y-1)) break;
                        Y--;
                        isFindPalce = false;
                    }
                    break;
                case 2:
                    if (Y < Program.World.Height - 1)
                    {
                        if (CheckPlace(X, Y+1)) break;
                        Y++;
                        isFindPalce = false;
                    }
                    break;
                case 3:
                    if (X < Program.World.Width - 1)
                    {
                        if (CheckPlace(X+1, Y)) break;
                        X++;
                        isFindPalce = false;
                    }
                    break;
            }
        }
        
        Program.World.Map[oldX, oldY] = Program.World.MapChar;
        Program.World.Map[X, Y] = AntSettings.Symbol;
    }
    protected bool CheckPlace(int x, int y)
    {
        // если место занято устраиваем фой
        if (!Program.World.IsPlaceTaken(x, y))
        {
            Ant? findAnt = Program.World.FindAntByPosition(x, y);
            if (findAnt != null && findAnt.IsLive)
            {
                Fight(findAnt);
            }

            return true;
        }
        return false;
    }
    public void Kill()
    {
        Program.World.Map[X, Y] = 'x';
        Program.World.KillPlaces.Add((X, Y));
        IsLive = false;
    }
    public abstract void Fight(Ant ant);
}