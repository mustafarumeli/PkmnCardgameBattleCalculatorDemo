namespace BattleCalculatorDemo.Models
{
    public class BattleResult
    {
        public short DamageDealt { get; set; }
        public bool WasCritical { get; set; }
        public bool DidDefenderDie { get; set; } = false;
    }
}