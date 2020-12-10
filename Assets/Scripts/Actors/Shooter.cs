using UnityEngine;

// Press any button for shoot object
public class Shooter : MonoBehaviour
{
    public int shoots = 0;
    [HideInInspector]
    public LevelManager levelManager;

    public Mover mover;

    [Range(16f,64f)]
    public float speedShooter = 32f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shoots--;
            if(shoots >= 0)
            {
                mover.speed = speedShooter;
            }else
            {
                //enabled = false;
            }
            enabled = false;
            
        }
    }
}