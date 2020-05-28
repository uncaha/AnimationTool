
using System;
using AniPlayable.Module;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    public class AnimationStateNode : Node
    {
        public string stateName;
        public int nameHash;

        public AnimationStateInfo stateInfo { get; protected set;}
        public List<AnimatorTransition> animatorTransitions = new List<AnimatorTransition>();
        public AnimationInstancing aniInfo;

        public AnimationStateNode(AnimationStateInfo pInfo)
        {
            stateInfo = pInfo;
        }
    }
}