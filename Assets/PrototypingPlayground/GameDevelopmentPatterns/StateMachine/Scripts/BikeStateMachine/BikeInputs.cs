using UnityEngine;
namespace PrototypingPlayground.GameDevelopmentPatterns.StateMachine.BikeStateMachine
{
    public class BikeInputs : MonoBehaviour
    {
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = (BikeController) FindObjectOfType(typeof(BikeController));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow))
            {
                _bikeController.StartBike();
            }
            if (Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.DownArrow))
            {
                _bikeController.StopBike();
            }
            if (Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _bikeController.TurnBike(Direction.Left);
            }
            if (Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow))
            {
                _bikeController.TurnBike(Direction.Right);
            }
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Bike"))
            {
                _bikeController.StartBike();
            }
            if (GUILayout.Button("Stop Bike"))
            {
                _bikeController.StopBike();
            }
            if(GUILayout.Button("Turn Left"))
            {
                _bikeController.TurnBike(Direction.Left);
            }
            if (GUILayout.Button("Turn Right"))
            {
                _bikeController.TurnBike(Direction.Right);
            }
        }
    }
}
