using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LaptopViewer.Core.Mvvm;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event to notify subscribers that a property value has changed
    /// </summary>
    /// <param name="propertyName">The name of the property that has changed</param>
    public void RaisePropertyChanged([CallerMemberName]string? propertyName = null)
    {
        // Invoke the PropertyChanged event with the updated property name
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
