using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationController : MonoBehaviour
{   
    public CameraController cameraController;
    public Text text;
    public Image panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlanetManager.current.Target != null)
        {
            if (PlanetManager.current.Target.CompareTag("Planet"))
            {
                // Récupérez les informations de la planète (par exemple, en utilisant currentTarget)
                string planetInfo = "Informations sur la planète: "+PlanetManager.current.Target.name; // Mettez les informations réelles ici
                text.text = planetInfo;
                panel.enabled = true;
            }
            else
            {
                text.text = "";
                panel.enabled = false;
            }
        }
    }
}
