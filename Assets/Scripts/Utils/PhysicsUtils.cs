using UnityEngine;

public class PhysicsUtils
{
    
    public static Vector3 GetRandomForce(float min,float max)
    {
        float xForce = Random.Range(min,max);
        if(Random.Range(0,2) == 1) xForce*=-1;
        return new Vector3(xForce,-min,0);
    }
}