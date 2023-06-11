using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create News",fileName = "News",order = 1)]

public class News : ScriptableObject
{
    public NewsType newsTyoe;

    public List<Countries> newsOfWhichCountries = new List<Countries>();

    public string newsText;
}
