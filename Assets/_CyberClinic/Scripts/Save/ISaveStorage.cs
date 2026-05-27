namespace CyberClinic.Save
{
    public interface ISaveStorage
    {
        bool HasSave(string slotId);
        void Write(string slotId, string json);
        bool TryRead(string slotId, out string json);
        void Delete(string slotId);
    }
}
