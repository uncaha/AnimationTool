using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace LitEngine.Animation
{
    public class LitAnimator : MonoBehaviour
    {

        #region data
        #endregion
        //Dictionary<string,AnimationState>
        bool isInit = false;
        void Init()
        {
            if (isInit) return;
            isInit = true;
        }

    }
}

