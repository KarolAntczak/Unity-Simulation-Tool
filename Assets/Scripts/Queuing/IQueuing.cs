using System.Collections.Generic;

/// <summary>
/// Queuing strategy
/// </summary>
public interface IQueuing<T> {

    /// <summary>
    /// Removes next element from list using some queuing strategy
    /// </summary>
    T GetNextElement(List<T> list);
    
}
