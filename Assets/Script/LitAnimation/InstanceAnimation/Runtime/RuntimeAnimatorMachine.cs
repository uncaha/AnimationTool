
using System;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    
    public class RuntimeAnimatorMachine: Node
    {
        public AnimationStateMachineInfo machineInfo { get; protected set;}
        public RuntimeAnimatorMachine(AnimationStateMachineInfo pInfo)
        {
            machineInfo = pInfo;
        }
    }
}