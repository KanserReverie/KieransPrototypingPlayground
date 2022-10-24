using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.AbstractClasses;
using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.FallingBallObservers
{
    [RequireComponent(typeof(Renderer))]
    public class BallRenderer : AbstractFallingBallObserverBehaviour
    {
        [SerializeField][Range(0.8f, 1f)] private float degradingSpeed = 0.9f;
        private bool haveWeCollidedWithAnythingYet;
        private Renderer ballRenderer;
        private Color defaultColor;
        
        private void Start()
        {
            AttachToFallingBallInScene();
            haveWeCollidedWithAnythingYet = fallingBall.haveWeCollidedWithAnythingYet;
            ballRenderer = GetComponent<Renderer>();
            defaultColor = ballRenderer.material.color;
        }

        private void Update()
        {
            if (!haveWeCollidedWithAnythingYet) return;
            DarkenMaterialRender(Time.deltaTime);
        }

        private void DarkenMaterialRender(float _time)
        {
            ballRenderer.material.color = Color.Lerp(ballRenderer.material.color, defaultColor, -(degradingSpeed-1)*_time);
        }

        public override void Notify(AbstractSubjectBehaviour _abstractSubjectBehaviour)
        {
            haveWeCollidedWithAnythingYet = fallingBall.haveWeCollidedWithAnythingYet;

            if (!fallingBall.lastCollision.haveWeCollidedWithTheSameGameObject)
            {
                ballRenderer.material = fallingBall.lastCollision.material;
            }
        }
    }
}
