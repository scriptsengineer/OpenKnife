using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour,GameStates
{
    public Level[] levels;

    public GameObject applePrefab;
    public GameObject knifePrefab;

    private List<GameObject> objectsInWood;

    public GameObject player;
    public GameObject wood;

    public Transform spawnShooter;

    private Rotator rotator;
    private Shooter shooter;

    private int actualLevel = -1;

    private void Awake()
    {
        rotator = wood.GetComponent<Rotator>();
        if(!rotator) Debug.Log("Wood deve ter um rotator!");

        shooter = player.GetComponent<Shooter>();
        if(!shooter) Debug.Log("Player deve ter um shooter!");

        shooter.levelManager = this;
    }

    // Clear all objects in level
    public void Clear()
    {
        foreach(GameObject go in objectsInWood)
        {
            Destroy(go);
        }
        objectsInWood.Clear();
    }

    // Setting level
    // Set initial speed
    // Spawn objects in the wood
    // Set levels speed
    // Set shoots
    public void Setting(Level level)
    {
        rotator.speed = level.initialSpeed;
        shooter.shoots = level.shoots;

        if(level.angleObjects.Count <=0) return;

        foreach(AngleObject ao in level.angleObjects)
        {
            GameObject prefab = ao.objectType == ObjectType.Knife ? knifePrefab : applePrefab;
            Instantiate(prefab,wood.transform);
        }

        StartLevel();

    }

    public void StartLevel()
    {
        shooter.enabled = true;
        PrepareNextShoot(spawnShooter);
    }

    // Prepare for next shooter
    public void PrepareNextShoot(Transform spawner)
    {
        GameObject go = Instantiate(knifePrefab,spawner.position,spawner.rotation);
    }

    public void MainMenu(GameState newState, GameState oldState)
    {
        
    }

    public void StartGame(GameState newState, GameState oldState)
    {
        actualLevel = -1;
        NextLevel();
    }

    public void GameOver(GameState newState, GameState oldState)
    {
        
    }

    public void NextLevel()
    {
        actualLevel++;
        Setting(levels[actualLevel]);
    }
}