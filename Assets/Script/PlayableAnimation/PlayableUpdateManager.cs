using UnityEngine;
using System.Collections.Generic;
namespace AniPlayable
{
    public class UpdateObject
    {
        public List<UpdateObject> owner;
        public AnimatorUpdateMode updateType { get; private set; }
        public string Key { get; private set; }
        public bool IsDestroyed { get { return target == null; } }
        public bool IsEnable {get{return target!= null && target.enabled && target.gameObject.activeInHierarchy;}}
        System.Action<float> delgate;
        PlayableAnimator target;

        public UpdateObject(PlayableAnimator tar, System.Action<float> pDelgate, AnimatorUpdateMode pType = AnimatorUpdateMode.Normal)
        {
            target = tar;
            Key = target.gameObject.ToString();
            delgate = pDelgate;
            updateType = pType;
        }

        public void Call(float dt)
        {
            delgate?.Invoke(dt);
        }
    }
    public class PlayableUpdateManager : MonoBehaviour
    {
        static PlayableUpdateManager sInstance = null;
        static private PlayableUpdateManager Ins
        {
            get
            {
                if (sInstance == null)
                {
                    GameObject tobj = new GameObject("PlayableUpdateManager");
                    GameObject.DontDestroyOnLoad(tobj);
                    sInstance = tobj.AddComponent<PlayableUpdateManager>();
                }
                return sInstance;
            }
        }

        List<UpdateObject> lateUpdataList = new List<UpdateObject>();
        List<UpdateObject> fixedUpdataList = new List<UpdateObject>();
        List<UpdateObject> unscaleUpdataList = new List<UpdateObject>();

        static public void Reg(UpdateObject pobj)
        {
            List<UpdateObject> towner = null;
            switch (pobj.updateType)
            {
                case AnimatorUpdateMode.Normal:
                    towner = Ins.lateUpdataList;
                    break;
                case AnimatorUpdateMode.AnimatePhysics:
                    towner = Ins.fixedUpdataList;
                    break;
                case AnimatorUpdateMode.UnscaledTime:
                    towner = Ins.unscaleUpdataList;
                    break;
                default:
                    Debug.LogError("erro animatorUpdateode");
                    return;
            }
            if (pobj.owner != towner)
            {
                pobj.owner?.Remove(pobj);
                pobj.owner = towner;
                towner.Add(pobj);
            }
        }

        static public void UnReg(UpdateObject pobj)
        {
            if (pobj.owner != null)
            {
                pobj.owner.Remove(pobj);
            }
        }
        private void LateUpdate()
        {
            UpdateList(lateUpdataList, Time.deltaTime);
            UpdateList(unscaleUpdataList, Time.unscaledDeltaTime);
        }
        private void FixedUpdate()
        {
            UpdateList(fixedUpdataList, Time.fixedDeltaTime);
        }

        void UpdateList(List<UpdateObject> pList, float dt)
        {
            int length = pList.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                var item = pList[i];
                if (item.IsDestroyed)
                {
                    pList.RemoveAt(i);
                    continue;
                }
                if(item.IsEnable)
                    item.Call(dt);
            }
        }
    }
}