namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern
{
    /// <summary>
    /// The interface all commands will inherit.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// This is the action taken when this command is executed.
        /// </summary>
        void ExecuteCommand();

        /// <summary>
        /// This will be used to undo the previous command.
        /// </summary>
        void Undo();
    }
}