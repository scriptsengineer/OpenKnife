using System.Collections.Generic;
using UnityEngine;

namespace OpenKnife.Levels
{
    [CreateAssetMenu(fileName = "New Stage", menuName = "OpenKnife/Stage")]
    public class Stage : ScriptableObject
    {
        [Range(2,12)]
        public int shoots = 7;
        public bool isBoss = false;

        public float timerResetSpeedCurves = 16f;
        public AnimationCurve speedCurves = new AnimationCurve(new Keyframe(0,-1f),new Keyframe(1,1f));
        public float speedMultiplier = 32f;

        [Header("Objects in Level")]
        public List<AngleObject> angleObjects;
    }

    [System.Serializable]
    public struct AngleObject
    {
        [Range(0,359)]
        public int angle;
        public ObjectType objectType;
    }

    [System.Serializable]
    public enum ObjectType
    {
        Fruit,Knife
    }
}

