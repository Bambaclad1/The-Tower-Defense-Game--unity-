using UnityEngine;

public class TowerGizmo : MonoBehaviour
{
    public Color gizmoColor = Color.green; 
    public float radius = 5f; 

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
