using UnityEngine;
using System;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    public class RuntimeAnimatorLayer : Node
    {
        public string name { get { return layerInfo.name; } }
        public int index { get { return layerInfo.index; } }
        public RuntimeAnimatorMachine defaultStateMachine {get ; private set;}
        
        AnimationLayerInfo layerInfo;
        private List<RuntimeAnimatorMachine> machineList = new List<RuntimeAnimatorMachine>();
        private Dictionary<int,RuntimeAnimatorMachine> machineDic = new Dictionary<int,RuntimeAnimatorMachine>();
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
                machineDic.Add(tmachine.defaultHashName,tmachine);
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

        public int GetMachineIndex(int pHashName)
        {
            if(!machineDic.ContainsKey(pHashName)) return -1;
            return machineDic[pHashName].index;
        } 
    }
}