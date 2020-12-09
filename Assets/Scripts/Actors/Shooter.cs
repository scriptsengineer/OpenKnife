using UnityEngine;

// Press any button for shoot object
public class Shooter : MonoBehaviour
{
    public int shoots = 0;
    [HideInInspector]
    public LevelManager levelManager;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            shoots--;
            if(shoots <= 0)
            {
                enabled = false;
            }
        }
    }
}