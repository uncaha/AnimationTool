using LitEngine.Animation.Data;
namespace LitEngine.Animation
{
    public abstract class AnimationNode : System.IDisposable
    {
        public NodeType nodeType { get; private set; }
        public IAnimationData Data { get; private set; }
        
        #region  init
        bool IsInit = false;
        public void Init(IAnimationData pData)
        {
            if(IsInit) return;
            Data = pData;
            Initialized();
            IsInit = true;
        }
        abstract protected void Initialized();
        ~AnimationNode()
        {
            Dispose(false);
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool pdis)
        {
            if (disposed) return;
            disposed = true;
            if (pdis)
            {
                DisposeUnityGc();
            }
        }

        abstract protected void DisposeUnityGc();
        #endregion
    }
}