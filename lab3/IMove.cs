namespace lab2
{
    public interface IMove
    {
        int Speed { get; set; }
        bool IsMove { get; set; }
        bool IsRun { get; set; }

        void Jump();
        void SitDown();
    }
}