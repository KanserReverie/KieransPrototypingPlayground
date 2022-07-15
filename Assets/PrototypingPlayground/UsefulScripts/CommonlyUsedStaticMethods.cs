namespace PrototypingPlayground.UsefulScripts
{
    public static class CommonlyUsedStaticMethods
    {
        /// <summary>
        /// In build - Quits the game
        /// In playmode - Ends the playmode 
        /// </summary>
        public static void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
    }
}
