using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ilustracion1;
    public GameObject ilustracion2;
    public GameObject interfaz;
    public GameObject fondoIlustracion;
    public static int contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        ilustracion1.SetActive(true);
        fondoIlustracion.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (ilustracion1.activeSelf || ilustracion2.activeSelf)
        {
            // Verifica si se presiona la tecla X
            if (Input.GetKeyDown(KeyCode.X) && contador == 0)
            {
                // Desactiva ilustracion1 y activa ilustracion2
                ilustracion1.SetActive(false);
                ilustracion2.SetActive(true);
                contador++;
            }
             
            else if (Input.GetKeyDown(KeyCode.X) && contador==1)
            {
                // Desactiva ilustracion2
                ilustracion2.SetActive(false);
                fondoIlustracion.SetActive(false);
                interfaz.SetActive(true);
                EnemyGeneratorManager.generationRatio = 1;
                contador++;
            }
        }
    }
}