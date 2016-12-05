using System.Collections.Generic;

/// <summary>
/// First In - First Out queuing strategy
/// </summary>
class Fifo<T> : IQueuing<T>
{
    public T GetNextElement(List<T> list)
    {
        T element = list[0];
        list.RemoveAt(0);
        return element;
    }
}