using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class RicochetTrajectory : MonoBehaviour
{
    public Transform firePosition;
    public float maximumRayCastDistance = 50f;
    public float maximumReflectionCount = 5f;

    public int _fields;
    public List<string> _colorss = new List<string>();


    void Update()
    {
        DrawCurrentTrajectory();

    }

    void DrawCurrentTrajectory()
    {
        Vector2 position = transform.position;
        Vector2 direction = firePosition.position - transform.position;

        for (int i = 0; i <= maximumReflectionCount; ++i)
        {
            RaycastHit2D hit = Physics2D.Raycast(position, direction, maximumRayCastDistance);
            if (hit)
            {
                Debug.DrawLine(position, hit.point, Color.green);
                Debug.DrawLine(hit.point, hit.point + hit.normal * 0.25f, Color.magenta);

                position = hit.point + hit.normal * 0.00001f;
                direction = Vector2.Reflect(direction, hit.normal);
            }
        }
    }
}

[System.Serializable]
public struct ColorsData
{
    public TrapType trapType;
    public Color color;
}