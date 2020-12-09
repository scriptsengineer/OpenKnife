using UnityEngine;

// Rotate the object
public class Rotator : MonoBehaviour
{
    [Range(-1f,1f)]
    public float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,0,speed * Time.deltaTime);
    }
}
