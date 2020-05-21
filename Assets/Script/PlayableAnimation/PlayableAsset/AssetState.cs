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
        }
    }
}