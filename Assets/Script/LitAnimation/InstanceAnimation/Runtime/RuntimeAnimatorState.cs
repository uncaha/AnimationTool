
using System;
using AniPlayable.Module;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorState : Node
    {
        public string stateName;
        public int nameHash;
        public int motionHash = 0;
        public int motionIndex = 0;

        public AnimationStateInfo stateInfo { get; protected set;}
        public List<AnimatorTransition> animatorTransitions = new List<AnimatorTransition>();
        public AnimationInstancing aniInfo;

        public RuntimeAnimatorState(AnimationStateInfo pInfo)
        {
            stateInfo = pInfo;
            stateName = stateInfo.name;
            nameHash = stateInfo.hashName;
            motionHash = stateInfo.motionName.GetHashCode();
        }
        public override void InitNode()
        {
            for (int i = 0; i < stateInfo.transtionList.Count; i++)
            {
                var item = stateInfo.transtionList[i];
                AnimatorTransition item2 = new AnimatorTransition(parameters, item, i);
                animatorTransitions.Add(item2);
            }
        }

        public AnimatorTransition CheckTransition(float p)
        {
            if (animatorTransitions.Count == 0) return null;

            var transtions = animatorTransitions;
            for (int i = 0; i < transtions.Count; i++)
            {
                var ttrans = transtions[i];
                if (ttrans.CheckCondition())
                {
                    if (ttrans.exitTime < p)
                    {
                        return ttrans;
                    }
                }

            }
            return null;
        }
    }
}