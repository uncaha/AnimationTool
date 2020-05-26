using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AniPlayable.Module
{
    public class AnimatorTransition : AnimatorModule
    {
        public int Index { get; private set; }
        public AnimatorCondition[] conditions { get; private set; }

        public string destinationStateMachineName;
        public string destinationStateName;
        public float duration;
        public float exitTime;
        protected AssetTransitions.Transtions transtion;
        public AnimatorTransition(PlayableAnimator playableAnimator,AssetTransitions.Transtions pData, int pIndex)
        {
            transtion = pData;
            Index = pIndex;

            destinationStateMachineName = pData.destinationStateMachineName;
            destinationStateName = pData.destinationStateName;
            duration = pData.duration;
            exitTime = pData.exitTime;

            if(transtion.conditions != null && transtion.conditions.Length > 0)
            {
                conditions = new AnimatorCondition[transtion.conditions.Length];
                for (int i = 0; i < conditions.Length; i++)
                {
                    conditions[i] = new AnimatorCondition(playableAnimator,transtion.conditions[i],i);
                }
            }
            
        }

        public bool CheckCondition()
        {
            if(conditions == null || conditions.Length == 0) return true;
            bool isOk = true;
            int tlen = conditions.Length;
            for (int i = 0; i < tlen; i++)
            {
                var item = conditions[i];
                if(!item.CheckCondition())
                {
                    isOk = false;
                    break;
                }
            }
            return isOk;
        }

    }
}