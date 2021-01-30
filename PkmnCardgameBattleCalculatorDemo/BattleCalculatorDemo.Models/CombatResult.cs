namespace BattleCalculatorDemo.Models
{
    public class CombatResult
    {
        public short DamageDealt { get; set; }
        public bool WasCritical { get; set; }
        public bool DidDefenderDie { get; set; } = false;
    }
}