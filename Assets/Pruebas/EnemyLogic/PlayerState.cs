using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Control sobre el estado del jugador.
/// </summary>
public class PlayerState : MonoBehaviour
{
    public Image healthBar;

    public static float actualHealth;

    private float maxHealth = 10;

    public GameObject menuMuerte;
    /// <summary>
    /// Vida del jugador.
    /// </summary>
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        actualHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = actualHealth / maxHealth;
    }
    /// <summary>
    /// Daña al jugador
    /// </summary>
    /// <param name="damage">Cantidad de daño recibida por el jugador</param>
    public void damagePlayer(int damage)
    {
        life-=damage;
        Debug.Log("Jugador dañado");
        if(life<=0)
        {
            killPlayer();
        }
    }
    /// <summary>
    /// Mata al jugador.
    /// </summary>
    private void killPlayer()
    {
        Debug.Log("Jugador muerto");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            actualHealth--;

            if (actualHealth == 0)
            {
                menuMuerte.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
