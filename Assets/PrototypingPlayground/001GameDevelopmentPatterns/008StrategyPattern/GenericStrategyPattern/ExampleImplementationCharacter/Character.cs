using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern.ExampleImplementationCharacter
{
    public class Character : MonoBehaviour
    {
        private Context context;

        private void Start()
        {
            context = GetComponent<Context>();
        }

        private void Update()
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                context.SetStrategy(GetComponent<CharacterConcreteStrategyA>());
            }
            else
            {
                context.SetStrategy(GetComponent<CharacterConcreteStrategyB>());
            }

            context.ExecuteStrategy();
            
            
            // In the above code, ConcreteStrategyA represents walking
            // and moves the character forward at a speed of 5 units per second.
            //
            // ConcreteStrategyB represents running
            // and moves the character forward at a speed of 10 units per second.
            //
            //
            // This allows us to switch between the two movement behaviors dynamically by using the Context class.
            //
            // When the player is not holding down the left shift key,
            // the character will use the ConcreteStrategyA component to move forward at a walking speed.
            //
            // When the player is holding down the left shift key,
            // the character will use the ConcreteStrategyB component to move forward at a running speed.
        }
    }
}