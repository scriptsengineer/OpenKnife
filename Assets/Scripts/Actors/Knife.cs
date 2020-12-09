using UnityEngine;

public class Knife : MonoBehaviour
{

    public bool isPlayer = false;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isPlayer) return;

        if (other.tag == "Wood")
        {
            gameObject.transform.parent = other.gameObject.transform;
            //gameObject.tag = "Knife";
            GetComponent<Mover>().speed = 0f;
            isPlayer = false;

            GameManager.instance.GetComponent<LevelManager>().RequestNewShoot();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.GameOver();
        isPlayer = false;
    }
}