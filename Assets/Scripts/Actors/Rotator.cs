using UnityEngine;

// Rotate the object
public class Rotator : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,0,speed * Time.deltaTime);
    }
}
