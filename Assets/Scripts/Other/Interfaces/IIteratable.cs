namespace Toweristika.Other
{
    public interface IIteratable<T>
    {
        bool IsDone();
        void Next();
        T GetCurrent();
    }
}