namespace lab4
{
    //TODO Відокремлення інтерфейсу
    public interface IAttack<T> where T : Unit
    {
        int Damage { get; set; }
        bool IsAttack { get; set; }
        int AttackSpeed { get; set; }

        event AttackHandle AttackEvent;
        void AttackTarget(T target);
        void MakeCriticalHit(T target);
        void CheckAttack(T attacker, AttackEventArgs args);
    }
}