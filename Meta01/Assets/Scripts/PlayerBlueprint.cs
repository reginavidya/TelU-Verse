using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerBlueprint
{
    public string names;
    public int price;
    public bool isUnlocked;

    public PlayerBlueprint(string names, int price, bool isUnlocked)
    {
        this.names = names;
        this.price = price;
        this.isUnlocked = isUnlocked;
    }

    public PlayerBlueprint ReturnClass()
    {
        return new PlayerBlueprint(names, price, isUnlocked);
    }
}
