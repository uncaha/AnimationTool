
using System;
using System.Collections.Generic;
namespace AniPlayable.InstanceAnimation
{
    
    public class RuntimeAnimatorMachine: Node
    {
        public AnimationStateMachineInfo machineInfo { get; protected set;}
        public RuntimeAnimatorState defaultState { get; protected set;}
        private Dictionary<int,RuntimeAnimatorState> stateList = new Dictionary<int,RuntimeAnimatorState>();
        public RuntimeAnimatorMachine(AnimationStateMachineInfo pInfo)
        {
            machineInfo = pInfo;
        }
        public override void InitNode(AnimationInstancing pAnimator)
        {
            var tpam = parameters;
            foreach (var item in machineInfo.stateInfos)
            {
                var tstate = new RuntimeAnimatorState(item){parameters = tpam};
                tstate.InitNode(pAnimator);
                stateList.Add(tstate.nameHash,tstate);
                if(item.hashName == machineInfo.defaultHashName)
                {
                    defaultState = tstate;
                }
            }
        }

        public RuntimeAnimatorState this[int pKey]
        {
            get
            {
                if(!stateList.ContainsKey(pKey)) return null;
                return stateList[pKey];
            }
        }

        #region get
        public RuntimeAnimatorState GetState(string pStateName)
        {
            return this[pStateName.GetHashCode()];
        }

        #endregion

    }
}