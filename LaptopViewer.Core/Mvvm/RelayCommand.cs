using System.Windows.Input;

namespace LaptopViewer.Core.Mvvm;

/// <summary>
/// A command implementation that allows binding methods to UI elements in a view model
/// </summary>
public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Determines whether the command can be executed with the specified parameter
    /// </summary>
    /// <param name="parameter">The parameter for the command</param>
    /// <returns>true if the command can be executed; otherwise, false</returns>
    public bool CanExecute(object? parameter)
    {
        // Invoke the canExecute delegate if it's not null, otherwise default to true
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// Executes the command with the specified parameter
    /// </summary>
    /// <param name="parameter">The parameter for the command</param>
    public void Execute(object? parameter)
    {
        _execute(parameter);
    }
}
