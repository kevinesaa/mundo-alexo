using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlataform : MonoBehaviour
{

    public float leftMarging = -0.1f;
    public float rightMarging = 0.1f;
    public float topMarging = 0.1f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        MakeChild(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        MakeChild(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 left = transform.position + (leftMarging * Vector3.right);
        Vector3 right = transform.position + (rightMarging * Vector3.right);
        Vector3 top = transform.position + (topMarging * Vector3.up);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(left, 0.1f);
        Gizmos.DrawSphere(right, 0.1f);
        Gizmos.DrawSphere(top, 0.1f);
    }
#endif
    private void MakeChild(Collision2D other)
    {
        
        if (other.transform.position.y  >= transform.position.y + topMarging)
        {
            float leftLimit = transform.position.x + leftMarging;
            float rightLimit = transform.position.x + rightMarging;
            
            if (leftLimit < other.transform.position.x &&
                rightLimit > other.transform.position.x )
            {
                
                other.transform.SetParent(gameObject.transform);
            }
        }
    }
}
