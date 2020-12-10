using UnityEngine;
using OpenKnife.Managers;

namespace OpenKnife.Gameplay
{
    // Press any button for shoot object
    public class Shooter : MonoBehaviour
    {
        public int shoots = 0;
        [HideInInspector]
        public LevelManager levelManager;

        public ConstantForce2D mover;

        [Range(128f, 512f)]
        public float speedShooter = 256f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                shoots--;
                if (shoots >= 0)
                {
                    mover.force = Vector2.up * speedShooter;
                }
                else
                {
                    //enabled = false;
                }
                enabled = false;

            }
        }
    }
}

