using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AniPlayable.Module;
namespace AniPlayable.InstanceAnimation
{
    public class InstAnimator : MonoBehaviour
    {
        #region serlizeddata
        [SerializeField] private AssetStateController _assetStateController;
        [SerializeField] protected string defaultState;
        [SerializeField] protected bool isAutoPlay = false;
        public AnimatorUpdateMode mode = AnimatorUpdateMode.Normal;
        #endregion

        #region control
        public bool isPlaying { get; protected set; }
        public bool isPause { get; protected set; }
        #endregion
        private UpdateObject updateObject;

        #region Init Method
        private bool m_IsInitialized = false;
        private void Awake()
        {
            Init();
            if (isAutoPlay)
            {

            }
        }

        public void Init()
        {
            if (m_IsInitialized) return;
            Initialize();
            if (_assetStateController != null)
            {

            }
        }

        private void Initialize()
        {
            if (m_IsInitialized) return;

            updateObject = new UpdateObject(this, UpdateRender, mode);
            PlayableUpdateManager.Reg(updateObject);
            m_IsInitialized = true;
        }

        public void UpdateRender(float dt)
        {
            if (!isPlaying || isPause) return;

        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void OnDestroy()
        {
            PlayableUpdateManager.UnReg(updateObject);
        }
        #endregion
    }
}