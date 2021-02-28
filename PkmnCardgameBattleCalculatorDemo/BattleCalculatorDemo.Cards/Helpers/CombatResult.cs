namespace BattleCalculatorDemo.Cards.Helpers
{
    public class CombatResult
    {
        public int DamageDealt { get; set; }
        public bool WasCritical { get; set; } = false;
        public bool DidDefenderDie { get; set; } = false;
    }
}