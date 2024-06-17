using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using UnityEngine;

public static class CloudSave
{
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