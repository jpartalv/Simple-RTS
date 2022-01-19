using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles Turret parameters and behavior
/// </summary>
public class Turret : MonoBehaviour
{
    public GameObject Cannon;
    public ParticleSystem ProjectilesPS;
    public SphereCollider RangeCollider;
    public float AttackRange;
    
    private GameObject targetUnit; // only one unit for the prototype 

    void Start()
    {
        ProjectilesPS.Stop();
        RangeCollider.radius = AttackRange;
    }

    void Update()
    {
        if (targetUnit != null)
        {
            Cannon.transform.LookAt(targetUnit.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GlobalVariables.PLAYER_UNIT_TAG)
        {
            targetUnit = other.gameObject;
            ProjectilesPS.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == GlobalVariables.PLAYER_UNIT_TAG)
        {
            targetUnit = null;
            ProjectilesPS.Stop();
        }

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, AttackRange, 2f);
    }
#endif
}
