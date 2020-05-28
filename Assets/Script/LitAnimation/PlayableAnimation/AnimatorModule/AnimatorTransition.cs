using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AniPlayable.Module
{
    public class AnimatorTransition : AnimatorModule
    {
        
        public int Index { get; private set; }
        public AssetTransitions.DestinationType destinationType{ get { return transtion.destinationType; } }
        public string destinationName { get { return transtion.destinationName; } }
        public int destinationHashName {get;private set;}
        public float duration { get { return transtion.duration; } }
        public float exitTime { get { return transtion.exitTime; } }

        AnimatorCondition[] conditions { get; set; }
        protected AssetTransitions.Transtions transtion;
        public AnimatorTransition(PlayableAnimatorParameter parms,AssetTransitions.Transtions pData, int pIndex)
        {
            transtion = pData;
            Index = pIndex;

            if(transtion.conditions != null && transtion.conditions.Length > 0)
            {
                conditions = new AnimatorCondition[transtion.conditions.Length];
                for (int i = 0; i < conditions.Length; i++)
                {
                    conditions[i] = new AnimatorCondition(parms,transtion.conditions[i],i);
                }
            }

            destinationHashName = destinationName.GetHashCode();
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