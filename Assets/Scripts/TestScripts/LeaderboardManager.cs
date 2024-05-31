using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Leaderboards;
using System.Threading.Tasks;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public async void SubmitScore(int score)
    {
        string leaderboardId = "your_leaderboard_id";
        //var leaderboardUpdate = new LeaderboardUpdateRequest
        {
            //LeaderboardId = leaderboardId,
            //Score = score
        };
        //await LeaderboardsService.Instance.UpdateLeaderboardAsync(leaderboardUpdate);
        Debug.Log("Score submitted to leaderboard: " + score);
    }

    public async Task FetchLeaderboard()
    {
        string leaderboardId = "your_leaderboard_id";
        //var leaderboardResults = await LeaderboardsService.Instance.GetLeaderboardAsync(leaderboardId, 10);
        //foreach (var entry in leaderboardResults)
        //{
            //Debug.Log($"Player: {entry.PlayerId}, Score: {entry.Score}");
        //}
    }
}
