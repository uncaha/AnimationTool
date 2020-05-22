using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
namespace AniPlayable
{
    [CreateAssetMenu(fileName = "AssetCondition", menuName = "PlayableAnimator/Condition", order = 0)]
    public class AssetCondition : ScriptableObject
    {
        [System.Serializable]
        public class Condition
        {
            public AnimatorConditionMode mode;
            public string parameter;
            public float threshold;
            public void CopyData(ref AnimatorCondition pSource)
            {
                mode = pSource.mode;
                parameter = pSource.parameter;
                threshold = pSource.threshold;
            }
        }
    }
}