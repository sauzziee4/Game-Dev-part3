using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using UnityEngine;
using Unity.Services.CloudSave.Models;

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

    public static async Task SaveData()
    {
        Dictionary<string, string> result =
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object>()
            {
                { "Highscore", 25 }
            });
    }

    public static async Task<Item> LoadData()
    {
        Dictionary<string, Item> result = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string>()
        {
            "Highscore"
        });

        return result["Highscore"];
    }
}
