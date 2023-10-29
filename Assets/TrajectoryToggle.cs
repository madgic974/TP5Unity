using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrajectoryToggle : MonoBehaviour
{
    public Toggle toggle; // Assurez-vous que la variable "toggle" est liée au composant Toggle du bouton.

    public GameObject[] planetsWithTrajectories; // Tableau des GameObjects des planètes avec des trajectoires.

    public TrajectoryController trajectoryController; // Référence au TrajectoryController

    private void Start()
    {
        // Assurez-vous que le composant Toggle est correctement lié dans l'inspecteur.
        if (toggle != null)
        {
            // Ajoutez un gestionnaire d'événements lorsque l'état du Toggle change.
            toggle.onValueChanged.AddListener(ToggleTrajectories);
        }
        
    }

    private void ToggleTrajectories(bool enable)
    {
        // Activez ou désactivez les trajectoires des planètes en fonction de l'état du Toggle.
        foreach (var planet in planetsWithTrajectories)
        {
             trajectoryController.SetTrajectoriesEnabled(enable);
        }
    }
}
