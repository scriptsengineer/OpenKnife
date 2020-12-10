using System.Collections;
using UnityEngine;

namespace OpenKnife.Actors
{
    [RequireComponent(typeof(Rotator))]
    public class CurveRotator : MonoBehaviour
    {
        private Rotator rotator;
        private float timer = 0;
        private float m_TimeToResetCurve = 1f;
        private AnimationCurve m_SpeedCurve = new AnimationCurve();
        private float m_SpeedMultiplier = 1f;

        public void Setting(float speedMultiplier,AnimationCurve curve,float time)
        {
            m_SpeedMultiplier = speedMultiplier;
            m_SpeedCurve = curve;
            m_TimeToResetCurve = time;
            timer = 0;
        }

        private void Awake()
        {
            rotator = GetComponent<Rotator>();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if(timer >= m_TimeToResetCurve) timer = 0;
            rotator.speed = m_SpeedCurve.Evaluate(timer/m_TimeToResetCurve)*m_SpeedMultiplier;
        }
   
    }
}