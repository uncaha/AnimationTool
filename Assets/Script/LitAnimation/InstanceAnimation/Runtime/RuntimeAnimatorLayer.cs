using UnityEngine;
using System;
namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorLayer : Node
    {
        public AnimationLayerInfo layerInfo { get; protected set; }
        public RuntimeAnimatorLayer(AnimationLayerInfo pInfo)
        {
            layerInfo = pInfo;
        }
    }
}