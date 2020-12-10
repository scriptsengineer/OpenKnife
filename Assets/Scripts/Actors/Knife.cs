using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public bool isPlayer = false;

    private Rigidbody2D m_rigidbody2D;
    private LevelManager levelManager;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        levelManager = GameManager.instance.GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isPlayer) return;

        if(other.tag == "Knife")
        {
            isPlayer = false;
            GetComponent<Mover>().speed = 0f;
            m_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            m_rigidbody2D.AddForceAtPosition(PhysicsUtils.GetRandomForce(128f,256f),Vector3.up);

            levelManager.onKnifeHitOnKnife.Invoke();
            
        }else

        if (other.tag == "Wood")
        {
            gameObject.transform.parent = other.gameObject.transform.parent;
            GetComponent<Mover>().speed = 0f;
            isPlayer = false;

            levelManager.onKnifeHitOnWood.Invoke();
            
        }
        
    }
}