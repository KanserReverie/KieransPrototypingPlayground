using System;
using UnityEngine;

namespace PrototypingPlayground._003ProjectPrototypes.CodeCampIgnitePlatformer.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Animator thisAnimator;

        private void Start()
        {
            thisAnimator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                thisAnimator.Play("Hero Left Animation");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                thisAnimator.Play("Hero Right Animation");
            }
        }
    }
}
