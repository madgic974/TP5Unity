using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    public Toggle realistPlanetsToggle;
    public Toggle adaptedPlanetsToggle;
    public GameObject[] planets; // Tableau de GameObjects représentant les planètes
    public Dictionary<string, float> planetSizesRealistic; // Dictionnaire pour stocker les tailles réelles

    public Dictionary<string,float> planetSizesAdapted;

    private void Start()
    {
        // Ajoutez des événements de déclenchement pour les boutons de bascules
        realistPlanetsToggle.onValueChanged.AddListener(OnRealistPlanetsToggleChanged);
        adaptedPlanetsToggle.onValueChanged.AddListener(OnAdaptedPlanetsToggleChanged);
         planetSizesRealistic = new Dictionary<string, float>
        {
            { "Mercure", 0.000055f }, // Diamètre de Mercure en UA
            { "Venus", 0.000137f }, // Diamètre de Vénus en UA
            { "Earth", 0.000145f }, // Diamètre de la Terre en UA
            { "Mars", 0.000077f }, // Diamètre de Mars en UA
            { "Jupiter", 0.001429f }, // Diamètre de Jupiter en UA
            { "Saturn", 0.001193f }, // Diamètre de Saturne en UA
            { "Uranus", 0.000508f }, // Diamètre d'Uranus en UA
            { "Neptune", 0.000494f }, // Diamètre de Neptune en UA
            { "Sun", 0.004649f } // Diamètre du Soleil en UA
        };
        planetSizesAdapted = new Dictionary<string, float>
        {
            { "Mercure", 0.15f }, 
            { "Venus", 0.15f }, 
            { "Earth", 0.15f },
            { "Mars", 0.15f }, 
            { "Jupiter", 0.15f }, 
            { "Saturn", 0.15f },
            { "Uranus", 0.15f }, 
            { "Neptune", 0.15f }, 
            { "Sun", 0.3f }, 
        };
        foreach (var planet in planets)
        {
            string planetName = planet.name;

            if (planetSizesAdapted.ContainsKey(planetName))
            {
                float newSize = planetSizesAdapted[planetName];
                planet.transform.localScale = new Vector3(newSize, newSize, newSize);
            }
            else
            {
                Debug.LogWarning("La taille de la planète " + planetName + " n'a pas été définie.");
            }
        }
    }

    private void OnRealistPlanetsToggleChanged(bool isOn)
    {
        if (isOn)
        {
            SetPlanetSize("realistic");
            adaptedPlanetsToggle.isOn = false;
        }
    }

    private void OnAdaptedPlanetsToggleChanged(bool isOn)
    {
        if (isOn)
        {
            SetPlanetSize("adapted");
            realistPlanetsToggle.isOn = false;
        }
    }

    public void SetPlanetSize(string size)
    {
        if(size=="realistic")
        {
            foreach (var planet in planets)
        {
            string planetName = planet.name;

            if (planetSizesRealistic.ContainsKey(planetName))
            {
                float newSize = planetSizesRealistic[planetName];
                planet.transform.localScale = new Vector3(newSize, newSize, newSize);
            }
            else
            {
                Debug.LogWarning("La taille de la planète " + planetName + " n'a pas été définie.");
            }
        }

        }
        else if(size=="adapted")
        {
            foreach (var planet in planets)
        {
            string planetName = planet.name;

            if (planetSizesAdapted.ContainsKey(planetName))
            {
                float newSize = planetSizesAdapted[planetName];
                planet.transform.localScale = new Vector3(newSize, newSize, newSize);
            }
            else
            {
                Debug.LogWarning("La taille de la planète " + planetName + " n'a pas été définie.");
            }
        }
        }
    }
}


