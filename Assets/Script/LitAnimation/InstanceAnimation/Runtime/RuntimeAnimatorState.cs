
using System;
using AniPlayable.Module;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorState : Node
    {
        public int layerIndex {get{return stateInfo.layerIndex;}}
        public int machineIndex {get{return stateInfo.machineIndex;}}
        public string stateName {get{return stateInfo.name;}}
        public int nameHash {get{return stateInfo.hashName;}}
        public int motionHash {get; private set;}
        public int motionIndex {get; private set;}

        public AnimationStateInfo stateInfo { get; protected set;}
        public List<AnimatorTransition> animatorTransitions = new List<AnimatorTransition>();

        public RuntimeAnimatorState(AnimationStateInfo pInfo)
        {
            if(pInfo == null) return;
            stateInfo = pInfo;
            motionHash = stateInfo.motionName.GetHashCode();
        }
        public override void InitNode(AnimationInstancing pAnimator)
        {
            motionIndex = pAnimator.FindAnimationInfo(motionHash);
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