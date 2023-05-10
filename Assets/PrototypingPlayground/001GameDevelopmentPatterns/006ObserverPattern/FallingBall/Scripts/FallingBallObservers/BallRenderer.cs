using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern;
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
            haveWeCollidedWithAnythingYet = FallingBall.haveWeCollidedWithAnythingYet;
            ballRenderer = GetComponent<Renderer>();
            defaultColor = ballRenderer.material.color;
        }

        private void Update()
        {
            if (!haveWeCollidedWithAnythingYet) return;
            DarkenMaterialRender(Time.deltaTime);
        }

        private void DarkenMaterialRender(float time)
        {
            ballRenderer.material.color = Color.Lerp(ballRenderer.material.color, defaultColor, -(degradingSpeed-1)*time);
        }

        public override void Notify(AbstractSubjectBehaviour abstractSubjectBehaviour)
        {
            haveWeCollidedWithAnythingYet = FallingBall.haveWeCollidedWithAnythingYet;

            if (!FallingBall.LastCollision.HaveWeCollidedWithTheSameGameObject)
            {
                ballRenderer.material = FallingBall.LastCollision.Material;
            }
        }
    }
}
