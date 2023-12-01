using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    Camera cam;
    public Camera SecondCam;
    public LayerMask mask;
    private bool targetCursor = false;

    public CameraShoot cs;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        bool rayHasHitted = false;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray , out hit , 100 , mask))
        {
            //rayHasHitted = true;

            if (hit.collider.gameObject.CompareTag("Pantalla"))
            {
                rayHasHitted = true;

                if (Input.GetMouseButtonDown(0))
                {
                    MeshCollider col = hit.collider.gameObject.GetComponent<MeshCollider>();
                    float h, w;
                    h = col.bounds.extents.y;
                    w = col.bounds.extents.x;

                    Vector3 pointInArcadeScreen = new Vector3((col.bounds.center.x - hit.point.x) / w,  - (col.bounds.center.y - hit.point.y) / h, 0);
                    Debug.Log(pointInArcadeScreen);
                    DebugDrawCross(hit.point);
                    cs.Shoot(pointInArcadeScreen);



                }
            }
            
        }

        ChangeCursor(rayHasHitted);
    }

    void ChangeCursor(bool rayHasHit)
    {
        if (rayHasHit) {
            if (targetCursor) return;

            MouseCursor.instance.ChangeCursor(true);
            targetCursor = true;

        }
        else
        {
            if (!targetCursor) return;

            MouseCursor.instance.ChangeCursor(false);
            targetCursor = false;
        }
        
    }

    void DebugDrawCross(Vector3 point)
    {
        Debug.DrawLine(point - Vector3.up * 0.2f, point + Vector3.up * 0.2f, Color.red, 1.5f);
        Debug.DrawLine(point - Vector3.left * 0.2f, point + Vector3.left * 0.2f, Color.red, 1.5f);


    }
}
