using System;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour
{
    public InputField inputField;
    private void Start() 
    {
        PlanetManager.current.OnTimeChange += UpdateText;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Appuyez sur la touche "Entrée" pour valider la date
        {
            // Récupérez le texte de l'UI et appelez la méthode pour définir la date
            string inputDate = inputField.text;
            Debug.Log(inputDate.ToString());
            DateTime date = new DateTime();
            if (DateTime.TryParse(inputDate, out date))
            {
                Console.WriteLine("Date et heure parsées : " + date.ToString());
            }
            else
            {
                Console.WriteLine("Impossible de convertir la chaîne en DateTime.");
            }

            PlanetManager.current.Date= date;
        }
    }
    private void UpdateText(UDateTime date)
    {
        inputField.text = date.dateTime.ToString("yyyy-MM-dd");;
    }
}

