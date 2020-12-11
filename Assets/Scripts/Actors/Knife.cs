using UnityEngine;
using OpenKnife.Utils;
using UnityEngine.Events;

namespace OpenKnife.Actors
{

    public class Knife : MonoBehaviour
    {

        public bool isPlayer = false;

        private Rigidbody2D m_rigidbody2D;
        private ConstantForce2D m_Mover;

        public UnityEvent onCollisionWood;
        public UnityEvent onCollisionKnife;
        public UnityEvent onCollisionFruit;

        private void Awake()
        {
            m_rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void StopPlayerMovement()
        {
            isPlayer = false;
            m_Mover = GetComponent<ConstantForce2D>();
            m_Mover.force = Vector2.zero;
            m_Mover.enabled = false;

            m_rigidbody2D.velocity = Vector2.zero;
            m_rigidbody2D.angularVelocity = 0f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!isPlayer) return;

            if (other.gameObject.tag == "Fruit")
            {
                Destroy(other.gameObject);
                onCollisionFruit?.Invoke();
            }

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isPlayer) return;

            if (other.gameObject.tag == "Knife")
            {
                
                StopPlayerMovement();
                m_rigidbody2D.AddForce(PhysicsUtils.GetRandomForce(32f, 32f), 
                    ForceMode2D.Impulse);
                m_rigidbody2D.gravityScale = 1;
                onCollisionKnife?.Invoke();

            }
            else if (other.gameObject.tag == "Wood")
            {
                m_rigidbody2D.velocity = Vector2.zero;
                m_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                StopPlayerMovement();
                gameObject.transform.parent = other.transform.parent;
                onCollisionWood?.Invoke();

            }
        }
    }
}