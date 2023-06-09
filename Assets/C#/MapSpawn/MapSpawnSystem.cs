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

    private HashSet<RectTransform> openHashSet = new();

    private void Start()
    {
        MapSpawn();
    }

    [ContextMenu("MapSpawn")]
    public void MapSpawn()
    {
        UIManager.Instance.ResetContent();
        Debug.Log(new Vector2(Screen.width / 6, content.sizeDelta.y / 9));
        foreach (var data in mapSpawndata.mapDatasList)
        {
            RectTransform startMap = Instantiate(data.StartMap, content.transform);
            startMap.position = data.StartMapPos;

            Vector2 mapInterval = new Vector2(Screen.width / 6, content.sizeDelta.y / 9);

            for (int verti = 1; verti <= mapMaxVertiIndex; verti++)
            {
                int randomHorizonIndex = Random.Range(3, mapMaxHorizonIndex + 1);
                int randomMap = Random.Range(0, data.MapPrefab.Count);

                for (int horizon = 1; horizon <= randomHorizonIndex; horizon++)
                {
                    if (IsFirstVertiIndex())
                    {
                        RectTransform battleMap = Instantiate(data.MapPrefab[0], content.transform);
                        battleMap.position = new Vector2(/*battleMap.position.x - data.MapInterval.width * horizon, data.StartMapPos.y - data.MapInterval.height * verti*/mapInterval.x * -horizon, mapInterval.y * -verti);
                    }
                    RectTransform spawnMap = Instantiate(data.MapPrefab[randomMap], content.transform);
                    spawnMap.position = new Vector2(/*spawnMap.position.x - data.MapInterval.width * horizon, -data.StartMapPos.y - (data.MapInterval.height * (verti + 1))*/mapInterval.x * -horizon, mapInterval.y * -verti);
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
