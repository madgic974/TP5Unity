using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{
    public GameObject[] planetObjects; // Tableau contenant les GameObjects des planètes


    // Fonction pour mettre à jour la position des planètes en fonction de la date et de l'heure
    void UpdatePosition(UDateTime date)
    {
        for (int i = 0; i < planetObjects.Length; i++)
        {
            PlanetData.Planet planet = (PlanetData.Planet)i; // Convertissez l'index en type de planète
            if (planetObjects[i] == null)
                continue; 

            // Utilisez la date de type UDateTime pour obtenir la position des planètes
            DateTime currentTime = date;

            // Utilisez PlanetData pour obtenir la position de la planète à la date actuelle
            Vector3 planetPosition = PlanetData.GetPlanetPosition(planet, currentTime);

            // Mise à jour de la position du GameObject de la planète dans la scène
            planetObjects[i].transform.position = planetPosition;
        }
    }

    void Start()
    {
        PlanetManager.current.OnTimeChange += UpdatePosition;
                // Obtenez la date et l'heure actuelles
        UDateTime currentDate = new UDateTime();
        currentDate.dateTime = DateTime.Now;

        // Appelez la fonction UpdatePosition pour mettre à jour les positions des planètes
        UpdatePosition(currentDate);
    }

    void Update()
    {

    }
}

