using System;
using CyberClinic.Core;
using CyberClinic.Cosmetics;
using CyberClinic.Economy;
using CyberClinic.Progression;
using CyberClinic.Tutorial;

namespace CyberClinic.Save
{
    [Serializable]
    public class SaveGameSnapshot
    {
        public SaveVersion Version = SaveVersion.Initial;
        public int RunSeed;
        public ClinicStateSnapshot ClinicState = new ClinicStateSnapshot();
        public PlayerProgressionState PlayerProgression = new PlayerProgressionState();
        public TutorialProgressState TutorialProgress = new TutorialProgressState();
        public CosmeticOwnershipState CosmeticOwnership = new CosmeticOwnershipState();
        public DateTime SavedAtUtc;
    }
}
