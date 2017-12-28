namespace lab3
{
    public interface IAttack<T> where T : Unit
    {
        int Damage { get; set; }
        bool IsAttack { get; set; }
        int AttackSpeed { get; set; }

        event AttackHandle AttackEvent;
        void Attack(T target);
        void MakeCriticalHit(T target);
        void CheckAttack(T attacker, AttackEventArgs args);
    }
}