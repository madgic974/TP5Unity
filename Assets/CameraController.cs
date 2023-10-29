using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float moveSpeed = 5.0f;
    public float maxZoomDistance = 10.0f;
    public float minZoomDistance = 2.0f;
    public float smoothSpeed = 5.0f;

    private Vector3 lastMousePosition;

    void Start()
    {
    }

    void Update()
    {
        // Rotation de la caméra
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            Vector3 axisX = PlanetManager.current.Target.right;
            Vector3 axisY = PlanetManager.current.Target.up;

            transform.RotateAround(PlanetManager.current.Target.position, axisY, deltaMouse.x * rotationSpeed * Time.deltaTime);
            transform.RotateAround(PlanetManager.current.Target.position, axisX, -deltaMouse.y * rotationSpeed * Time.deltaTime);

            lastMousePosition = Input.mousePosition;
        }

        // Zoom de la caméra
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        transform.LookAt(PlanetManager.current.Target.position); // Permet de regarder toujours en direction de la cible
        transform.position += transform.forward*zoomInput*moveSpeed*Time.deltaTime; 
        

        // Détection de clic pour changer la cible
        if (Input.GetMouseButtonDown(1)) // Clic droit pour changer la cible
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Planet") || hit.transform.CompareTag("Astre"))
                {
                    PlanetManager.current.Target = hit.transform; // Changer la cible vers la planète cliquée
                }
            }
        }
    }
}
