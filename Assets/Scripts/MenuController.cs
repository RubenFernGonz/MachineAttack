using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject ilustracion1;
    public GameObject ilustracion2;
    public GameObject fondoIlustracion;
    public static int contador = 0;
    public GameObject interfaz;


    public GameObject menuPausa;
    private bool pausaActiva = false;

    private bool prueba;

    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    public GameObject botonCentral;
    public GameObject botonPausa;



    private void Update()
    {
        if (Input.GetKeyDown("escape") | Input.GetKeyDown(KeyCode.Tab))
        {
            if (!pausaActiva)
            {
                Time.timeScale = 0.1f;
                menuPausa.SetActive(true);
                pausaActiva = true;
                Cursor.lockState = CursorLockMode.Confined;
                boton1.SetActive(false);
                boton2.SetActive(false);
                boton3.SetActive(false);
                boton4.SetActive(false);
                botonCentral.SetActive(false);
                botonPausa.SetActive(false);

            }
            else
            {
                Continue();
            }
        }

      
    }

    public void StartGame()
    {

            SceneManager.LoadScene("Game");
        ilustracion1.SetActive(true);



    }

    public void Pausa()
    {
        Time.timeScale = 0.1f;
        menuPausa.SetActive(true);
        pausaActiva = true;
 
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        pausaActiva = false; // Restablece la pausa como inactiva cuando se reanuda.
        boton1.SetActive(true);
        boton2.SetActive(true);
        boton3.SetActive(true);
        boton4.SetActive(true);
        botonCentral.SetActive(true);
        botonPausa.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

    }

    public void ExitPrincipalScene()
    {
        SceneManager.LoadScene("PrincipalMenu");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {
       #if UNITY_EDITOR
        // Si estamos en el Editor de Unity, recargamos la escena
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                    // Si estamos en una compilación independiente, cerramos la aplicación
                    Application.Quit();
        #endif
    }


    public void Ilustracion()
    {
        if (ilustracion1.activeSelf || ilustracion2.activeSelf)
        {
            // Verifica si se presiona la tecla X
            if (contador == 0)
            {
                // Desactiva ilustracion1 y activa ilustracion2
                ilustracion1.SetActive(false);
                ilustracion2.SetActive(true);
                contador++;
            }

            else if (contador == 1)
            {
                // Desactiva ilustracion2
                ilustracion2.SetActive(false);
                fondoIlustracion.SetActive(false);
                interfaz.SetActive(true);
                EnemyGeneratorManager.generationRatio = 1;
                contador++;

                boton1.SetActive(true);
                boton2.SetActive(true);
                boton3.SetActive(true);
                boton4.SetActive(true);
                botonCentral.SetActive(false);
                botonPausa.SetActive(true);

            }
        }
    }



}
