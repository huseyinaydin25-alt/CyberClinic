namespace CyberClinic.PlatformServices
{
    public enum GamePlatform
    {
        Editor = 0,
        Android = 1,
        iOS = 2
    }

    public interface IPlatformService
    {
        GamePlatform Platform { get; }
        string AppVersion { get; }
        void OpenStorePage();
    }
}
