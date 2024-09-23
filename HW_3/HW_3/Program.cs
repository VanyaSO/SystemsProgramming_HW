namespace HW_3;


// Описание 
// У нас есть разные роли, есть киллер который убивает мирных 
// Бой происходит таким образом: когда мураыей хочет стать на какоето место и это место занято,
// проверяет кто это по роли, если враг то наносит первый ему урон,
// если не убил, получает повторно
public class Program
{
    public static Random Random = new Random();
    public static World World = new World();
    
    static void Main(string[] args)
    {
        AntSettings.InitAntSettings();

        World.Ants.Add(new Ant.AntPeaceful((RoleAnt)0));
        World.Ants.Add(new Ant.AntPeaceful((RoleAnt)1));
        World.Ants.Add(new Ant.AntPeaceful((RoleAnt)2));
        World.Ants.Add(new Ant.AntPeaceful((RoleAnt)4));
        World.Ants.Add(new Ant.AntKiller());

        Thread threadWorld = new Thread(() => World.PrintMap());
        threadWorld.Start();
    }
}