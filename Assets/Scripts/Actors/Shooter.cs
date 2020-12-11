using UnityEngine;
using OpenKnife;
using OpenKnife.UI;
using UnityEngine.Events;

namespace OpenKnife.Actors
{

    [System.Serializable]
    public class ShootEvent : UnityEvent<int>
    {
    }

    // Press any button for shoot object
    public class Shooter : MonoBehaviour
    {
        private int shoots = 0;
        public ShootEvent m_ShootEvent = new ShootEvent();

        public ConstantForce2D mover;

        [Range(128f, 512f)]
        public float speedShooter = 256f;

        public int Shoots => shoots;

        public void SetNewShoots(int shoots)
        {
            this.shoots = shoots;
            UIManager.instance.shootsPanel.SetNewShoots(shoots);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (shoots > 0)
                {
                    shoots--;
                    m_ShootEvent?.Invoke(shoots);
                    mover.force = Vector2.up * speedShooter;
                }
                enabled = false;

            }
        }
    }
}

