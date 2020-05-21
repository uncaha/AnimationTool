using UnityEngine;
using System.IO;
namespace LitEngine.Animation.Data
{
    public enum NodeType
    {
        none = 0,
        machine,
        state,
        transition,
        player,
    }

    public abstract class AnimationNodeData : IAnimationData
    {
        public string name;
        virtual public void Read(BinaryReader pReader)
        {
            
        }

        static public void ReadNode(BinaryReader pReader)
        {
            
        }
    }

    public class AnimationStateMachineInfo : AnimationNodeData
    {
        public IAnimationData[] children;
        public AnimationTransitionInfo[] transitionList;
    }

    public class AnimationStateInfo : AnimationNodeData
    {
        public string motion;
        public float speed = 1;
    }

    public class AnimationTransitionInfo : AnimationNodeData
    {
        public string nextNode;
        public int hasExitTime;
        public TransitionSetting setings;
        public ConditionInfo[] conditions;
    }

    public class TransitionSetting : AnimationNodeData
    {
        public float exitTime = 0;
        public bool fixedDuration = false;
        public float transitionDuration = 0;
        public float trnsitionOffset = 0;
        public int interruptionSource = 0;
        public bool orderedInterruption = false;
        public bool canTransitionToSelf = false;
        public string preViewAnimationName = null;
    }

    public class ConditionInfo: AnimationNodeData
    {
        public string type;
        public float value;
    }
}