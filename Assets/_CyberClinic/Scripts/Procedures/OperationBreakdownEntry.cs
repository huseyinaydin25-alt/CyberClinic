using System;

namespace CyberClinic.Procedures
{
    [Serializable]
    public struct OperationBreakdownEntry
    {
        public string TermKey;
        public float Value;
        public int SortOrder;

        public OperationBreakdownEntry(string termKey, float value, int sortOrder)
        {
            TermKey = termKey;
            Value = value;
            SortOrder = sortOrder;
        }
    }
}
