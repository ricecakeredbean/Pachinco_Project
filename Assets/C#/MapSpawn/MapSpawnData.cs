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
    [Header("MapPrefab")]
    public List<RectTransform> MapPrefab = new();
    public RectTransform StartMap;
    public RectTransform BossMap;

    [Header("MapPos")]
    public Vector2 StartMapPos;
    public Vector2 BossMapPos;
}
