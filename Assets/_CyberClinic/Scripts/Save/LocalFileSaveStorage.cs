using System.IO;

namespace CyberClinic.Save
{
    public sealed class LocalFileSaveStorage : ISaveStorage
    {
        readonly string _rootDirectory;

        public LocalFileSaveStorage(string rootDirectory)
        {
            _rootDirectory = string.IsNullOrWhiteSpace(rootDirectory) ? "." : rootDirectory;
        }

        public bool HasSave(string slotId)
        {
            return File.Exists(GetPath(slotId));
        }

        public void Write(string slotId, string json)
        {
            if (string.IsNullOrWhiteSpace(slotId))
            {
                return;
            }

            Directory.CreateDirectory(_rootDirectory);
            File.WriteAllText(GetPath(slotId), json ?? string.Empty);
        }

        public bool TryRead(string slotId, out string json)
        {
            json = string.Empty;
            var path = GetPath(slotId);
            if (!File.Exists(path))
            {
                return false;
            }

            json = File.ReadAllText(path);
            return true;
        }

        public void Delete(string slotId)
        {
            var path = GetPath(slotId);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        string GetPath(string slotId)
        {
            var safeSlot = string.IsNullOrWhiteSpace(slotId) ? "default" : slotId;
            safeSlot = safeSlot.Replace("/", "_").Replace("\\", "_");
            return Path.Combine(_rootDirectory, safeSlot + ".json");
        }
    }
}
