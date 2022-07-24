using UnityEngine;

namespace PrototypingPlayground.DumplingTesting.DeathAndRespawning
{
    public sealed class LivesManager : MonoBehaviour
    {
        #region MakeSingleton
        
        private static LivesManager  instance;

        public static LivesManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<LivesManager>();

                    if(instance == null)
                    {
                        GameObject tempGameObject = new GameObject();
                        tempGameObject.name = typeof(LivesManager).Name;
                        instance = tempGameObject.AddComponent<LivesManager>();
                    }
                }
                return instance;
            }
        }

        public void Awake()
        {
            if(instance == null)
            {
                instance = this as LivesManager;
                DontDestroyOnLoad(gameObject);
            } 
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion
        [SerializeField] private int communalLives;
        [SerializeField] private int startingLivesAmount = 10;

        private void Start()
        {
            communalLives = startingLivesAmount;
        }

        public bool AreThereAnyLivesLeft()
        {
            return communalLives > 0;

        }
        public void LoseLive()
        {
            communalLives--;
        }
    }
}
