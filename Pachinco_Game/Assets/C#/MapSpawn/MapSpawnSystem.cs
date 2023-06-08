using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnSystem : MonoBehaviour
{
    [SerializeField] private MapSpawnData mapSpawndata;

    [SerializeField] private GameObject content;

    private int mapMaxVertiIndex = 8;
    private int mapVertiIndex = 0;
    private int mapMaxHorizonIndex = 4;

    private HashSet<GameObject> openHashSet = new();

    [ContextMenu("MapSpawn")]
    public void MapSpawn()
    {
        UIManager.Instance.ResetContent();
        foreach (var data in mapSpawndata.mapDatasList)
        {
            int randomMap = Random.Range(0, data.MapPrefab.Count - 1);
            int randomHorizonIndex = Random.Range(3, mapMaxHorizonIndex + 1);

            RectTransform startMap = Instantiate(data.StartMap, content.transform);
            startMap.position = data.StartMapPos;

            for (int verti = 0; verti < mapMaxVertiIndex; verti++)
            {
                if (IsFirstVertiIndex())
                {
                    RectTransform battleMap = Instantiate(data.MapPrefab[0], content.transform);
                    battleMap.position = new(battleMap.position.x, data.StartMapPos.y + data.MapVertiInterval);
                }
                for (int horizon = 0; horizon < randomHorizonIndex; horizon++)
                {
                    RectTransform spawnMap = Instantiate(data.MapPrefab[randomMap], content.transform);
                }
                mapVertiIndex++;
            }

            RectTransform bossMap = Instantiate(data.BossMap, content.transform);
            bossMap.position = data.BossMapPos;
        }
    }

    private bool IsFirstVertiIndex()
    {
        return mapVertiIndex == 0;
    }
}
