namespace BattleCalculatorDemo.AbstractionLayer
{

    public interface ICombatResult
    {
        public int DamageDealt { get; set; }
        public bool WasCritical { get; set; }
        public bool DidDefenderDie { get; set; }
    }
    public interface IBoardManager
    {
        void SetPlayer2(IPlayerInGame playerInGame);
        ICombatResult Battle(string attackerId, string defenderId, int attackingSide = 1);
        public void Player1PlayCard(string cardId);
        public void Player2PlayCard(string cardId);
    }
}