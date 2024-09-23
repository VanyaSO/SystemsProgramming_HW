namespace HW_3.Ant;

public class AntPeaceful : Ant
{
    public AntPeaceful(RoleAnt role)
    {
        if (role == RoleAnt.Killer) throw new ArgumentOutOfRangeException("Мирный не может быть убицей");
        
        AntSettings = AntSettingsList[(int)role]; // характеристики в зависимости от роли
        RandomPosition(ref X, ref Y);
        _thread = new Thread(() => Live());
        _thread.Start();
    }
    
    public override void Fight(Ant ant)
    {
        if (ant.AntSettings.Role == RoleAnt.Killer)
        {
            ant.AntSettings.Hp -= AntSettings.Damage;
            if (ant.AntSettings.Hp <= 0)
            {
                ant.AntSettings.Hp = 0;
                ant.Kill();
                return;
            }
            
            Thread.Sleep(1000);
            ant.Fight(this);
        }
    }
}