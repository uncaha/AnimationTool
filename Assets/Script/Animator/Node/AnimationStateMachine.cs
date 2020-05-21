using UnityEngine;
using System.Collections.Generic;
using LitEngine.Animation.Data;
namespace LitEngine.Animation
{
    public class AnimationStateMachine : AnimationNode
    {
        AnimationStateMachineInfo info;
        Dictionary<string,AnimationNode> stateDic = new Dictionary<string, AnimationNode>();
        protected override void Initialized()
        {
            if(Data is AnimationStateMachineInfo)
            {
                info = (AnimationStateMachineInfo)Data;
            }else{
                Debug.LogWarningFormat("AnimationStateMachine-> this Data is not AnimationStateMachineInfo. Data = {0}",Data != null ? Data.ToString() : "null" );
            }
        }
        protected override void DisposeUnityGc()
        {

        }

        
    }
}