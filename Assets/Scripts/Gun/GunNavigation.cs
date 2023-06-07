using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunNavigation : MonoBehaviour
{
    public GameObject NavigationArea;
    public GameObject PlayerObject;


    public float RotationSpeed = 0.1f;

    private float CircleRadius;

    public float ElevationOffset = 0;

    private Vector3 positionOffset;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        CircleRadius = GetCircleRadius();
        angle = ElevationOffset;
    }

    public float GetCircleRadius()
    {
        return NavigationArea.GetComponent<CircleCollider2D>().radius * 2;
    }

    // Update is called once per frame
    void Update()
    {
        positionOffset.Set(
         Mathf.Cos(angle) * CircleRadius,
         Mathf.Sin(angle) * CircleRadius,
         0
     );
        transform.position = NavigationArea.transform.position - positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }
}
