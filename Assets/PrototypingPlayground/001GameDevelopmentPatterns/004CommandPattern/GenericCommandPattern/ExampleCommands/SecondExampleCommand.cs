namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern.ExampleCommands
{
    /// <summary>
    /// A command that will be:
    /// Invoked - by a Command Manager
    /// Act - on a Command Receiver.
    /// </summary>
    public class SecondExampleCommand : ICommand
    {
        // This will be the object we will be affecting with commands.
        private readonly CommandReceiver commandReceiver;

        public SecondExampleCommand(CommandReceiver _commandReceiver)
        {
            commandReceiver = _commandReceiver;
        }
        
        public void ExecuteCommand()
        {
            commandReceiver.SecondCommand();
        }

        public void Undo()
        {
            commandReceiver.UndoSecondCommand();
        }
    }
}