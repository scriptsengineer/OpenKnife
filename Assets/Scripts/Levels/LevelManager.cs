using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OpenKnife.Actors;
using OpenKnife.States;
using OpenKnife.UI;

namespace OpenKnife.Levels
{
    public class LevelManager : MonoBehaviour, GameStates
    {
        #region Public variables
        [Header("Levels")]
        public Stage[] stages;

        [Header("Prefabs")]
        public GameObject applePrefab;
        public GameObject knifePrefab;
        public GameObject woodParticle;
        public GameObject fruitsParticle;

        [Header("References")]
        public GameObject player;
        public GameObject wood;
        public Transform spawnShooter;


        [Header("Events")]
        public UnityEvent onKnifeHitOnWood;
        public UnityEvent onKnifeHitOnKnife;
        public UnityEvent onScore;
        public UnityEvent onFruitSlice;
        public UnityEvent onStageInit;
        public UnityEvent onStageFinish;
        public UnityEvent onShoot;

        #endregion

        #region Private variables
        private List<GameObject> objectsInWood = new List<GameObject>();
        private CurveRotator rotator;
        private Shooter shooter;
        private int actualStage = -1;
        private Scorer scorer;
        #endregion

        private void Awake()
        {
            CheckAndGetInternalReferences();
            shooter.m_ShootEvent.AddListener(delegate
            {
                onShoot.Invoke();
            });
        }

        private void Start()
        {
            InitBuiltInEvents();
        }

        #region Game States events
        public void MainMenu(GameState newState, GameState oldState)
        {
            if (oldState == GameState.IN_GAME)
            {
                Clear();
            }
        }

        public void StartGame(GameState newState, GameState oldState)
        {
            actualStage = -1;
            Next();
        }

        public void GameOver(GameState newState, GameState oldState)
        {
            Clear();
        }
        #endregion

        #region Private Methods
        private IEnumerator StartGameOver()
        {
            yield return new WaitForSeconds(1f);
            GameManager.instance.GameOver();
        }

        private IEnumerator StartLevel()
        {
            onStageInit.Invoke();
            yield return new WaitForSeconds(1f);
            RequestNewShoot();
        }

        private void CheckAndGetInternalReferences()
        {
            // NOTE
            // Here it has been tested to pick up components in a different 
            // way using 'TryGetComponent'
            bool check = wood.TryGetComponent<CurveRotator>(out rotator);
            if (!check) Debug.LogError("Wood must have a rotator!");

            check = player.TryGetComponent<Shooter>(out shooter);
            if (!check) Debug.LogError("Player must have a shooter!");

            check = player.TryGetComponent<Scorer>(out scorer);
            if (!check) Debug.LogError("Player must have a scorer!");
        }

        private void InitBuiltInEvents()
        {
            onKnifeHitOnKnife.AddListener(delegate
            {
                StartCoroutine(StartGameOver());
            });
            onKnifeHitOnWood.AddListener(delegate
            {
                RequestNewShoot();

                GameObject go = Instantiate(woodParticle, Vector3.down * 1.5f, Quaternion.identity);
                Destroy(go, 1f);

                scorer.AddScore(1);
                onScore.Invoke();
            });
            onFruitSlice.AddListener(delegate
            {
                scorer.AddScore(2);
                onScore.Invoke();

                GameObject go = Instantiate(fruitsParticle, Vector3.down * 1.5f, Quaternion.identity);
                Destroy(go, 1f);

                scorer.AddFruits(1);
                UIManager.instance.UpdateFruitsText(scorer.Fruits);
            });
            onScore.AddListener(delegate
            {
                UIManager.instance.UpdateScoreText(scorer.Score);
            });

            onStageInit.AddListener(delegate
            {
                UIManager.instance.UpdateStageTitleText(actualStage);
            });
            onStageFinish.AddListener(delegate
            {
                UIManager.instance.stageTitle.gameObject.SetActive(false);
            });

            onShoot.AddListener(delegate
            {
                UIManager.instance.shootsPanel.Shoot();
            });
        }

        // Prepare for next shooter
        private void PrepareNextShoot()
        {
            GameObject go = Instantiate(knifePrefab, spawnShooter.position, spawnShooter.rotation);
            ConstantForce2D mover = go.AddComponent<ConstantForce2D>();
            mover.force = Vector2.zero;
            Knife knife = go.GetComponent<Knife>();
            knife.isPlayer = true;
            knife.onCollisionWood.AddListener(delegate{onKnifeHitOnWood.Invoke();});
            knife.onCollisionKnife.AddListener(delegate{onKnifeHitOnKnife.Invoke();});
            knife.onCollisionFruit.AddListener(delegate{onFruitSlice.Invoke();});
            objectsInWood.Add(go);
            shooter.mover = mover;
            shooter.enabled = true;
        }

        // Clear all objects in stage
        private void Clear()
        {
            foreach (GameObject go in objectsInWood)
            {
                Destroy(go);
            }
            objectsInWood.Clear();
        }

        // Loads next shot, checking that no more shots passes to next stage
        private void RequestNewShoot()
        {
            if (shooter.Shoots > 0)
            {
                PrepareNextShoot();
            }
            else
            {
                onStageFinish.Invoke();
                Clear();
                Next();
            }
        }

        // Calls next stage, also checking if this level is available to load.
        private void Next()
        {
            actualStage++;
            UIManager.instance.UpdateStageText(actualStage);
            if (stages.Length <= actualStage)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                Setting(stages[actualStage]);
            }
        }

        // Setting level
        // Set initial speed
        // Spawn objects in the wood
        // Set levels speed
        // Set shoots
        private void Setting(Stage stage)
        {
            rotator.Setting(stage.speedMultiplier,stage.speedCurves,stage.timerResetSpeedCurves);
            shooter.SetNewShoots(stage.shoots);

            foreach (AngleObject ao in stage.angleObjects)
            {
                GameObject prefab = ao.objectType == ObjectType.Knife ? knifePrefab : applePrefab;
                GameObject go = Instantiate(prefab,
                    wood.transform.position,
                    Quaternion.identity,
                    wood.transform);
                // FIXME Don' use hardcoded, use collider size!.
                go.transform.position += Vector3.down * 2f;
                go.transform.RotateAround(transform.position, wood.transform.forward, ao.angle);
                objectsInWood.Add(go);
                go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }

            StartCoroutine(StartLevel());

        }
        #endregion
    }
}

