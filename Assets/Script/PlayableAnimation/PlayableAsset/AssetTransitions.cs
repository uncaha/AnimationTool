using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
namespace AniPlayable
{
    [CreateAssetMenu(fileName = "AssetTransitions", menuName = "PlayableAnimator/Transition", order = 0)]
    public class AssetTransitions : ScriptableObject
    {
        [System.Serializable]
        public class Transtions
        {
            public string targetName;
            public float duration;
            public float offset;
            public TransitionInterruptionSource interruptionSource;
            public bool orderedInterruption;
            public float exitTime;
            public bool hasExitTime;
            public bool hasFixedDuration;
            public bool canTransitionToSelf;

            public void CopyData(AnimatorStateTransition pSource)
            {
                targetName = pSource.destinationState.name;
                duration = pSource.duration;
                offset = pSource.offset;
                interruptionSource = pSource.interruptionSource;
                orderedInterruption = pSource.orderedInterruption;
                exitTime = pSource.exitTime;
                hasExitTime = pSource.hasExitTime;
                hasFixedDuration = pSource.hasFixedDuration;
                canTransitionToSelf = pSource.canTransitionToSelf;
            }
        }
        public Transtions data;
    }
}