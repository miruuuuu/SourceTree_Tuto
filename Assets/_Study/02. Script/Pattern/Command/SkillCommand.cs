using UnityEngine;

public class SkillCommand : ICommand
{
    public Unit unit;
    private string skillName;
    
    public SkillCommand(Unit unit, string skillName)
    {
        this.unit = unit;
        this.skillName = skillName;
    }
    
    public void Execute()
    {
        unit.UseSkill("Fireball");
    }

    public void Cancel()
    {
        unit.UseSkillCancel("Fireball");
    }
}