using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator.ExampleImplementation
{
    public class OldPlayer : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 10;
        [SerializeField] private float jumpHeight = 4;
        [SerializeField] private float damage = 2;

        private void Update()
        { 
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }

        private void MoveRight()
        {
            Debug.Log($"Move right = {movementSpeed} km/h || {this.gameObject.name}", this);
        }

        private void MoveLeft()
        {
            Debug.Log($"Move left = {movementSpeed} km/h || {this.gameObject.name}", this);
        }

        private void Jump()
        {
            Debug.Log($"Jump = {jumpHeight} meters high || {this.gameObject.name}", this);
        }

        private void Attack()
        {
            Debug.Log($"Attack = {damage} damage || {this.gameObject.name}", this);
        }

    }
}