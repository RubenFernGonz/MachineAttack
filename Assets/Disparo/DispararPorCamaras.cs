using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DispararPorCamaras : MonoBehaviour
{
    public Camera camara;
    public CameraController cameraController;
    public GameObject currentCamera;
    //public Texture2D cursorType;
    public GameObject shootPrefab;
    public GameObject dump;
    //int actCam = 0;

    private void Start()
    {
       // Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        //Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
        currentCamera = cameraController.currentCamera;
    }

    private void Update()
    {
        if (cameraController.currentCamera == cameraController.cameras[4]) return;
        


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = camara.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0)){

            instantiateShoot(mousePos, cameraController.currentCamera.gameObject.transform.position);

        }





    }
    void instantiateShoot(Vector3 targetPosition, Vector3 startingPos)
    {
        GameObject obj = Instantiate(shootPrefab, dump.transform);
        obj.transform.position = startingPos;
        Bala bala = obj.GetComponent<Bala>();
        bala.startingPos = startingPos;
        bala.targetPos = targetPosition;


    }
}
