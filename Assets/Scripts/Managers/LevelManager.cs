using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OpenKnife.Gameplay;

namespace OpenKnife.Managers
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

        #endregion

        #region Private variables
        private List<GameObject> objectsInWood = new List<GameObject>();
        private Rotator rotator;
        private Shooter shooter;
        private int actualLevel = -1;
        private Scorer scorer;
        #endregion

        private void Awake()
        {
            CheckAndGetInternalReferences();
            shooter.levelManager = this;
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
            actualLevel = -1;
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
            yield return new WaitForSeconds(1f);
            RequestNewShoot();
        }

        private void CheckAndGetInternalReferences()
        {
            // NOTE
            // Here it has been tested to pick up components in a different 
            // way using 'TryGetComponent'
            bool check = wood.TryGetComponent<Rotator>(out rotator);
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
                GameManager.instance.uIManager.UpdateFruits(scorer.Fruits);
            });
            onScore.AddListener(delegate
            {
                GameManager.instance.uIManager.UpdateScoreText(scorer.Score);
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
            if (shooter.shoots > 0)
            {
                PrepareNextShoot();
            }
            else
            {
                Clear();
                Next();
            }
        }

        // Calls next stage, also checking if this level is available to load.
        private void Next()
        {
            actualLevel++;
            GameManager.instance.uIManager.UpdateStageText(actualLevel);
            if (stages.Length <= actualLevel)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                Setting(stages[actualLevel]);
            }
        }

        // Setting level
        // Set initial speed
        // Spawn objects in the wood
        // Set levels speed
        // Set shoots
        private void Setting(Stage stage)
        {
            rotator.speed = stage.initialSpeed;
            shooter.shoots = stage.shoots;

            if (stage.angleObjects.Count <= 0) return;

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

