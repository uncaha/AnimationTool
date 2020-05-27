using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AniPlayable
{
    [CreateAssetMenu(fileName = "AssetTransitions", menuName = "PlayableAnimator/Transition", order = 0)]
    public class AssetTransitions : ScriptableObject
    {
        [System.Serializable]
        public class Transtions
        {
            public bool solo;
            public bool mute;
            public bool isExit;
            public string destinationStateMachineName;
            public string destinationStateName;
            public float duration;
            public float offset;
            public int interruptionSource;
            public bool orderedInterruption;
            public float exitTime;
            public bool hasExitTime;
            public bool hasFixedDuration;
            public bool canTransitionToSelf;
            public AssetCondition.Condition[] conditions;
#if UNITY_EDITOR
            public void CopyData(UnityEditor.Animations.AnimatorStateTransition pSource)
            {
                if (pSource == null) return;
                solo = pSource.solo;
                mute = pSource.mute;
                isExit = pSource.isExit;
                destinationStateMachineName = pSource.destinationStateMachine != null ? pSource.destinationStateMachine.name : null;
                destinationStateName = pSource.destinationState != null ? pSource.destinationState.name : null;
                duration = pSource.duration;
                offset = pSource.offset;
                interruptionSource = (int)pSource.interruptionSource;
                orderedInterruption = pSource.orderedInterruption;
                exitTime = pSource.exitTime;
                hasExitTime = pSource.hasExitTime;
                hasFixedDuration = pSource.hasFixedDuration;
                canTransitionToSelf = pSource.canTransitionToSelf;

                var tcondions = pSource.conditions;
                conditions = new AssetCondition.Condition[tcondions.Length];
                for (int i = 0; i < conditions.Length; i++)
                {
                    AssetCondition.Condition item = new AssetCondition.Condition();
                    item.CopyData(ref tcondions[i]);
                    conditions[i] = item;
                }
            }

            public void WriteToFile(System.IO.BinaryWriter pWriter)
            {
                pWriter.Write(destinationStateName);
                pWriter.Write(duration);
                pWriter.Write(exitTime);

                int tlen = conditions == null ? 0 : conditions.Length;
                pWriter.Write(tlen);
                if (conditions != null)
                {
                    for (int i = 0; i < conditions.Length; i++)
                    {
                        AssetCondition.Condition item = new AssetCondition.Condition();
                        item.WriteToFile(pWriter);
                    }
                }

            }
#endif
            public void ReadFromFile(System.IO.BinaryReader pReader)
            {
                destinationStateName = pReader.ReadString();
                duration = pReader.ReadSingle();
                exitTime = pReader.ReadSingle();

                int tlen = pReader.ReadInt32();
                conditions = new AssetCondition.Condition[tlen];
                for (int i = 0; i < tlen; i++)
                {
                    conditions[i] = new AssetCondition.Condition();
                    conditions[i].ReadFromFile(pReader);
                }
            }
        }
        public Transtions data;
    }
}