namespace CyberClinic.Core
{
    /// <summary>
    /// Content entry that can be selected from weighted pools during procedural generation.
    /// </summary>
    public interface IWeightedDefinition : IIdentifiable
    {
        /// <summary>Relative selection weight (greater than zero when used in pools).</summary>
        float Weight { get; }
    }
}
