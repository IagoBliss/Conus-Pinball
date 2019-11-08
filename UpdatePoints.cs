using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using PlayFab.DataModels;
using PlayFab.ProfilesModels;
using System.Collections.Generic;
using PlayFab.Json;
using UnityEngine.UI;
public class UpdatePoints : MonoBehaviour
{
    
    void Start()
    {
     
    }

    
    void Update()
    {
        
    }

    public static void SetStats()
    {
            PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
            {

                // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
                Statistics = new List<StatisticUpdate> {
                new StatisticUpdate { StatisticName = "PlayerHighScore", Value = GameController.myPoints },

            }
            },
         result => { Debug.Log("User statistics updated"); },
         error => { Debug.LogError(error.GenerateErrorReport()); });
        }
    }
