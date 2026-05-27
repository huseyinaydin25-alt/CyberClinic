namespace CyberClinic.Save
{
    public sealed class SaveService
    {
        readonly ISaveStorage _storage;

        public SaveService(ISaveStorage storage)
        {
            _storage = storage;
        }

        public void Save(string slotId, SaveGameData data)
        {
            var json = SaveSerializer.ToJson(data);
            _storage?.Write(slotId, json);
        }

        public bool TryLoad(string slotId, out SaveGameData data)
        {
            data = null;
            if (_storage == null || !_storage.TryRead(slotId, out var json))
            {
                return false;
            }

            data = SaveSerializer.FromJson(json);
            return data != null;
        }

        public bool HasSave(string slotId)
        {
            return _storage != null && _storage.HasSave(slotId);
        }

        public void Delete(string slotId)
        {
            _storage?.Delete(slotId);
        }
    }
}
