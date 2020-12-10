using UnityEngine;
using OpenKnife.Managers;
using OpenKnife.Utils;

namespace OpenKnife.Gameplay
{

    public class Knife : MonoBehaviour
    {

        public bool isPlayer = false;

        private Rigidbody2D m_rigidbody2D;
        private LevelManager m_LevelManager;
        private ConstantForce2D m_Mover;

        private void Awake()
        {
            m_rigidbody2D = GetComponent<Rigidbody2D>();
            m_LevelManager = GameManager.instance.GetComponent<LevelManager>();
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
                
                m_LevelManager.onFruitSlice.Invoke();
                Destroy(other.gameObject);

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
                m_LevelManager.onKnifeHitOnKnife.Invoke();
                m_rigidbody2D.gravityScale = 1;

            }
            else if (other.gameObject.tag == "Wood")
            {
                m_rigidbody2D.velocity = Vector2.zero;
                m_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                StopPlayerMovement();
                gameObject.transform.parent = other.transform.parent;
                m_LevelManager.onKnifeHitOnWood.Invoke();

            }
        }
    }
}