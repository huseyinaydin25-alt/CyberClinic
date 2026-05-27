using UnityEngine;

namespace CyberClinic.Save
{
    public static class SaveSerializer
    {
        public static string ToJson(SaveGameData data)
        {
            return JsonUtility.ToJson(data ?? new SaveGameData(), false);
        }

        public static SaveGameData FromJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return new SaveGameData();
            }

            var data = JsonUtility.FromJson<SaveGameData>(json);
            return data ?? new SaveGameData();
        }
    }
}
