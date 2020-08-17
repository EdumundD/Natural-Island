using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Land,
    Water
}
public class MapTile
{
    public int X;
    public int Z;
    public TileType type;
    public GameObject go;

    public MapTile(int posX, int posZ, int type)
    {
        X = posX;
        Z = posZ;
        this.type = (TileType)type;
        if ((TileType)type == TileType.Land)
            go = (GameObject)GameObject.Instantiate(Resources.Load("Cubes/Prefabs/Tiling/Earth"), new Vector3(posX, 0, posZ),
            Quaternion.identity, GameObject.Find("GameObject").transform.Find("Plane"));
        else if ((TileType)type == TileType.Water)
            go = (GameObject)GameObject.Instantiate(Resources.Load("Cubes/Prefabs/Tiling/Crystal"), new Vector3(posX, 0, posZ),
            Quaternion.identity, GameObject.Find("GameObject").transform.Find("Plane"));
    }
}
