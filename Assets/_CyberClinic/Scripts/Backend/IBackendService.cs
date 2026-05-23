namespace CyberClinic.Backend
{
    /// <summary>Root backend facade. Gameplay must not call Supabase directly.</summary>
    public interface IBackendService
    {
        bool IsAvailable { get; }
        void Initialize();
    }
}
