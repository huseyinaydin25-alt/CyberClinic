using System;
using CyberClinic.Procedures;
using UnityEngine;

namespace CyberClinic.Feedback
{
    public sealed class ClinicFeedbackRouter : MonoBehaviour
    {
        [SerializeField] ClinicFeedbackCueData[] _cues = Array.Empty<ClinicFeedbackCueData>();

        public int CueCount => _cues?.Length ?? 0;
        public ClinicFeedbackCueData LastMatchedCue { get; private set; }
        public ClinicFeedbackRequest LastRequest { get; private set; }

        public bool TryRoute(ClinicFeedbackRequest request, out ClinicFeedbackCueData cue)
        {
            LastRequest = request;
            cue = FindCue(request);
            LastMatchedCue = cue;
            return cue != null;
        }

        ClinicFeedbackCueData FindCue(ClinicFeedbackRequest request)
        {
            if (_cues == null)
            {
                return null;
            }

            for (var i = 0; i < _cues.Length; i++)
            {
                var cue = _cues[i];
                if (cue == null)
                {
                    continue;
                }

                if (cue.EventId != request.EventId)
                {
                    continue;
                }

                if (request.RiskBand < cue.MinimumRiskBand)
                {
                    continue;
                }

                if (cue.OutcomeType != OperationOutcomeType.PreviewOnly && cue.OutcomeType != request.OutcomeType)
                {
                    continue;
                }

                return cue;
            }

            return null;
        }
    }
}
