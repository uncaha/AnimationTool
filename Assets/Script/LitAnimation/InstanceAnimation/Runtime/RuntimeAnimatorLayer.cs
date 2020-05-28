using UnityEngine;
using System;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorLayer : Node
    {
        public RuntimeAnimatorMachine defaultStateMachine {get ; private set;}
        public AnimationLayerInfo layerInfo { get; protected set; }
        private List<RuntimeAnimatorMachine> machineList = new List<RuntimeAnimatorMachine>();
        public RuntimeAnimatorLayer(AnimationLayerInfo pInfo)
        {
            layerInfo = pInfo;
        }
        public override void InitNode(AnimationInstancing pAnimator)
        {
            var tpam = parameters;
            foreach (var item in layerInfo.machines)
            {
                var tmachine = new RuntimeAnimatorMachine(item){parameters = tpam};
                tmachine.InitNode(pAnimator);
                machineList.Add(tmachine);
            }
            if(machineList.Count > 0)
                defaultStateMachine = machineList[0];
        }

        public RuntimeAnimatorMachine this[int index]
        {
            get
            {
                if (index < 0 || index >= machineList.Count) return null;
                return machineList[index];
            }
        }
    }
}