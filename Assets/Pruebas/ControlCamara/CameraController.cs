using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Controlador de las cámaras. Para realizar el cambio de cámaras instantaneo el CinemachineBrain de la cámara debe estar configurado con Default Blend a Cut.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Lista con las cámaras del nivel.
    /// </summary>
    public List<GameObject> cameras = new List<GameObject>();
    /// <summary>
    /// Camara activa
    /// </summary>
    public GameObject currentCamera;
    int pez = 1;
    public static int pos;

    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    public GameObject botonCentral;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        string input = Input.inputString;
        if (!string.IsNullOrEmpty(input) && (input.Length > 0 || pez == 1))
        {
            char character = input[0];
            //Posición de la cámara en la lista de cámaras
            pos = -1;
            //Según el número pulsado se activará una cámara diferente
            if (character.Equals('1'))
            {
                pos = 0;
            }
            else if (character.Equals('2'))
            {
                pos = 1;
            }
            else if (character.Equals('3'))
            {
                pos = 2;
            }
            else if (character.Equals('4'))
            {
                pos = 3;
            }
            else if (character.Equals('e'))
            {
                pos = 4;
            }
            /*else if (character.Equals('6'))
            {
                pos = 5;
            }
            else if (character.Equals('7'))
            {
                pos = 6;
            }
            else if (character.Equals('8'))
            {
                pos = 7;
            }
            else if (character.Equals('9'))
            {
                pos = 8;
            }*/
            //Si pos no es negativo significa que se ha seleccionado una cámara para cambiar
            if (pos >= 0)
            {
                //Comprobamos que se puede seleccionar la cámara
                if (pos < cameras.Count)
                {
                    //Desactivamos la cámara actual
                    currentCamera.SetActive(false);
                    //Seleccionamos la cámara nueva
                    currentCamera = cameras[pos];
                    //Activamos la nueva cámara 
                    currentCamera.SetActive(true);
                }
            }
        }

      
    }
    public void Camara1()
    {
        pos = 0; // Set the value of pos to 0
        boton1.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        boton4.SetActive(false);
        botonCentral.SetActive(true);
        SwitchCamera(); // Call the method to switch the camera
    }

    public void Camara2()
    {
        pos = 1; // Set the value of pos to 0
        boton1.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        boton4.SetActive(false);
        botonCentral.SetActive(true);
        SwitchCamera(); // Call the method to switch the camera
    }

    public void Camara3()
    {
        pos = 2; // Set the value of pos to 0
        boton1.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        boton4.SetActive(false);
        botonCentral.SetActive(true);
        SwitchCamera(); // Call the method to switch the camera
    }

    public void Camara4()
    {
        pos =3; // Set the value of pos to 0
        boton1.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        boton4.SetActive(false);
        botonCentral.SetActive(true);
        SwitchCamera(); // Call the method to switch the camera
    }

    public void CamaraCentral()
    {
        pos = 4; // Set the value of pos to 0
        boton1.SetActive(true);
        boton2.SetActive(true);
        boton3.SetActive(true);
        boton4.SetActive(true);
        botonCentral.SetActive(false);

        SwitchCamera(); // Call the method to switch the camera
    }

    // ... (other code)

    // Method to switch the camera based on the value of pos
    private void SwitchCamera()
    {
        // Check if pos is a valid index in the cameras list
        if (pos >= 0 && pos < cameras.Count)
        {
            // Deactivate the current camera
            currentCamera.SetActive(false);

            // Set the new camera based on the value of pos
            currentCamera = cameras[pos];

            // Activate the new camera
            currentCamera.SetActive(true);
        }
    }
}
