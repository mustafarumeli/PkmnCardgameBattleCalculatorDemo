namespace BattleCalculatorDemo.Models
{
    public class CombatResult
    {
        public int DamageDealt { get; set; }
        public bool WasCritical { get; set; }
        public bool DidDefenderDie { get; set; } = false;
    }
}