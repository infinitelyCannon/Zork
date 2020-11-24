using System.IO;
using UnityEngine;
using Zork.Common;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private UnityInputService InputService;

    [Header("Header Text References")]
    [SerializeField]
    private TMP_Text LocationText;

    [SerializeField]
    private TMP_Text ScoreText;

    [SerializeField]
    private TMP_Text MovesText;

    private bool IsQuiting = false;

    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAssetName);

        Game.Start(gameJsonAsset.text, InputService, OutputService);
        Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");
        UpdateLocation(null, Game.Instance.World.GetStartingLocation());

        Game.Instance.OnLocationChanged += UpdateLocation;
        Game.Instance.OnMovesChanged += OnMovesChanged;
        Game.Instance.OnScoreChanged += UpdateScore;
        Game.Instance.LoadGameString += LoadGameString;
        Game.Instance.OnSaveGame += OnSaveGame;
    }

    private void Update()
    {
        if (!Game.Instance.IsRunning && !IsQuiting)
        {
            OutputService.WriteLine("Thank you for playing! (Press any key to quit)");
            IsQuiting = true;
        }
        if(IsQuiting && Input.anyKeyDown)
        {
#if UNITY_EDITOR
            Debug.Log("Cannot shutdown the game while inside Unity");
#endif
            Application.Quit();
        }
    }

    private void OnSaveGame(object sender, string data)
    {
        File.WriteAllText(Application.persistentDataPath + "/ZorkSave.json", data);
    }

    private string LoadGameString()
    {
        if (File.Exists(Application.persistentDataPath + "/ZorkSave.json"))
        {
            string data = File.ReadAllText(Application.persistentDataPath + "/ZorkSave.json");
            return data;
        }
        else
            return string.Empty;
    }

    private void UpdateScore(object sender, int score)
    {
        ScoreText.text = "Score: " + score;
    }

    private void OnMovesChanged(object sender, int moves)
    {
        MovesText.text = "Moves: " + moves;
    }

    private void UpdateLocation(object sender, string location)
    {
        LocationText.text = location;
    }
}
