
using System;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    
    public class RuntimeAnimatorMachine: Node
    {
        public AnimationStateMachineInfo machineInfo { get; protected set;}

        private List<RuntimeAnimatorState> stateList = new List<RuntimeAnimatorState>();
        public RuntimeAnimatorMachine(AnimationStateMachineInfo pInfo)
        {
            machineInfo = pInfo;
        }
        public override void InitNode()
        {
            var tpam = parameters;
            foreach (var item in machineInfo.stateInfos)
            {
                var tstate = new RuntimeAnimatorState(item){parameters = tpam};
                tstate.InitNode();
                stateList.Add(tstate);
            }
        }
    }
}