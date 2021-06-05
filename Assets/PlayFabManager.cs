using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayFabManager : MonoBehaviour
{
   public Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        Login();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isChosen)
        {
            SendLeaderboard(manager.inventionName, 0);
        }
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/ account create");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while loging/ creating account");
        Debug.Log(error.GenerateErrorReport());
    }

   public void SendLeaderboard(string choice, int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = choice, Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
        manager.isChosen = false;
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");

    }
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = manager.inventionName,
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
