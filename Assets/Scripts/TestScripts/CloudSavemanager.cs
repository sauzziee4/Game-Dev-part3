using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using UnityEngine;

public class CloudSavemanager : MonoBehaviour
{
    public static CloudSavemanager Instance { get; private set; }

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

    public async void SaveScore(int score)
    {
        var data = new Dictionary<string, object>
        {
            {"playerScore", score}
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        Debug.Log("Score saved to cloud: " + score);
    }

    public async Task<int> LoadScore()
    {
        var data = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "playerScore" });
        if (data.ContainsKey("playerScore"))
        {
            int score = System.Convert.ToInt32(data["playerScore"]);
            Debug.Log("Score loaded from cloud: " + score);
            return score;
        }
        return 0;
    }
}
