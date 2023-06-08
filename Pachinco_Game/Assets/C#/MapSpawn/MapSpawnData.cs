using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSpawnData", menuName = "MapSpawnData", order = 0)]
public class MapSpawnData : ScriptableObject
{
    public List<MapData> mapDatasList = new();
}

[System.Serializable]
public class MapData
{
    [Header("Interval")]
    public float MapVertiInterval;
    public float MapHorizonInterval;

    [Header("MapPrefab")]
    public List<RectTransform> MapPrefab = new();
    public RectTransform StartMap;
    public RectTransform BossMap;

    [Header("MapPos")]
    public Vector2 StartMapPos;
    public Vector2 BossMapPos;

    public MapData(float mapVertiInterval, float mapHorizonInterval, List<RectTransform> mapPrefab, RectTransform startMap, RectTransform bossMap)
    {
        MapVertiInterval = mapVertiInterval;
        MapHorizonInterval = mapHorizonInterval;
        MapPrefab = mapPrefab;
        StartMap = startMap;
        BossMap = bossMap;
    }
}
