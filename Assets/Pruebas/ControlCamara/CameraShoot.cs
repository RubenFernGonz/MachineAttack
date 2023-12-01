using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShoot : MonoBehaviour
{
    [SerializeField] Camera _actualCam;
    public LayerMask layerMask;
    public GameObject shootPrefab;
    public GameObject dump;

    public RenderTexture cameraTexture;
    Vector3 lastPos = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = _actualCam.transform.position;
        Debug.DrawRay(camPos, lastPos - camPos, Color.red);
    }

    public void Shoot( Vector3 objectivePosition)
    {
        Vector3 camPos = _actualCam.transform.position;
        objectivePosition = new Vector3((objectivePosition.x + 1.0f) / 2.0f, (objectivePosition.y + 1.0f) / 2.0f, 0.0f);

        Vector3 mouseInCam = new Vector3 (objectivePosition.x * _actualCam.scaledPixelWidth , objectivePosition.y * _actualCam.scaledPixelHeight , 0.0f);
        Debug.Log("Moise in s Cam is : " + mouseInCam);
        mouseInCam.z = 100f;
        Vector3 mouseInWorld = _actualCam.ScreenToWorldPoint(mouseInCam);
        mouseInCam.z = 0.0f;



        lastPos = mouseInWorld;   
        
        


        Ray ray = _actualCam.ScreenPointToRay(mouseInCam);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit , 100f , layerMask))
        {

           instantiateShoot(hit.point, camPos);
            


        }
    }
    void instantiateShoot(Vector3 targetPosition , Vector3 startingPos)
    {
        GameObject obj = Instantiate(shootPrefab, dump.transform);
        obj.transform.position = startingPos;
        Bala bala = obj.GetComponent<Bala>();
        bala.startingPos = startingPos;
        bala.targetPos = targetPosition;


    }

    public void ChangeCamera(Camera newCam)
    {
        _actualCam.targetTexture = null;
        _actualCam = newCam;
        _actualCam.targetTexture = cameraTexture;
        

    }
}
