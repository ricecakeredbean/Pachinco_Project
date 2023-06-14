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

[CreateAssetMenu(fileName = "StageData", menuName = "StageData", order = 0)]
public class StageData : ScriptableObject
{
    public StageSpawnData StageSpawnData;
    [Space]
    public Stage_Line Stage_Line;
}

[System.Serializable]
public class StageSpawnData
{
    [Header("MapPrefab")]
    public List<RectTransform> StagePrefab = new();
    public RectTransform StartStage;
    public RectTransform BossStage;
}

[System.Serializable]
public class StageWeight : WeightRandomData<StageType>
{
}

[System.Serializable]
public class Stage_Line
{
    public int MapHorizonCountMin { get; private set; }
    public int MapHorizonCountMax;

    public int MapMaxVertiIndex;

    [Space]
    public int MinBattleCount;

    [Space]
    public StageWeight[] Weights;
}

[System.Serializable]
public class Node
{
    public StageType stageType;
    public int EventId;
    public int[] EventIds;
}