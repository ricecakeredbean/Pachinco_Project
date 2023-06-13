using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    Start,
    Battle,
    Store,
    Treasure,
    Boss
}

[CreateAssetMenu(fileName = "MapData", menuName = "MapData")]
public class MapData_Scriptable : ScriptableObject
{
    public MapSpawnData mapSpawnData;
    [Space]
    public Map_Line map_Line;
}

[System.Serializable]
public class MapSpawnData
{
    [Header("MapPrefab")]
    public List<RectTransform> MapPrefab = new();
    public RectTransform StartMap;
    public RectTransform BossMap;
}

[System.Serializable]
public class WeightRandom
{
    public StageType StageType;
    public int Weight;
}

[System.Serializable]
public class Map_Line
{
    public int MapHorizonCountMin { get; private set; }
    public int MapHorizonCountMax;

    public int MapMaxVertiIndex;

    [Space]
    public int MinBattleCount;

    [Space]
    public WeightRandom[] Weights;
}

[System.Serializable]
public class Node
{
    public StageType stageType;
    public int EventId;
    public int[] EventIds;
}