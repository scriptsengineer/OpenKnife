using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage", menuName = "OpenKnife/Stage")]
public class Stage : ScriptableObject
{
    [Range(2,12)]
    public int shoots = 7;
    public bool boss = false;
    public float initialSpeed = 1f;
    
    public List<SpeedTimer> speedTimers;

    [Header("Objects in Level")]
    public List<AngleObject> angleObjects;
}

public struct SpeedTimer
{
    public float speed;
    public float timer;
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