using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Text;
using System.ComponentModel;

namespace Zork.Common
{
    public class Game
    {
        [JsonIgnore]
        public static Game Instance { get; private set; }

        public World World { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        public bool IsRunning { get; }

        [JsonIgnore]
        public CommandManager CommandManager { get; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }

        public Game() => CommandManager = new CommandManager();

        public static void Start(string gameFilename)
        {
            if (!File.Exists(gameFilename))
                throw new FileNotFoundException("Expected file.", gameFilename);

            while(Instance == null || Instance.mIsRestarting)
            {
                Instance = Load(gameFilename, (Instance == null) ? true : Instance.mIsNewGame);
                Instance.LoadCommands();
                Instance.LoadScripts();
                Instance.DisplayWelcomeMessage();
                Instance.Run();
            }
        }

        public void Run()
        {
            mIsRunning = true;
            Room previousRoom = null;

            while (mIsRunning)
            {
                Console.WriteLine(Player.Location);
                if(previousRoom != Player.Location)
                {
                    CommandManager.PerformCommand(this, "LOOK");
                    previousRoom = Player.Location;
                }

                Console.Write("\n> ");
                if(CommandManager.PerformCommand(this, Console.ReadLine().Trim()))
                {
                    Player.Moves++;
                }
                else
                {
                    Console.WriteLine("That's not a verb I recognize.");
                }
            }
        }

        public void LoadGame()
        {
            mIsNewGame = false;
            mIsRunning = false;
            mIsRestarting = true;
            Console.Clear();
        }

        public void SaveGame()
        {
            JsonSerializer serializer = new JsonSerializer { Formatting = Formatting.Indented };

            using (StreamWriter streamWriter = new StreamWriter("./ZorkSave.json"))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, Player.GetSaveData());
            }
            Console.WriteLine("Game Saved.");
        }

        public void Restart()
        {
            mIsRunning = false;
            mIsRestarting = true;
            Console.Clear();
        }

        public void Quit() => mIsRunning = false;

        public static Game Load(string filename, bool newGame)
        {
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
            game.Player = game.World.SpawnPlayer(newGame);

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
                    Console.WriteLine($"Error compiling script: {file} Error: {e.Message}");
                }
            }
        }

        public bool ConfirmAction(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                string response = Console.ReadLine().Trim().ToUpper();
                if (response == "YES" || response == "Y")
                    return true;
                else if (response == "NO" || response == "N")
                    return false;
                else
                    Console.Write("Please answer yes or no.> ");
            }
        }

        public bool ParseNumber(string prompt, out int value)
        {
            Console.Write(prompt);
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
                    Console.Write("Please enter a whole number.> ");
            }
        }

        private void DisplayWelcomeMessage() => Console.WriteLine(WelcomeMessage);

        public static readonly Random Random = new Random();
        private static readonly string ScriptDirectory = "Scripts";
        private static readonly string ScriptFileExtension = "*.csx";

        [JsonProperty]
        private string WelcomeMessage = null;

        private bool mIsRunning;
        private bool mIsRestarting;
        private bool mIsNewGame = true;
    }
}
