﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptBoardCorner : MonoBehaviour {

    public PlayerData owner = null;
    public bool roadUp;
    public List<ScriptBoardHex> adjacentHexes = new List<ScriptBoardHex>(0);
    public List<ScriptBoardEdge> adjacentRoads = new List<ScriptBoardEdge>(0);
    public Time time;


    public bool CheckValidBuild(GameObject player)
    {
        Debug.Log("Checking Valid Build");
        foreach(ScriptBoardEdge road in adjacentRoads)
        {
            if (road.owner == player.GetComponent<PlayerData>())
            {
                owner = player.GetComponent<PlayerData>();
                return true;
            }
        }
        return false;
    }

    public void GainResources(int checkValue)
    {
        foreach (ScriptBoardHex hex in adjacentHexes)
        {
            if (hex.hexDieValue == checkValue)
            {
                switch(hex.resource)
                {
                    case HexType.BRICK:
                        owner.ChangeBrick(1);
                        break;
                    case HexType.GRAIN:
                        owner.ChangeGrain(1);
                        break;
                    case HexType.WOOD:
                        owner.ChangeWood(1);
                        break;
                    case HexType.WOOL:
                        owner.ChangeWool(1);
                        break;
                }
            }
        }
    }
}
