using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFacade
{
    private static GameFacade instance = null;
    private static readonly object padlock = new object();
    public static GameFacade Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameFacade();
                    }
                }
            }
            return instance;
        }
    }
    public System.Random pseudoRandom;
    public int[,] map;
    public List<MapTile> mapList;
    public int maleToFemaleRatio = 50;
    private GameFacade()
    {
        pseudoRandom = new System.Random(System.DateTime.Now.ToString().GetHashCode());
    }
}
