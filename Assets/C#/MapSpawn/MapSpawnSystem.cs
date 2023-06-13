using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnSystem : MonoBehaviour
{
    [SerializeField] private MapSpawnData mapSpawndata;

    [SerializeField] private RectTransform content;

    private int mapMaxVertiIndex = 8;
    private int mapVertiIndex = 0;
    private int mapMaxHorizonIndex = 4;

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
        foreach (var data in mapSpawndata.mapDatasList)
        {
            RectTransform startMap = Instantiate(data.StartMap, content.transform);
            startMap.position = startMapPos;

            for (int verti = 1; verti <= mapMaxVertiIndex; verti++)
            {
                int randomHorizonIndex = Random.Range(2, mapMaxHorizonIndex);

                for (int horizon = -1; horizon < randomHorizonIndex; horizon++)
                {
                    int randomMap = Random.Range(0, data.MapPrefab.Count);

                    if (IsFirstVertiIndex())
                    {
                        RectTransform battleMap = Instantiate(data.MapPrefab[0], content.transform);
                        battleMap.position = new Vector2(mapInterval.x * horizon, startMapPos.y - (mapInterval.y * verti));
                        openHash.Add(battleMap);
                    }
                    RectTransform spawnMap = Instantiate(data.MapPrefab[randomMap], content.transform);
                    spawnMap.position = new Vector2(mapInterval.x * horizon, (startMapPos.y - mapInterval.y) - (mapInterval.y * verti));
                    openHash.Add(spawnMap);
                }
                mapVertiIndex++;
            }
            RectTransform bossMap = Instantiate(data.BossMap, content.transform);
            bossMap.position = bossMapPos;
        }
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