using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    int[,] map;
    List<MapTile> mapList;

    [Range(0, 100)]
    public int probability;

    [Range(0, 10)]
    public int smoothCount;

    public int width;
    public int height;
    //种子
    public string seed;
    //是否要使用随机种子
    public bool useRandomSeed;
    void Start()
    {
        mapList = new List<MapTile>();
        map = new int[width, height];
        RandomFillMap();
        for (int i = 0; i < smoothCount; i++)
        {
            SmoothMap();
        }
        CreateMapTile();
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
            seed = DateTime.Now.ToString();
        System.Random pseudoRandom = new System.Random(seed.GetHashCode());
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0 || i == width - 1 || j == 0 || j == height - 1)  //边缘是水
                    map[i, j] = 1;
                else
                    map[i, j] = (pseudoRandom.Next(0, 100) < probability) ? 1 : 0;  //1是水，0是空地, 2是食物, 3是树木
            }
        }
    }
    int GetSurroundingWaters(int posX, int posY)
    {
        int waterCount = 0;
        for (int i = posX - 1; i <= posX + 1; i++)
        {
            for (int j = posY - 1; j <= posY + 1; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    if (i != posX || i != posY)
                        waterCount += map[i, j];
                }
                else
                {
                    waterCount++;
                }
            }
        }
        return waterCount;
    }
    void SmoothMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int surroundingTiles = GetSurroundingWaters(i, j);
                if (surroundingTiles > 4)
                    map[i, j] = 1;
                else
                    map[i, j] = 0;
            }
        }
    }

    void CreateMapTile()
    {
        if (map != null)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    mapList.Add(new MapTile(i, j, map[i, j]));
                }
            }
        }
        GameFacade.Instance.map = map;
        GameFacade.Instance.mapList = mapList;
    }
    void OnDrawGizmos()
    {
        // if (map != null)
        // {
        //     for (int i = 0; i < height; i++)
        //     {
        //         for (int j = 0; j < width; j++)
        //         {
        //             Gizmos.color = map[i, j] == 1 ? Color.black : Color.white; //黑色代表水，白色代表陆地
        //             Vector3 pos = new Vector3(-width / 2 + i + .5f, 0, -height / 2 + j + .5f);
        //             Gizmos.DrawCube(pos, Vector3.one);
        //         }
        //     }
        // }
    }
}
