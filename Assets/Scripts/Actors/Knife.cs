using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public bool isPlayer = false;


    private Rigidbody2D m_rigidbody2D;


    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isPlayer) return;

        if(other.tag == "Knife")
        {
            StartCoroutine(StartGameOver());
            isPlayer = false;
            GetComponent<Mover>().speed = 0f;
            m_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            m_rigidbody2D.AddForce(GetRandomForce(),ForceMode2D.Impulse);
            
        }else

        if (other.tag == "Wood")
        {
            gameObject.transform.parent = other.gameObject.transform.parent;
            GetComponent<Mover>().speed = 0f;

            GameManager.instance.GetComponent<LevelManager>().RequestNewShoot();
            isPlayer = false;
        }
        
    }

    public IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.GameOver();
    }

    public static Vector3 GetRandomForce()
    {
        float xForce = Random.Range(4f,8f);
        if(Random.Range(0,2) == 1) xForce*=-1;
        return new Vector3(xForce,-1,0);
    }
}