using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LitEngine.Animation.Data
{
    public class AnimationEvent: IAnimationData
    {
        public string function;
        public int intParameter;
        public float floatParameter;
        public string stringParameter;
        public string objectParameter;
        public float time;
    }

    public class AnimationInfo : IAnimationData
    {
        public string animationName;
        public int animationNameHash;
        public int totalFrame;
        public int fps;
        public int animationIndex;
        public int textureIndex;
        public bool rootMotion;
        public WrapMode wrapMode;
        public Vector3[] velocity;
        public Vector3[] angularVelocity;
        public List<AnimationEvent> eventList;
    }

    public class ExtraBoneInfo: IAnimationData
    {
        public string[] extraBone;
        public Matrix4x4[] extraBindPose;
    }

    public class ComparerHash : IComparer<AnimationInfo>
    {
        public int Compare(AnimationInfo x, AnimationInfo y)
        {
            return x.animationNameHash.CompareTo(y.animationNameHash);
        }
    }
}