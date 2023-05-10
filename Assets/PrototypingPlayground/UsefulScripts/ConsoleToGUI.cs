using UnityEngine;
namespace PrototypingPlayground.UsefulScripts
{
    public class ConsoleToGUI : MonoBehaviour
    {
        private const string CONSOLE_TO_GUI_PREFAB_NAME = "ConsoleToGUI - Add this to a scene to display console"; 
        string myLog = "*begin log";
        string filename = "";
        bool doShow = true;
        int kChars = 700;

        void OnEnable()
        {
            Application.logMessageReceived += Log;
        }
        void OnDisable()
        {
            Application.logMessageReceived -= Log;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                doShow = !doShow;
            }
        }
        public void Log(string logString, string stackTrace, LogType type)
        {
            // for onscreen...
            myLog = myLog + "\n" + logString;
            if (myLog.Length > kChars)
            {
                myLog = myLog.Substring(myLog.Length - kChars);
            }

            // for the file ...
            if (filename == "")
            {
                string d = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/YOUR_LOGS";
                System.IO.Directory.CreateDirectory(d);
                string r = Random.Range(1000, 9999).ToString();
                filename = d + "/log-" + r + ".txt";
            }
            try
            {
                System.IO.File.AppendAllText(filename, logString + "\n");
            }
            catch { }
        }

        void OnGUI()
        {
            GUILayout.Label("Press \"~\" to toggle console");
            if (!doShow)
            {
                return;
            }
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
                new Vector3(Screen.width / 1200.0f, Screen.height / 800.0f, 1.0f));
            GUI.TextArea(new Rect(10, 30, 540, 370), myLog);
        }

        /// <summary>
        /// This will Instantiate a GameObject for users to see the console log. 
        /// </summary>
        /// <param name="_showGUIByDefault"> If you want to show the GUI when instantiated. </param>
        public static void InstantiateConsoleToGUIInScene(bool _showGUIByDefault)
        {
            GameObject instantiatedObject = Instantiate(Resources.Load(CONSOLE_TO_GUI_PREFAB_NAME) as GameObject);
            instantiatedObject.GetComponentInChildren<ConsoleToGUI>().doShow = _showGUIByDefault;
        }
        
        /// <summary>
        /// This will Instantiate a GameObject for users to see the console log. 
        /// </summary>
        public static void InstantiateConsoleToGUIInScene()
        {
            Instantiate(Resources.Load(CONSOLE_TO_GUI_PREFAB_NAME));
        }
    }
}