using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AniPlayable.Module;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
namespace AniPlayable.InstanceAnimation
{
    public class AnimationStateInfo
    {
        public string name;
        public int hashName;
        public float speed = 1;
        public List<AssetTransitions.Transtions> transtionList = new List<AssetTransitions.Transtions>();
#if UNITY_EDITOR
        public void SetData(UnityEditor.Animations.AnimatorState pState)
        {
            name = pState.name;
            hashName = pState.nameHash;
            speed = pState.speed;

            transtionList.Clear();
            AnimatorStateTransition[] transs = pState.transitions;
            for (int k = 0; k < transs.Length; k++)
            {
                AnimatorStateTransition transdata = transs[k];
                AssetTransitions.Transtions ttranstion = new AssetTransitions.Transtions();
                ttranstion.CopyData(transdata);
                transtionList.Add(ttranstion);
            }
        }

        public void WriteToFile(System.IO.BinaryWriter pWriter)
        {
            pWriter.Write(name);
            pWriter.Write(hashName);
            pWriter.Write(speed);

            pWriter.Write(transtionList.Count);
            for (int i = 0; i < transtionList.Count; i++)
            {
                AssetTransitions.Transtions item = transtionList[i];
                item.WriteToFile(pWriter);
            }

        }
#endif
        public void ReadFromFile(System.IO.BinaryReader pReader)
        {
            name = pReader.ReadString();
            hashName = pReader.ReadInt32();
            speed = pReader.ReadSingle();

            int tlen = pReader.ReadInt32();
            for (int i = 0; i < tlen; i++)
            {
                var item = new AssetTransitions.Transtions();
                item.ReadFromFile(pReader);
                transtionList.Add(item);
            }
        }
    }
}