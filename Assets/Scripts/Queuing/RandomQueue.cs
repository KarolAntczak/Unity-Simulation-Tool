using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Random queung strategy
/// </summary>
class RandomQueue<T> : IQueuing<T>
{
    public T GetNextElement(List<T> list)
    {
        int index = Random.Range(0, list.Count);
        T element = list[index];
        list.RemoveAt(index);
        return element;
    }
}