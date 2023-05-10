using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator.ExampleImplementation.DecoratorScripts;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator.ExampleImplementation
{
    // 1) We made and implemented an interface with values to modify with decorators.
    public class NewPlayer : MonoBehaviour, IPlayerDecoratableVariables
    {
        // These are our base values.
        [SerializeField] private float movementSpeed = 10;
        [SerializeField] private float jumpHeight = 4;
        [SerializeField] private float damage = 2;

        // 2) We added a list of all our decorators.
        public List<IPlayerDecoratableVariables> PlayerDecorators = new List<IPlayerDecoratableVariables>();
        
        // 3) We make sure to get our base values + any decorators we might have.
        public float MovementSpeed { get { return movementSpeed + PlayerDecorators.Sum(playerDecoratableVariables => playerDecoratableVariables.MovementSpeed); } }
        public float JumpHeight { get { return jumpHeight + PlayerDecorators.Sum(playerDecoratableVariables => playerDecoratableVariables.JumpHeight); } }
        public float Damage { get { return damage + PlayerDecorators.Sum(playerDecoratableVariables => playerDecoratableVariables.Damage); } }

        // 4) Everywhere our movementSpeed, jumpHeight and damage is ---> We replace them with:
        // ------- movementSpeed -> MovementSpeed
        // ------- jumpHeight -> JumpHeight
        // ------- damage -> Damage
        
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
            // 4) Changed movementSpeed -> MovementSpeed
            Debug.Log($"Move right = {MovementSpeed} km/h || {this.gameObject.name}", this);
        }

        private void MoveLeft()
        {
            // 4) Changed movementSpeed -> MovementSpeed
            Debug.Log($"Move left = {MovementSpeed} km/h || {this.gameObject.name}", this);
        }

        private void Jump()
        {
            // 4) Changed jumpHeight -> JumpHeight
            Debug.Log($"Jump = {JumpHeight} meters high || {this.gameObject.name}", this);
        }

        private void Attack()
        {
            // 4) Changed damage -> Damage
            Debug.Log($"Attack = {Damage} damage || {this.gameObject.name}", this);
        }

    }
}