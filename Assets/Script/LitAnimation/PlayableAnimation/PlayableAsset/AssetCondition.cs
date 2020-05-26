using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AniPlayable
{
    [CreateAssetMenu(fileName = "AssetCondition", menuName = "PlayableAnimator/Condition", order = 0)]
    public class AssetCondition : ScriptableObject
    {
        public enum AnimatorConditionMode
        {
            If = 1,
            IfNot = 2,
            Greater = 3,
            Less = 4,
            Equals = 6,
            NotEqual = 7
        }
        [System.Serializable]
        public class Condition
        {
            public AnimatorConditionMode mode;
            public string parameter;
            public float threshold;
#if UNITY_EDITOR
            public void CopyData(ref UnityEditor.Animations.AnimatorCondition pSource)
            {
                mode = (AnimatorConditionMode)pSource.mode;
                parameter = pSource.parameter;
                threshold = pSource.threshold;
            }
#endif
        }

        public Condition condition;
    }
}