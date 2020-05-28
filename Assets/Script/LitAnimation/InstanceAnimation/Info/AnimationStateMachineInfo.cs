using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AniPlayable.InstanceAnimation
{
    public class AnimationStateMachineInfo
    {
        public AnimationStateInfo defaultState;
        public int defaultHashName;
        public List<AnimationStateInfo> stateInfos = new List<AnimationStateInfo>();

#if UNITY_EDITOR
        public void WriteToFile(System.IO.BinaryWriter pWriter)
        {
            pWriter.Write(defaultHashName);

            pWriter.Write(stateInfos.Count);
            for (int i = 0; i < stateInfos.Count; i++)
            {
                var item = stateInfos[i];
                item.WriteToFile(pWriter);
            }

        }
#endif

        public void ReadFromFile(System.IO.BinaryReader pReader)
        {
            defaultHashName = pReader.ReadInt32();

            int tlen = pReader.ReadInt32();
            for (int i = 0; i < tlen; i++)
            {
                var tstate = new AnimationStateInfo();
                tstate.ReadFromFile(pReader);
                if(tstate.hashName == defaultHashName)
                {
                    defaultState = tstate;
                }
                stateInfos.Add(tstate);
            }
        }
    }
}