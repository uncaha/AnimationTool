using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AniPlayable
{
    public class AssetState : ScriptableObject
    {
        [System.Serializable]
        public class AnimationState
        {
            public AnimationClip clip;
            public float threshold;
            public float speed;
            public AssetBlendTree.BlendTreeType blendTreeType;
            public string stateName;
            public AssetTransitions.Transtions[] transtions;

            public void AddState(PlayableAnimator playableAnimator, string groupName, int layer)
            {
                string tstateName = string.IsNullOrEmpty(stateName) ? clip.name : stateName;
                PlayableStateController.StateInfo tinfo = playableAnimator.AddState(clip, tstateName, groupName, layer);
                tinfo.transtions = transtions;
                tinfo.speed = speed;
            }
        }

        public AnimationState data;
    }
}