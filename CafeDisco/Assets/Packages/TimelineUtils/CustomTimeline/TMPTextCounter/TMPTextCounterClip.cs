namespace GameFoundation.CustomTimeline {
    using System;
    using UnityEngine;
    using UnityEngine.Playables;
    using UnityEngine.Timeline;

    [Serializable]
    public class TMPTextCounterClip : PlayableAsset, ITimelineClipAsset {
        public TMPTextCounterBehaviour template = new TMPTextCounterBehaviour();

        public ClipCaps clipCaps {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            var                     playable = ScriptPlayable<TMPTextCounterBehaviour>.Create(graph, this.template);
            TMPTextCounterBehaviour clone    = playable.GetBehaviour();
            return playable;
        }
    }
}
