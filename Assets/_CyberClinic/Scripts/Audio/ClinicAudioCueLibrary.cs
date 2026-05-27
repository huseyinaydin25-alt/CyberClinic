using System;
using CyberClinic.Procedures;
using UnityEngine;

namespace CyberClinic.Audio
{
    public sealed class ClinicAudioCueLibrary : MonoBehaviour
    {
        [SerializeField] ClinicAudioCueData[] _cues = Array.Empty<ClinicAudioCueData>();

        public int CueCount => _cues?.Length ?? 0;

        public bool TryFind(ClinicAudioRequest request, out ClinicAudioCueData cue)
        {
            cue = null;
            if (_cues == null)
            {
                return false;
            }

            for (var i = 0; i < _cues.Length; i++)
            {
                var item = _cues[i];
                if (item == null)
                {
                    continue;
                }

                if (item.EventId != request.EventId || item.Category != request.Category)
                {
                    continue;
                }

                if (request.RiskBand < item.MinimumRiskBand)
                {
                    continue;
                }

                if (item.OutcomeType != OperationOutcomeType.PreviewOnly && item.OutcomeType != request.OutcomeType)
                {
                    continue;
                }

                cue = item;
                return true;
            }

            return false;
        }
    }
}
