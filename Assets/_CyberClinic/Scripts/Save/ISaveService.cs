namespace CyberClinic.Save
{
    public interface ISaveService
    {
        bool HasSave { get; }
        bool TryLoad(out SaveGameSnapshot snapshot);
        void Save(SaveGameSnapshot snapshot);
        void DeleteSave();
    }
}
