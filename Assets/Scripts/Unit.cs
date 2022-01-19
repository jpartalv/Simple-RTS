using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class that handles Unit interaction and movement
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    public GameObject SelectionIndicator;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UnitUnselected();
    }

    public void UnitSelected()
    {
        SelectionIndicator.SetActive(true);
    }

    public void UnitUnselected()
    {
        SelectionIndicator.SetActive(false);
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
