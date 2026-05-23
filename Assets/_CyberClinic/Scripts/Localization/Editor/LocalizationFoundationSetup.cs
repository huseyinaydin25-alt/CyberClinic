#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace CyberClinic.Localization.Editor
{
    /// <summary>
    /// Creates locales, string table collections, and seed entries from CSV (Milestone 2).
    /// Menu: Cyber Clinic/Localization/Setup Foundation (M2)
    /// </summary>
    public static class LocalizationFoundationSetup
    {
        const string LocalizationRoot = "Assets/_CyberClinic/Localization";
        const string LocalesPath = LocalizationRoot + "/Locales";
        const string StringTablesPath = LocalizationRoot + "/StringTables";
        const string SeedPath = StringTablesPath + "/Seed";
        const string SettingsAssetPath = LocalizationRoot + "/LocalizationSettings.asset";

        static readonly (string CollectionName, string CsvFileName)[] TableDefinitions =
        {
            ("UI", "UI"),
            ("Tutorial", "Tutorial"),
            ("Patients", "Patients"),
            ("Implants", "Implants"),
            ("Procedures", "Procedures"),
            ("Economy", "Economy"),
            ("Events", "Events"),
            ("Cosmetics", "Cosmetics"),
            ("Clinic", "Clinic"),
            ("Errors", "Errors"),
            ("System", "System")
        };

        [MenuItem("Cyber Clinic/Localization/Setup Foundation (M2)")]
        public static void SetupFoundation()
        {
            if (!IsLocalizationPackageAvailable())
            {
                Debug.LogError(
                    "Unity Localization package is not available. Ensure com.unity.localization and com.unity.addressables are in Packages/manifest.json, then wait for Package Manager to finish.");
                return;
            }

            EnsureFolders();
            var localeEn = EnsureLocale("en", "English (en)");
            var localeTr = EnsureLocale("tr", "Turkish (tr)");
            EnsureLocalizationSettings(localeEn);

            var imported = 0;
            foreach (var definition in TableDefinitions)
            {
                imported += ImportSeedTable(definition.CollectionName, definition.CsvFileName, localeEn, localeTr);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"Cyber Clinic localization foundation setup complete. Imported/updated {imported} keys across {TableDefinitions.Length} tables.");
        }

        static bool IsLocalizationPackageAvailable()
        {
            return Type.GetType("UnityEditor.Localization.LocalizationEditorSettings, Unity.Localization.Editor") != null;
        }

        static void EnsureFolders()
        {
            CreateFolder("Assets/_CyberClinic", "Localization");
            CreateFolder(LocalizationRoot, "Locales");
            CreateFolder(LocalizationRoot, "AssetTables");
            CreateFolder(LocalizationRoot, "StringTables");
            CreateFolder(StringTablesPath, "Seed");
        }

        static void CreateFolder(string parent, string child)
        {
            var combined = parent + "/" + child;
            if (!AssetDatabase.IsValidFolder(combined))
            {
                AssetDatabase.CreateFolder(parent, child);
            }
        }

        static Locale EnsureLocale(string code, string displayName)
        {
            var identifier = new LocaleIdentifier(code);
            var existing = LocalizationEditorSettings.GetLocale(identifier);
            if (existing != null)
            {
                return existing;
            }

            var assetPath = $"{LocalesPath}/{displayName}.asset";
            var existingAsset = AssetDatabase.LoadAssetAtPath<Locale>(assetPath);
            if (existingAsset != null)
            {
                LocalizationEditorSettings.AddLocale(existingAsset);
                return existingAsset;
            }

            var locale = Locale.CreateLocale(code);
            locale.name = displayName;
            AssetDatabase.CreateAsset(locale, assetPath);
            LocalizationEditorSettings.AddLocale(locale);
            return locale;
        }

        static void EnsureLocalizationSettings(Locale localeEn)
        {
            var settings = LocalizationEditorSettings.ActiveLocalizationSettings;
            if (settings == null)
            {
                settings = AssetDatabase.LoadAssetAtPath<LocalizationSettings>(SettingsAssetPath);
            }

            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<LocalizationSettings>();
                AssetDatabase.CreateAsset(settings, SettingsAssetPath);
            }

            LocalizationEditorSettings.ActiveLocalizationSettings = settings;
            LocalizationSettings.ProjectLocale = localeEn;
            EditorUtility.SetDirty(settings);
        }

        static int ImportSeedTable(string collectionName, string csvFileName, Locale localeEn, Locale localeTr)
        {
            var csvPath = $"{SeedPath}/{csvFileName}.csv";
            if (!File.Exists(csvPath))
            {
                Debug.LogWarning($"Seed CSV not found: {csvPath}");
                return 0;
            }

            var rows = ParseCsv(csvPath);
            var collectionDirectory = $"{StringTablesPath}/{collectionName}";
            var collection = LocalizationEditorSettings.GetStringTableCollection(collectionName);
            if (collection == null)
            {
                collection = LocalizationEditorSettings.CreateStringTableCollection(collectionName, collectionDirectory);
            }

            var enTable = EnsureStringTable(collection, localeEn);
            var trTable = EnsureStringTable(collection, localeTr);

            var count = 0;
            foreach (var row in rows)
            {
                var keyId = collection.SharedData.GetId(row.Key, addNewKey: true);
                if (keyId == SharedTableData.EmptyId)
                {
                    Debug.LogWarning($"Could not create shared key '{row.Key}' in collection '{collectionName}'.");
                    continue;
                }

                SetTableEntry(enTable, keyId, row.English);
                SetTableEntry(trTable, keyId, row.Turkish);
                count++;
            }

            EditorUtility.SetDirty(collection);
            EditorUtility.SetDirty(collection.SharedData);
            EditorUtility.SetDirty(enTable);
            EditorUtility.SetDirty(trTable);
            return count;
        }

        static StringTable EnsureStringTable(StringTableCollection collection, Locale locale)
        {
            var table = collection.GetTable(locale.Identifier) as StringTable;
            if (table != null)
            {
                return table;
            }

            return collection.AddNewTable(locale.Identifier) as StringTable;
        }

        static void SetTableEntry(StringTable table, long sharedEntryId, string value)
        {
            var entry = table.GetEntry(sharedEntryId);
            if (entry == null)
            {
                table.AddEntry(sharedEntryId, value);
            }
            else
            {
                entry.Value = value;
            }
        }

        static List<SeedRow> ParseCsv(string path)
        {
            var rows = new List<SeedRow>();
            var lines = File.ReadAllLines(path);
            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var parts = line.Split(',');
                if (parts.Length < 3)
                {
                    continue;
                }

                rows.Add(new SeedRow
                {
                    Key = parts[0].Trim(),
                    English = parts[1].Trim(),
                    Turkish = parts[2].Trim()
                });
            }

            return rows;
        }

        struct SeedRow
        {
            public string Key;
            public string English;
            public string Turkish;
        }
    }
}
#endif
