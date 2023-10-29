using UnityEngine;
using System.Collections.Generic;
using System;

public class TrajectoryController : MonoBehaviour
{
    public LineRenderer trajectoryPrefab; // Préfab du LineRenderer pour les trajectoires

    private Dictionary<PlanetData.Planet, float> planetPeriods = new Dictionary<PlanetData.Planet, float>();

    private List<LineRenderer> trajectoryRenderers = new List<LineRenderer>(); // Liste pour stocker les LineRenderer

    private void Start()
    {
        // Initialisez le dictionnaire avec les périodes de révolution des planètes
        planetPeriods[PlanetData.Planet.Mercury] = 87.97f;
        planetPeriods[PlanetData.Planet.Venus] = 224.70f;
        planetPeriods[PlanetData.Planet.Earth] = 365.25f;
        planetPeriods[PlanetData.Planet.Mars] = 686.98f;
        planetPeriods[PlanetData.Planet.Jupiter] = 4332.59f;
        planetPeriods[PlanetData.Planet.Saturn] = 10759.22f;
        planetPeriods[PlanetData.Planet.Uranus] = 30685.40f;
        planetPeriods[PlanetData.Planet.Neptune] = 60189.00f;

        // Parcourez toutes les planètes et générez leurs trajectoires
        foreach (PlanetData.Planet planet in Enum.GetValues(typeof(PlanetData.Planet)))
        {
            LineRenderer trajectory = Instantiate(trajectoryPrefab, transform);
            PlanetTrajectory planetTrajectory = trajectory.gameObject.AddComponent<PlanetTrajectory>();
            planetTrajectory.planet = planet;
            planetTrajectory.numPositions = 500; // Personnalisez le nombre de positions si nécessaire
            planetTrajectory.duration = planetPeriods[planet]; // Utilisez la période de révolution correspondante
            planetTrajectory.lineRenderer = trajectory;
            trajectoryRenderers.Add(trajectory);
        }
    }
    public void SetTrajectoriesEnabled(bool enable)
    {
        foreach (var trajectory in trajectoryRenderers)
        {
            trajectory.enabled = enable;
        }
    }
}

