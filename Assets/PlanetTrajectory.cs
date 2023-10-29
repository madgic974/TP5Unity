using UnityEngine;
using System.Collections.Generic;
using System;

public class PlanetTrajectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public PlanetData.Planet planet; // La planète pour laquelle vous souhaitez afficher la trajectoire
    public int numPositions = 100; // Le nombre de positions à afficher
    public float duration = 365.25f; // La durée en jours de la trajectoire à afficher

    private List<Vector3> positions = new List<Vector3>();

    private void Start()
    {
        CalculateTrajectory();
        UpdateLineRenderer();
    }

    private void CalculateTrajectory()
{
    positions.Clear();
        UDateTime dateTime = new UDateTime
        {
            dateTime = DateTime.Now
        };
        float time = duration / numPositions; // Calcul du temps en jours
        for (int i = 0; i < numPositions; i++)
    {
        dateTime.dateTime=dateTime.dateTime.AddDays(time); // Utilisez AddDays pour mettre à jour la date
        Vector3 planetPosition = PlanetData.GetPlanetPosition(planet, dateTime);
        positions.Add(planetPosition);
    }
    
}

    private void UpdateLineRenderer()
    {
        lineRenderer.positionCount = numPositions;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
