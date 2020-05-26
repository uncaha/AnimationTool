using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
namespace AniPlayable
{
    [CreateAssetMenu(fileName = "AssetParameter", menuName = "PlayableAnimator/Parameter", order = 0)]
    public class AssetParameter : ScriptableObject
    {
        [System.Serializable]
        public class Parameter
        {
            public string name;
            public int nameHash;
            public AnimatorControllerParameterType type ;
            public float defaultFloat ;
            public int defaultInt ;
            public bool defaultBool ;

            public void CopyData(AnimatorControllerParameter des)
            {
                name = des.name;
                nameHash = des.nameHash;
                type = des.type;
                defaultFloat = des.defaultFloat;
                defaultInt = des.defaultInt;
                defaultBool = des.defaultBool;
            }
        }
        public Parameter[] parameters;
    }
}