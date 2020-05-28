using UnityEngine;
using System;
using System.Collections.Generic;

namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorLayerGroup: Node
    {   
        public List<AnimationLayerInfo> layerListInfo {get; private set;}
        private List<RuntimeAnimatorLayer> LayerList = new List<RuntimeAnimatorLayer>();
        public RuntimeAnimatorLayerGroup(List<AnimationLayerInfo> pInfo)
        {
            layerListInfo = pInfo;
        }

        public override void InitNode(AnimationInstancing pAnimator)
        {
            var tpam = parameters;
            foreach (var item in layerListInfo)
            {
                var trtlayer = new RuntimeAnimatorLayer(item){parameters = tpam};
                trtlayer.InitNode(pAnimator);
                LayerList.Add(trtlayer);
            }
        }

        public RuntimeAnimatorLayer this[int index]
        {
            get
            {
                if (index < 0 || index >= LayerList.Count) return null;
                return LayerList[index];
            }
        }
    }
}