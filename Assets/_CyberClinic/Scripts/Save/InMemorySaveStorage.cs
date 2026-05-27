using System.Collections.Generic;

namespace CyberClinic.Save
{
    public sealed class InMemorySaveStorage : ISaveStorage
    {
        readonly Dictionary<string, string> _slots = new Dictionary<string, string>();

        public bool HasSave(string slotId)
        {
            return !string.IsNullOrWhiteSpace(slotId) && _slots.ContainsKey(slotId);
        }

        public void Write(string slotId, string json)
        {
            if (string.IsNullOrWhiteSpace(slotId))
            {
                return;
            }

            _slots[slotId] = json ?? string.Empty;
        }

        public bool TryRead(string slotId, out string json)
        {
            json = string.Empty;
            return !string.IsNullOrWhiteSpace(slotId) && _slots.TryGetValue(slotId, out json);
        }

        public void Delete(string slotId)
        {
            if (!string.IsNullOrWhiteSpace(slotId))
            {
                _slots.Remove(slotId);
            }
        }
    }
}
