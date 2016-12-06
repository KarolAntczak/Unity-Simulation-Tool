using UnityEngine;
using UnityEngine.UI;

public class RoutingParamsController : MonoBehaviour
{
    public Dropdown RoutingDropdown;

    public void Load()
    {
        Router router = SelectObject.SelectedObject.GetComponent<Router>();
        IRouting<Connection> routingStrategy = router.RoutingStrategy;

        if (routingStrategy is RandomRouting<Connection>)
        {
            RoutingDropdown.value = 0;
            RoutingDropdown.captionText.text = "Random";
        } else if (routingStrategy is RoundRobinRouting<Connection>)
        {
            RoutingDropdown.value = 1;
            RoutingDropdown.captionText.text = "Round Robin";
        }
    }

    public void Apply()
    {
        Router router = SelectObject.SelectedObject.GetComponent<Router>();
        if (RoutingDropdown.captionText.text.Equals("Random"))
        {
            router.RoutingStrategy = new RandomRouting<Connection>();
        } else if (RoutingDropdown.captionText.text.Equals("Round Robin"))
        {
            router.RoutingStrategy = new RoundRobinRouting<Connection>();
        }
    }
}
