using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnSystem : MonoBehaviour
{
    [SerializeField] private MapData_Scriptable mapDatas;

    [SerializeField] private RectTransform content;

    [SerializeField] private int mapVertiIndex;

    private Vector2 mapInterval;
    private Vector2 startMapPos;
    private Vector2 bossMapPos;

    private HashSet<RectTransform> openHash = new();

    private void Start()
    {
        UIManager.Instance.ResetContent();
        mapInterval = new Vector2(Screen.width / 6, Screen.height / 6);
        startMapPos = new Vector2(0, -Screen.height / 8.5f);
        bossMapPos = new Vector2(0, 6.25f * (startMapPos.y - mapInterval.y));
        MapSpawn();
    }

    [ContextMenu("MapSpawn")]
    public void MapSpawn()
    {
        RectTransform startMap = Instantiate(mapDatas.mapSpawnData.StartMap, content.transform);
        startMap.position = startMapPos;

        for (int verti = 1; verti <= mapDatas.map_Line.MapMaxVertiIndex; verti++)
        {
            int randomHorizonIndex = Random.Range(mapDatas.map_Line.MapHorizonCountMin, mapDatas.map_Line.MapHorizonCountMax);

            for (int horizon = -1; horizon < randomHorizonIndex; horizon++)
            {
                int randomMap = Random.Range(0, mapDatas.mapSpawnData.MapPrefab.Count);

                if (IsFirstVertiIndex())
                {
                    RectTransform battleMap = Instantiate(mapDatas.mapSpawnData.MapPrefab[0], content.transform);
                    battleMap.position = new Vector2(mapInterval.x * horizon, startMapPos.y - (mapInterval.y * verti));
                    openHash.Add(battleMap);
                }
                RectTransform spawnMap = Instantiate(mapDatas.mapSpawnData.MapPrefab[randomMap], content.transform);
                spawnMap.position = new Vector2(mapInterval.x * horizon, (startMapPos.y - mapInterval.y) - (mapInterval.y * verti));
                openHash.Add(spawnMap);
            }
            mapVertiIndex++;
        }
        RectTransform bossMap = Instantiate(mapDatas.mapSpawnData.BossMap, content.transform);
        bossMap.position = bossMapPos;
    }

    [ContextMenu("DestroyMap")]
    public void DestroyAllMap()
    {
        GameObject[] maps = GameObject.FindGameObjectsWithTag("Map");

        foreach (var map in maps)
        {
            Destroy(map);
        }
    }

    private bool IsFirstVertiIndex()
    {
        return mapVertiIndex == 0;
    }
}