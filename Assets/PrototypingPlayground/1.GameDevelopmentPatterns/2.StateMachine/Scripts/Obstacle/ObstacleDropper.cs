using PrototypingPlayground._1.GameDevelopmentPatterns._2.StateMachine.BikeStateMachine;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._2.StateMachine.Obstacle
{
    public class ObstacleDropper : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private GameObject endGamePrefab;
        [SerializeField] private Vector3 dropLocation = new Vector3(0f,4f,0f);
        [SerializeField] private float dropDistance = 3f;
        [SerializeField] private Vector3 endPoint;

        private Vector3 _lastDrop;
        private Animator _spawnerAnimatedController;
        private BikeController _bikeController;
        private void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
            _spawnerAnimatedController = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            if (Vector3.Distance(_bikeController.transform.position, Vector3.zero) >= 4f)
                _spawnerAnimatedController.SetTrigger("Startgame");
            if(Vector3.Distance(_bikeController.transform.position, endPoint) <= 12f)
                _spawnerAnimatedController.SetTrigger("Endgame");
            _spawnerAnimatedController.SetFloat("TimeToDrop",
                Vector3.Distance(
                    _bikeController.transform.position + dropLocation + (Vector3.forward * dropDistance), 
                    _lastDrop));
        }

        public void SpawnObstacle()
        {
                GameObject dropObject =  Instantiate(
                    obstaclePrefab,
                    (_bikeController.transform.position + dropLocation + (Vector3.forward * dropDistance)), 
                    transform.rotation);
                _lastDrop = dropObject.transform.position;
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
