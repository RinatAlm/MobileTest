using System.Collections.Generic;
using UnityEngine;

public class MatchTableUIManager : MonoBehaviour
{
    public List<MatchTabUI> matchTabs = new List<MatchTabUI>();

    public void Init()
    {
        foreach(MatchTabUI matchTab in matchTabs)
        {
            matchTab.Init();
        }
    }
    public void OnPicked(AnimalShapeData animalShapeData)
    {
        SearchForMatch();
    }
    public void SearchForMatch()
    {
        Debug.Log("Searching for match");
    }
}
