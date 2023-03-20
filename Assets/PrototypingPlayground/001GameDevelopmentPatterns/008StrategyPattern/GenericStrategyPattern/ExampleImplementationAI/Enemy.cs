using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern.ExampleImplementationAI
{
    public class Enemy : MonoBehaviour
    {
        private Context context;

        private void Start()
        {
            context = GetComponent<Context>();
        }

        private void Update()
        {
            // This shows how the AI would execute a different algorithm based on distance to the player.
            // The algorithm (strategy/AI Behaviour) wouldn't change itself outcome itself.
            
            Vector3 playerLocation = Vector3.zero; // playerLocation = PlayerController.Instance.transform.position
            float playerDistance = Vector3.Distance(transform.position, playerLocation);

            if (playerDistance < 5f)
            {
                context.SetStrategy(GetComponent<ConcreteStrategyA>());
            }
            else if (playerDistance < 10f)
            {
                context.SetStrategy(GetComponent<ConcreteStrategyB>());
            }

            context.ExecuteStrategy();
        }
    }
}