using UnityEngine;

namespace OpenKnife.Actors
{
    public class Scorer : MonoBehaviour
    {
        private int score = 0;
        private int fruits = 0;

        public int Score => score;
        public int Fruits => fruits;

        private void Start()
        {
            score = 0;
            fruits = 0;
        }

        public void AddScore(int value)
        {
            if (value < 0) return;
            score += value;
        }

        public void AddFruits(int value)
        {
            if (value < 0) return;
            fruits += value;
        }

        public void ClearScore()
        {
            score = 0;
        }

        public void ClearFruits()
        {
            fruits = 0;
        }
    }
}

