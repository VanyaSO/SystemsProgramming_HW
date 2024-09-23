namespace HW_3;

public class AntSettings
{
    public char Symbol { get; set; }
    public RoleAnt Role { get; set; }
    public int Hp { get; set; }
    public int Damage { get; set; }

    public static void InitAntSettings()
    {
        Ant.Ant.AntSettingsList.Add(new AntSettings {Symbol = 'W',Role = RoleAnt.Worker, Hp = 30, Damage = 5});
        Ant.Ant.AntSettingsList.Add(new AntSettings {Symbol = 'S',Role = RoleAnt.SecurityGuard, Hp = 50, Damage = 15});
        Ant.Ant.AntSettingsList.Add(new AntSettings {Symbol = 'H',Role = RoleAnt.Hunter, Hp = 70, Damage = 50});
        Ant.Ant.AntSettingsList.Add(new AntSettings {Symbol = 'K',Role = RoleAnt.Killer, Hp = 100, Damage = 40});
        Ant.Ant.AntSettingsList.Add(new AntSettings {Symbol = 'Q',Role = RoleAnt.Queen, Hp = 100, Damage = 10});
    }
}