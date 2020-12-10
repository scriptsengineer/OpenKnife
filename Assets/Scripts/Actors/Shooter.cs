using UnityEngine;
using OpenKnife.Managers;

namespace OpenKnife.Gameplay
{
    // Press any button for shoot object
    public class Shooter : MonoBehaviour
    {
        private int shoots = 0;
        [HideInInspector]
        public LevelManager levelManager;

        public ConstantForce2D mover;

        [Range(128f, 512f)]
        public float speedShooter = 256f;

        public int Shoots => shoots;

        public void SetNewShoots(int shoots)
        {
            this.shoots = shoots;
            GameManager.instance.UI.shootsPanel.SetNewShoots(shoots);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (shoots > 0)
                {
                    shoots--;
                    GameManager.instance.UI.shootsPanel.Shoot();
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

