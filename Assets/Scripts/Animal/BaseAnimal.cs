using System.Collections.Generic;
using UnityEngine;
public class BaseAnimal : BaseObject
{
    //属性
    public int Hp; //生命值 0-100
    public int Age; //年龄 0-100
    public int Sex; //性别 1-2
    public int Vision; //视力 1-10
    public int SexReduce; //衰老速度 1-100/s
    public int Hunger; //饥饿度 0-100
    public int HungerConsume; //饥饿消耗 0-100/s
    public int Thirst; //口渴度 0-100
    public int ThirstConsume; //口渴消耗 0-100/s
    public int DesireToMate; //交配欲望 0-100
    public int Speed; //移动速度 0-5s/次 
    public int PhysicalStrength; //体力 0-100
    public int PhysicalStrengthConsume; //体力消耗 0-100/s

    private List<MapTile> openList = new List<MapTile>();
    private List<MapTile> closeList = new List<MapTile>();
    public Transform tr;
    private Vector3 nowPosition;
    private Vector3 nextMovePosition = Vector3.zero;
    
    public BaseAnimal()
    {
        Hp = 100;
        Age = 0;
        Sex = GameFacade.Instance.pseudoRandom.Next(0, 100) < GameFacade.Instance.maleToFemaleRatio ? 1 : 2;
        SexReduce = 10;
        Hunger = 100;
        HungerConsume = 1;
        Thirst = 100;
        ThirstConsume = 1;
        DesireToMate = 0;
        Speed = 4;
        PhysicalStrength = 100;
        PhysicalStrengthConsume = 1;
    }

    private void FixUpdate() {
        if(nextMovePosition != Vector3.zero){
            tr.position = Vector3.MoveTowards(nowPosition, nextMovePosition, Speed * Time.deltaTime);
            if(Vector3.Distance(tr.position, nextMovePosition) < 0.1)
            {
                tr.position = nextMovePosition;
                nextMovePosition = Vector3.zero;
            }
        }
    }

    //每秒消耗
    public void ConsumptionPerSecond(){
        Hunger -= HungerConsume; //饥饿消耗
        Thirst -= ThirstConsume; //口渴消耗
    }
    public void MoveTo(Vector3 position)
    {
        if()
        nowPosition = tr.position;
        nextMovePosition = position;
    }
}

