namespace CyberClinic.Core
{
    /// <summary>
    /// Stable content identifier used across ScriptableObject definitions and runtime lookups.
    /// </summary>
    public interface IIdentifiable
    {
        string Id { get; }
    }
}
