using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class RandomRotator : MonoBehaviour
{
    private Rotator rotator;

    public float timeToChange = 1f;
    public float nextSpeed = 1f;
    private float actualTimer = 0f;
    
    private void Awake()
    {
        rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        //actualTimer+
    }

    // public IEnumerator TimeToChangeSpeed()
    // {
    //     yield return new WaitForSeconds()
    // } 
}