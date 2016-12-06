using System.Collections.Generic;
using UnityEngine;

public class RandomRouting<T> : IRouting<T> {

    public T GetNextElement(List<T> list)
    {
        int index = Random.Range(0, list.Count);
        T element = list[index];
        return element;
    }
}
