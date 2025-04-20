namespace GameFoundation.CustomTimeline {
    using UnityEngine;
    using UnityEngine.Playables;

    public class CustomAnimationMixerBehaviour : PlayableBehaviour {
        //TODO
        //Need to optimize here
// NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
        public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
            Animation trackBinding = playerData as Animation;

            if (!trackBinding)
                return;

            int inputCount = playable.GetInputCount();

            for (int i = 0; i < inputCount; i++) {
                float inputWeight = playable.GetInputWeight(i);
                if (inputWeight <= 0f)
                    continue;
                ScriptPlayable<CustomAnimationBehaviour> inputPlayable = (ScriptPlayable<CustomAnimationBehaviour>) playable.GetInput(i);
                CustomAnimationBehaviour input = inputPlayable.GetBehaviour();

                // Use the above variables to process each frame of this playable.
                trackBinding.enabled = true;
                
                foreach (AnimationState a in trackBinding) {

                    if (a.name == input.animationName && !trackBinding.IsPlaying(a.name)) {
                        trackBinding[a.name].time = input.startTime;
                        trackBinding[a.name].wrapMode = input.wrapMode;
                        if (input.crossFade)
                        {
                            trackBinding.CrossFade(input.animationName, 0.5f, PlayMode.StopAll);
                            trackBinding[input.animationName].speed = input.speed;
                        }

                        else
                        {
                            trackBinding.Play(input.animationName, PlayMode.StopAll);
                            trackBinding[input.animationName].speed = input.speed;
                        }
                    }
                }
            }
        }
    }
}
