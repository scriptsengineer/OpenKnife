using UnityEngine;
using UnityEngine.UI;

namespace OpenKnife.Utils
{
    public class FPSStat : MonoBehaviour
    {

        [Range(0.1f,1f)]
        public float UpdateInterval = 0.5f;

        public Text _infoFPS;
        public Text _infoMS;

        private float m_AccumulatedTime = 0f;
        private int m_AccumulatedFrames = 0;
        private float m_LastUpdateTime;
        private float m_FrameTime = 0f;
        private float m_FrameRate = 0f;

        public static float MinTime = 0.000000001f;

        private void Update()
        {
            float deltaTime = Time.unscaledDeltaTime;

            m_AccumulatedTime += deltaTime;
            m_AccumulatedFrames++;

            float nowTime = Time.realtimeSinceStartup;
            if (nowTime - m_LastUpdateTime < UpdateInterval) {
                return;
            }

            m_FrameTime = m_AccumulatedTime / m_AccumulatedFrames;
            m_FrameRate = 1.0f / m_FrameTime;

            UpdateInfo();

            ResetProbingData();
            m_LastUpdateTime = nowTime;
        }


        private void UpdateInfo()
        {
            _infoFPS.text = string.Format(
                "{0}"+" FPS ",
                m_FrameRate.ToString("F0"));

            _infoMS.text = string.Format(
                "{0}"+" MS ",
                (m_FrameTime*1000f).ToString("F1"));
        }

        
        private void ResetProbingData() {
            m_AccumulatedTime = 0.0f;
            m_AccumulatedFrames = 0;
        }

        private void Reset()
        {
            m_LastUpdateTime = Time.realtimeSinceStartup;
        }

        
    }
}