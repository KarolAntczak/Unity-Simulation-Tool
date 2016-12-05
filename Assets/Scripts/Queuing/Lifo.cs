using System.Collections.Generic;

/// <summary>
/// Last In - First Out queuing strategy
/// </summary>
class Lifo<T> : IQueuing<T>
{
    public T GetNextElement(List<T> list)
    {
        T element = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return element;
    }
}