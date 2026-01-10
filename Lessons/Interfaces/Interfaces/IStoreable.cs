namespace Interfaces.Models
{
    public interface IStoreable
    {
        void Save();
        void Load();
        bool NeedsSave { get; set; }
    }
}
