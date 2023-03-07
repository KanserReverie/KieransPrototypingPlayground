namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern.ExampleCommands
{
    /// <summary>
    /// A command that will be:
    /// Invoked - by a Command Manager
    /// Act - on a Command Receiver.
    /// </summary>
    public class FirstExampleCommand : ICommand
    {
        // This will be the object we will be affecting with commands.
        private readonly CommandReceiver commandReceiver;

        public FirstExampleCommand(CommandReceiver _commandReceiver)
        {
            commandReceiver = _commandReceiver;
        }

        public void ExecuteCommand()
        {
            commandReceiver.FirstCommand();
        }

        public void Undo()
        {
            commandReceiver.UndoFirstCommand();
        }
    }
}