namespace GameFoundation.CustomTimeline {
    using System;
    using UnityEngine;
    using UnityEngine.Playables;
    using UnityEngine.Timeline;

    [Serializable]
    public class MarkerClip : PlayableAsset, ITimelineClipAsset {
        public MarkerBehaviour template = new MarkerBehaviour();

        public ClipCaps clipCaps {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            var             playable = ScriptPlayable<MarkerBehaviour>.Create(graph, this.template);
            MarkerBehaviour clone    = playable.GetBehaviour();
            return playable;
        }
    }
}
