using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour,GameStates
{
    #region Public variables
    [Header("Levels")]
    public Stage[] stages;

    [Header("Prefabs")]
    public GameObject applePrefab;
    public GameObject knifePrefab;

    [Header("References")]
    public GameObject player;
    public GameObject wood;
    public Transform spawnShooter;
    #endregion

    private List<GameObject> objectsInWood = new List<GameObject>();
    private Rotator rotator;
    private Shooter shooter;
    //private Mover knifeToShoot;
    private int actualLevel = -1;


    public UnityEvent onKnifeHitOnWood;
    public UnityEvent onKnifeHitOnKnife;

    private void Start()
    {
        onKnifeHitOnKnife.AddListener(delegate
        {
            StartCoroutine(StartGameOver());
        });
        onKnifeHitOnWood.AddListener(delegate
        {
            RequestNewShoot();
        });
    }

    public IEnumerator StartGameOver()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.GameOver();
    }

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
    public void Setting(Stage stage)
    {
        rotator.speed = stage.initialSpeed;
        shooter.shoots = stage.shoots;

        if(stage.angleObjects.Count <=0) return;

        foreach(AngleObject ao in stage.angleObjects)
        {
            GameObject prefab = ao.objectType == ObjectType.Knife ? knifePrefab : applePrefab;
            GameObject go = Instantiate(prefab,
                wood.transform.position,
                Quaternion.identity,
                wood.transform);
                // TODO diminuir do tamanho do objeto.
            go.transform.position+=Vector3.up*2.4f;
            objectsInWood.Add(go);
        }

        StartCoroutine(StartLevel());

    }

    public IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(1f);
        RequestNewShoot();
    }

    
    public void RequestNewShoot()
    {
        if(shooter.shoots > 0)
        {
            PrepareNextShoot();
        }
        else
        {
            Clear();
            Next();
        }
    }

    // Prepare for next shooter
    public void PrepareNextShoot()
    {

        GameObject go = Instantiate(knifePrefab,spawnShooter.position,spawnShooter.rotation);
        Mover mover = go.AddComponent<Mover>();
        mover.speed = 0;
        Knife knife = go.GetComponent<Knife>();
        knife.isPlayer = true;

        objectsInWood.Add(go);

        shooter.mover = mover;
        
        shooter.enabled = true;
    }

    #region Game States events
    public void MainMenu(GameState newState, GameState oldState)
    {
        if(oldState == GameState.IN_GAME)
        {
            Clear();
        }
    }

    public void StartGame(GameState newState, GameState oldState)
    {
        actualLevel = -1;
        Next();
    }

    public void GameOver(GameState newState, GameState oldState)
    {
        Clear();
    }
    #endregion

    public void Next()
    {
        actualLevel++;
        GameManager.instance.uIManager.UpdateStageText(actualLevel);
        if(stages.Length <= actualLevel)
        {
            GameManager.instance.GameOver();
        }
        else
        {
            Setting(stages[actualLevel]);
        }
        
    }
}