using PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.Obstacle
{
    public class ObstacleDropper : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private GameObject endGamePrefab;
        [SerializeField] private Vector3 dropLocation = new Vector3(0f,4f,0f);
        [SerializeField] private float dropDistance = 3f;
        [SerializeField] private Vector3 endPoint;

        private Vector3 lastDrop;
        private Animator spawnerAnimatedController;
        private BikeController bikeController;
        private static readonly int Startgame = Animator.StringToHash("Startgame");
        private static readonly int Endgame = Animator.StringToHash("Endgame");
        private static readonly int TimeToDrop = Animator.StringToHash("TimeToDrop");

        private void Start()
        {
            bikeController = FindObjectOfType<BikeController>();
            spawnerAnimatedController = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            if (bikeController==null)
            {
                Debug.Log("null _bikeController");
                return;
            }
            if (Vector3.Distance(
                bikeController.transform.position, 
                Vector3.zero) >= 4f)
                spawnerAnimatedController.SetTrigger(Startgame);
            if(Vector3.Distance(bikeController.transform.position, endPoint) <= 12f)
                spawnerAnimatedController.SetTrigger(Endgame);
            spawnerAnimatedController.SetFloat(TimeToDrop,
                Vector3.Distance(
                    bikeController.transform.position + dropLocation + (Vector3.forward * dropDistance), 
                    lastDrop));
        }

        public void SpawnObstacle()
        {
            GameObject dropObject =  Instantiate(
                obstaclePrefab,
                (bikeController.transform.position + dropLocation + (Vector3.forward * dropDistance)), 
                transform.rotation);
            lastDrop = dropObject.transform.position;
        }

        public void SpawnFinish()
        {
            Quaternion rotation = transform.rotation;
            Instantiate(endGamePrefab, (endPoint + dropLocation), rotation);
            Instantiate(endGamePrefab, (endPoint + dropLocation + Vector3.left * 2), rotation);
            Instantiate(endGamePrefab, (endPoint + dropLocation + Vector3.left * 4), rotation);
            Instantiate(endGamePrefab, (endPoint + dropLocation + Vector3.right * 2), rotation);
            Instantiate(endGamePrefab, (endPoint + dropLocation + Vector3.right * 4), rotation);
        }
    }
}
