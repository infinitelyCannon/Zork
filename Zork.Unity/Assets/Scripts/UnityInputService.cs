using UnityEngine;
using UnityEngine.EventSystems;
using Zork;
using Zork.Common;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;

public class UnityInputService : MonoBehaviour, IInputService
{
    [SerializeField]
    private TMP_InputField InputField;

    [SerializeField]
    private int MaxHistoryLength = 100;

    private EventSystem eventSystem;
    private List<string> CommandHistory;
    private int CommandHistoryIndex = 0;

    public event EventHandler<string> InputReceived;

    public  void ProcessInput()
    {
        
    }

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        CommandHistory = new List<string>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && Game.Instance.IsRunning)
        {
            string inputString = InputField.text;

            if (!string.IsNullOrWhiteSpace(inputString))
            {
                InputReceived?.Invoke(this, inputString);
                CommandContext lastCommand = Game.Instance.CommandManager.Parse(inputString);
                if(lastCommand.Command != null)
                {
                    AddToHistory(inputString);
                }
            }

            InputField.text = string.Empty;
            //eventSystem.SetSelectedGameObject(InputField.gameObject);
            InputField.ActivateInputField();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            InputReceived?.Invoke(this, "Quit");

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            InputField.text = CommandHistory[Clamp(CommandHistoryIndex--, 0, CommandHistory.Count - 1)];
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            InputField.text = CommandHistory[Clamp(CommandHistoryIndex++, 0, CommandHistory.Count - 1)];
        }
    }

    private void AddToHistory(string command)
    {
        if (CommandHistory.Count >= MaxHistoryLength)
        {
            CommandHistory = CommandHistory.Where((value, index) => index != 0).ToList();
            CommandHistory.Add(command);
        }
        else
            CommandHistory.Add(command);

        CommandHistoryIndex = CommandHistory.Count - 1;
    }

    private int Clamp(int value, int min, int max)
    {
        if (value < min)
            return min;
        if (value > max)
            return max;
        return value;
    }
}
