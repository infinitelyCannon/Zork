using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Zork.Common
{
    public class Game
    {
        public delegate string LoadGameEvent();

        // Data Events (For Unity)
        public event EventHandler<string> OnLocationChanged;
        public event EventHandler<int> OnScoreChanged;
        public event EventHandler<int> OnMovesChanged;
        public event EventHandler<string> OnSaveGame;
        public event LoadGameEvent LoadGameString;

        public delegate void YesNoPrompt();
        public delegate void NumberPrompt(int value);

        [JsonIgnore]
        public static Game Instance { get; private set; }

        public World World { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        public bool IsRunning { get; private set; }

        [JsonIgnore]
        public CommandManager CommandManager { get; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }

        public Game() => CommandManager = new CommandManager();

        public static void StartFromFile(string gameFilename, IInputService input, IOutputService output)
        {
            if (!File.Exists(gameFilename))
                throw new FileNotFoundException("Expected file.", gameFilename);

            Start(File.ReadAllText(gameFilename), input, output);
        }

        public static void Start(string gameJsonString, IInputService input, IOutputService output)
        {
            Instance = Load(gameJsonString, (Instance == null) ? string.Empty : Instance.NewGameString);
            Instance.GameString = gameJsonString;
            Instance.Input = input;
            Instance.Output = output;
            Instance.LoadCommands();
            //Instance.LoadScripts();
            Instance.DisplayWelcomeMessage();
            Instance.IsRunning = true;
            Instance.Input.InputReceived += Instance.InputInputReceivedHandler;
        }

        private void InputInputReceivedHandler(object sender, string inputString)
        {
            Room previousRoom = Player.Location;
            int previousScore = Player.Score;

            if (IsWaitingForYesNo)
            {
                string response = inputString.Trim().ToUpper();
                if (response == "YES" || response == "Y")
                {
                    YesPrompt?.Invoke();
                    IsWaitingForYesNo = false;
                    return;
                }
                else if (response == "NO" || response == "N")
                {
                    NoPrompt?.Invoke();
                    IsWaitingForYesNo = false;
                    return;
                }
                else
                {
                    Output.Write("Please answer yes or no.> ");
                    return;
                }
            }

            if (IsWaitingForNumber)
            {
                int result;
                string response = inputString.Trim();
                if (int.TryParse(response, out result))
                {
                    mNumberPrompt(result);
                    IsWaitingForNumber = false;
                    OnScoreChanged?.Invoke(this, Player.Score);
                    return;
                }
                else
                {
                    Output.WriteLine("Please enter a whole number.> ");
                    return;
                }
                    
            }

            if (CommandManager.PerformCommand(this, inputString.Trim()))
            {
                Player.Moves++;
                OnMovesChanged?.Invoke(this, Player.Moves);
                
                if (previousRoom != Player.Location)
                {
                    CommandManager.PerformCommand(this, "LOOK");
                    OnLocationChanged?.Invoke(this, Player.Location.Name);
                }

                if (previousScore != Player.Score)
                    OnScoreChanged?.Invoke(this, Player.Score);
            }
            else
            {
                Output.WriteLine("That's not a verb I recognize.");
            }
        }

        public void LoadGame()
        {
            if(LoadGameString != null)
            {
                PlayerState state = null;
                NewGameString = LoadGameString?.Invoke();

                if (!string.IsNullOrEmpty(NewGameString))
                {
                    state = JsonConvert.DeserializeObject<PlayerState>(NewGameString);
                    Player.LocationName = state.Location;
                    Player.Score = state.Score;
                    Player.Moves = state.Moves;
                    OnLocationChanged?.Invoke(this, Player.LocationName);
                    OnScoreChanged?.Invoke(this, Player.Score);
                    OnMovesChanged?.Invoke(this, Player.Moves);
                }

                else
                {
                    Output.WriteLine("Restore failed. No save file exists yet.");
                    return;
                }
            }
            else
            {
                Output.WriteLine("Restore failed. This game is not setup to load games.");
            }

        }

        public void SaveGame()
        {
            JsonSerializer serializer = new JsonSerializer { Formatting = Formatting.Indented };

            using (StringWriter streamWriter = new StringWriter())
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, Player.GetSaveData());
                if (OnSaveGame == null)
                    Output.WriteLine("Sorry, could not save. This game is not allowed.");
                else
                {
                    OnSaveGame(this, streamWriter.ToString());
                    Output.WriteLine("Game Saved.");
                }
            }
        }

        public void Restart()
        {
            //IsRunning = false;
            //mIsRestarting = true;
            Output.Clear();
            Player.LocationName = World.GetStartingLocation();
            Player.Score = 0;
            Player.Moves = 0;
            OnLocationChanged?.Invoke(this, Player.LocationName);
            OnScoreChanged?.Invoke(this, 0);
            OnMovesChanged?.Invoke(this, 0);
        }

        public void Quit() => IsRunning = false;

        public static Game Load(string gameJsonString, string newGameString)
        {
            Game game = JsonConvert.DeserializeObject<Game>(gameJsonString);
            game.Player = game.World.SpawnPlayer(newGameString);

            return game;
        }

        private void LoadCommands()
        {
            var commandMethods = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                  from method in type.GetMethods()
                                  let attribute = method.GetCustomAttribute<CommandAttribute>()
                                  where type.IsClass && type.GetCustomAttribute<CommandClassAttribute>() != null
                                  where attribute != null
                                  select new Command(attribute.CommandName, attribute.Verbs,
                                  (Action<Game, CommandContext>)Delegate.CreateDelegate(typeof(Action<Game, CommandContext>), method)));

            CommandManager.AddCommands(commandMethods);
        }

        /*
        private void LoadScripts()
        {
            foreach(string file in Directory.EnumerateFiles(ScriptDirectory, ScriptFileExtension))
            {
                try
                {
                    var scriptOptions = ScriptOptions.Default.AddReferences(Assembly.GetExecutingAssembly());

#if DEBUG
                    scriptOptions = scriptOptions.WithEmitDebugInformation(true)
                        .WithFilePath(new FileInfo(file).FullName)
                        .WithFileEncoding(Encoding.UTF8);
#endif

                    string script = File.ReadAllText(file);
                    CSharpScript.RunAsync(script, scriptOptions).Wait();
                }
                catch(Exception e)
                {
                    Output.WriteLine($"Error compiling script: {file} Error: {e.Message}");
                }
            }
        }
        */

        public void ConfirmAction(string prompt, YesNoPrompt yes, YesNoPrompt no)
        {
            Output.WriteLine(prompt);

            IsWaitingForYesNo = true;
            YesPrompt = yes;
            NoPrompt = no;
            /*
            Output.Write(prompt);

            while (true)
            {
                string response = Console.ReadLine().Trim().ToUpper();
                if (response == "YES" || response == "Y")
                    return true;
                else if (response == "NO" || response == "N")
                    return false;
                else
                    Output.Write("Please answer yes or no.> ");
            }
            */
        }

        public void ParseNumber(string prompt, NumberPrompt numberPrompt)
        {
            Output.WriteLine(prompt);

            IsWaitingForNumber = true;
            mNumberPrompt = numberPrompt;
            /*
            int result;

            while (true)
            {
                string response = Console.ReadLine().Trim();
                if (int.TryParse(response, out result))
                {
                    value = result;
                    return true;
                }
                else
                    Output.Write("Please enter a whole number.> ");
            }
            */
        }

        private void DisplayWelcomeMessage() => Output.WriteLine(WelcomeMessage);

        public static readonly Random Random = new Random();
        //private static readonly string ScriptDirectory = "Scripts";
        //private static readonly string ScriptFileExtension = "*.csx";

        [JsonProperty]
        private string WelcomeMessage = null;

        [JsonIgnore]
        public IOutputService Output { get; private set; }

        [JsonIgnore]
        public IInputService Input { get; private set; }

        private bool mIsRestarting;
        private string NewGameString = null;
        private string GameString;

        private bool IsWaitingForYesNo = false;
        private bool IsWaitingForNumber = false;
        private YesNoPrompt YesPrompt;
        private YesNoPrompt NoPrompt;
        private NumberPrompt mNumberPrompt;
    }
}
