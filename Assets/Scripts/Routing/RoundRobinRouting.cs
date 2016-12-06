using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RoundRobinRouting<T> : IRouting<T> {

    private int index = 0;

    public T GetNextElement(List<T> list)
    {
        if (list.Count < 1)
        {
            return default(T);
        } else if (list.Count <= index)
        {
            index = 0;
        }

        T element = list[index];
        index++;
        return element;
    }
}
