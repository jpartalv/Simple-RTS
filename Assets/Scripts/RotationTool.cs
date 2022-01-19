using UnityEngine;

/// <summary>
/// Simple tool for the indicator animation
/// </summary>
public class RotationTool : MonoBehaviour
{
    public float RotationSpeed = 1;

    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}
