using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

public class MapSpawnSystem : MonoBehaviour
{
    [SerializeField] private StageData stageDatas;

    [SerializeField] private RectTransform content;

    private int stageVertiIndex = 0;

    private Vector2 stageInterval;
    private Vector2 startStagePos;
    private Vector2 bossStagePos;

    private HashSet<RectTransform> openHash = new();

    private void Start()
    {
        UIManager.Instance.ResetContent();
        stageInterval = new Vector2(Screen.width / 6, Screen.height / 6);
        startStagePos = new Vector2(0, -Screen.height / 8.5f);
        bossStagePos = new Vector2(0, 6.25f * (startStagePos.y - stageInterval.y));
        MapSpawn();
    }

    [ContextMenu("MapSpawn")]
    public void MapSpawn()
    {
        RectTransform startMap = Instantiate(stageDatas.StageSpawnData.StartStage, content.transform);
        startMap.position = startStagePos;

        for (int verti = 1; verti <= stageDatas.Stage_Line.MapMaxVertiIndex; verti++)
        {
            int randomHorizonIndex = Random.Range(stageDatas.Stage_Line.MapHorizonCountMin, stageDatas.Stage_Line.MapHorizonCountMax);

            for (int horizon = -1; horizon < randomHorizonIndex; horizon++)
            {
                if (IsFirstVertiIndex())
                {
                    RectTransform battleMap = Instantiate(stageDatas.StageSpawnData.StagePrefab[0], content.transform);
                    battleMap.position = new Vector2(stageInterval.x * horizon, startStagePos.y - (stageInterval.y * verti));
                    openHash.Add(battleMap);
                }
                RectTransform stageNode = stageDatas.StageSpawnData.StagePrefab[Utill.WeightRandomToInt(stageDatas.Stage_Line.Weights)];
                RectTransform spawnMap = Instantiate(stageNode, content.transform);
                spawnMap.position = new Vector2(stageInterval.x * horizon, (startStagePos.y - stageInterval.y) - (stageInterval.y * verti));
                openHash.Add(spawnMap);
            }
            stageVertiIndex++;
        }
        RectTransform bossMap = Instantiate(stageDatas.StageSpawnData.BossStage, content.transform);
        bossMap.position = bossStagePos;
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
        return stageVertiIndex == 0;
    }
}