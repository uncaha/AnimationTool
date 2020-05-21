using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AniPlayable
{
    [CreateAssetMenu(fileName = "StateController", menuName = "PlayableAnimator/StateController", order = 4)]
    public class AssetStateController : ScriptableObject
    {
        public AssetStateLayer[] stateLayers;

        public void AddStates(PlayableAnimator playableAnimator)
        {
            for (int i = 0; i < stateLayers.Length; i++)
            {
                stateLayers[i].AddLayer(playableAnimator, i);
                stateLayers[i].AddStates(playableAnimator, i);
            }
        }
    }
}

