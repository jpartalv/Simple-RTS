using UnityEngine;

/// <summary>
/// Main class the manages the player interaction
/// </summary>
public class GameManager : MonoBehaviour
{
    public float CameraSpeed = 1;
    public GameObject DestinationIndicator;

    private Unit controlledUnit;
    private Vector3 defaultCameraPosition = new Vector3(0,0,-11);
    private float viewportMovementZone = 0.1f;

    void Start()
    {
        DestinationIndicator.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
    }

    void Update()
    {
        Vector3 viewportPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            
        if (viewportPoint.x < viewportMovementZone) 
        {
            Camera.main.transform.Translate(-CameraSpeed * Time.deltaTime,0,0);
        }

        if (viewportPoint.x > 1 - viewportMovementZone)
        {
            Camera.main.transform.Translate(CameraSpeed * Time.deltaTime, 0, 0);
        }

        if (viewportPoint.y < viewportMovementZone)
        {
            Camera.main.transform.Translate(0,0,-CameraSpeed * Time.deltaTime, Space.World);
        }

        if (viewportPoint.y > 1 - viewportMovementZone)
        {
            Camera.main.transform.Translate(0, 0, CameraSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (controlledUnit != null)
            {
                controlledUnit.UnitUnselected();
                controlledUnit = null;
                DestinationIndicator.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit " + hit.collider.name);

                switch (hit.collider.tag)
                {
                    case GlobalVariables.PLAYER_UNIT_TAG:
                        controlledUnit = hit.transform.gameObject.GetComponent<Unit>();
                        controlledUnit.UnitSelected();
                        Camera.main.transform.position = new Vector3(controlledUnit.transform.position.x, +Camera.main.transform.position.y,
                            controlledUnit.transform.position.z + defaultCameraPosition.z);
                        break;

                    case GlobalVariables.INDICATOR_TAG:
                        break;

                    case GlobalVariables.TERRAIN_TAG:
                        if (controlledUnit != null)
                        {
                            controlledUnit.SetDestination(hit.point);
                            DestinationIndicator.transform.position = hit.point;
                            DestinationIndicator.SetActive(true);
                        }
                        break;
                }

            }
            else
            {
                if (controlledUnit != null)
                {
                    controlledUnit.UnitUnselected();
                    controlledUnit = null;
                }
            }
        }
    }  
}
