namespace CyberClinic.PlatformServices
{
    public enum HapticPattern
    {
        Light = 0,
        Medium = 1,
        Heavy = 2,
        Success = 3,
        Warning = 4,
        Error = 5
    }

    public interface IHapticService
    {
        void Play(HapticPattern pattern);
    }
}
