using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchTableUIManager : MonoBehaviour
{
    public int maxPairsCount;
    public List<MatchTabUI> matchTabs = new List<MatchTabUI>();
    public Action onGameLost;
    public Action onGameWon;
    public GameObject explosionPrefab;
    public void Init()
    {
        foreach(MatchTabUI matchTab in matchTabs)
        {
            matchTab.Init();
        }
    }
    public void OnPicked(AnimalShapeData animalShapeData)
    {
        foreach (MatchTabUI matchTab in matchTabs)
        {
            if (matchTab.animalShapeData == null)
            {
                matchTab.SetAnimalShapeData(animalShapeData);
                break;
            }
        }

        StartMatchingCoroutine();
    }

    private void StartMatchingCoroutine()
    {
        MatchCheck();
        LoseCheck();
        WinCheck();
    }

    int pairMatchCount = 0;
    public bool MatchCheck()
    {
        int count = 1;
        List<MatchTabUI> streakMatchTabs = new List<MatchTabUI>();
        AnimalShapeData animalShapeData = null;
        foreach (MatchTabUI matchTab in matchTabs)
        {
            //Select 1 animal
            if(animalShapeData == null)
            {
                animalShapeData = matchTab.animalShapeData;
                streakMatchTabs.Add(matchTab);
            }
            else if(matchTab.animalShapeData == null)
            {
                //End of filled animal shapes
                break;
            }
            else if (animalShapeData.Compare(matchTab.animalShapeData))
            {
                streakMatchTabs.Add(matchTab);
                count++;
            }
            else
            {
                streakMatchTabs.Clear();
                animalShapeData = matchTab.animalShapeData;
                streakMatchTabs.Add(matchTab);
                count = 1;
            }

            //Check is match is possible
            if(count == 3)
            {
                Debug.Log("Match");
                foreach (MatchTabUI tab in streakMatchTabs)
                {
                    Instantiate(explosionPrefab, tab.transform.position, Quaternion.identity);
                    tab.SetAnimalShapeData(null);
                }
                streakMatchTabs.Clear();
                pairMatchCount++;
                return MatchCheck();
            }
        }
        return false;
    }

    public bool ComposeMatchTabs()
    {
        //Iterate through match tabs
        //Select first tab with null data
        //Iterate further until non null data is met
        //Put data into null tab, update UI
        //Repeat the process until there is no match tabs left

        MatchTabUI destinationMatchTab = null;
        MatchTabUI originMatchTab = null;
        foreach(MatchTabUI matchTab in matchTabs)
        {
            //Match tab origin selection
            if (destinationMatchTab == null)
            {
                if(matchTab.animalShapeData == null)
                {
                    destinationMatchTab = matchTab;
                }
                else
                {
                    //Skip match tab
                    continue;
                }
            }
            else
            {
                if(matchTab.animalShapeData != null)
                {
                    originMatchTab = matchTab;
                    destinationMatchTab.SetAnimalShapeData(originMatchTab.animalShapeData);
                    originMatchTab.SetAnimalShapeData(null);
                    return ComposeMatchTabs();
                }
            }
        }
        return false;
    }
    public void WinCheck()
    {
        //number of matches = max pair count
        if(pairMatchCount == maxPairsCount)
        {
            onGameWon?.Invoke();
        }
    }
    public void LoseCheck()
    {
        foreach(MatchTabUI matchTab in matchTabs)
        {
            if(matchTab.animalShapeData == null)
            {
                return;
            }
        }
        onGameLost?.Invoke();
        //End Game
    }
}
