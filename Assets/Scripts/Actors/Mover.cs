using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed = 1f;

    private void Update()
    {
        transform.position += Vector3.up * (speed * Time.deltaTime);
    }
}