using UnityEngine;
using System;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorLayer : Node
    {
        public AnimationLayerInfo layerInfo { get; protected set; }
        private List<RuntimeAnimatorMachine> machineList = new List<RuntimeAnimatorMachine>();
        public RuntimeAnimatorLayer(AnimationLayerInfo pInfo)
        {
            layerInfo = pInfo;
        }
        public override void InitNode()
        {
            var tpam = parameters;
            foreach (var item in layerInfo.machines)
            {
                var tmachine = new RuntimeAnimatorMachine(item){parameters = tpam};
                tmachine.InitNode();
                machineList.Add(tmachine);
            }
        }
    }
}