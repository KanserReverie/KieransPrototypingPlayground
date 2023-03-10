namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern
{
    /// <summary>
    /// Interface for poolable objects
    /// </summary>
    public interface IPoolable
    {
        IObjectPool Orgin { get; set; }
        void PrepareToUse();
        void ReturnToPool();
    }
}