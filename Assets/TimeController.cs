using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider speedSlider;
    public Button playPauseButton;
    public Text speedText;

    private bool isPlaying = false;
    private float timeSpeed = 1.0f; // Vitesse du temps (1.0 par défaut)

    private void Start()
    {
        // Initialisez le slider et le texte
        speedSlider.value = timeSpeed;
        speedText.text = "x " + timeSpeed.ToString("F2");

        // Associez des fonctions aux événements du slider et du bouton
        speedSlider.onValueChanged.AddListener(UpdateSpeed);
        playPauseButton.onClick.AddListener(TogglePlayPause);
    }

    private void Update()
    {
        if (isPlaying)
        {
            // Mettez à jour le temps en fonction de la vitesse
            float deltaTime = Time.deltaTime * timeSpeed;
            PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddDays(deltaTime);
        }
    }

    private void UpdateSpeed(float value)
    {
        timeSpeed = value;
        speedText.text = "x " + timeSpeed.ToString("F2");
    }

    private void TogglePlayPause()
    {
        isPlaying = !isPlaying;
        playPauseButton.GetComponentInChildren<Text>().text = isPlaying ? "Pause" : "Play";
    }
}

