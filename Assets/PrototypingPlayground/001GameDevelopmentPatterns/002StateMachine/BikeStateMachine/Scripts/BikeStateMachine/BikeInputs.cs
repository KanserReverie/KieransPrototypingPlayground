using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeInputs : MonoBehaviour
    {
        private BikeController bikeController;

        private void Start()
        {
            bikeController = (BikeController) FindObjectOfType(typeof(BikeController));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow))
            {
                bikeController.StartBike();
            }
            if (Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.DownArrow))
            {
                bikeController.StopBike();
            }
            if (Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.LeftArrow))
            {
                bikeController.TurnBike(Direction.Left);
            }
            if (Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow))
            {
                bikeController.TurnBike(Direction.Right);
            }
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Bike"))
            {
                bikeController.StartBike();
            }
            if (GUILayout.Button("Stop Bike"))
            {
                bikeController.StopBike();
            }
            if(GUILayout.Button("Turn Left"))
            {
                bikeController.TurnBike(Direction.Left);
            }
            if (GUILayout.Button("Turn Right"))
            {
                bikeController.TurnBike(Direction.Right);
            }
        }
    }
}
