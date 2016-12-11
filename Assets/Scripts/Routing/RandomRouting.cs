using System.Collections.Generic;
using UnityEngine;

public class RandomRouting : IRouting<Connection> {

    public Connection GetNextElement(List<Connection> list)
    {
        float sumOfProbabilities = 0;
        foreach(Connection connection in list)
        {
            sumOfProbabilities += connection.RedirectingProbability;
        }
        
        float random = Random.Range(0, sumOfProbabilities);
        float step = 0;

        foreach (Connection connection in list)
        {
            step += connection.RedirectingProbability;

            if (step > random)
            {
                return connection;
            }
        }

        return null; // Should not happen
    }
}
