using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Routing strategy
/// </summary>
public interface IRouting<T> {

    /// <summary>
    /// Get next element based on routing strategy.
    /// </summary>
    T GetNextElement(List<T> list);
}