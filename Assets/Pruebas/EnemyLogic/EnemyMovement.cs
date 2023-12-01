using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Componente NavMeshAgent del enemigo.
    /// </summary>
    public NavMeshAgent enemyAgent;
    /// <summary>
    /// Objetivo hacia el que se mueve el enemigo.
    /// </summary>
    public GameObject targetEnemy;
    /// <summary>
    /// Vida del enemigo.
    /// </summary>
    public int life = 0;
    /// <summary>
    /// Fuerza de ataque del enemigo
    /// </summary>
    public int attackForce = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(targetEnemy.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            attack();
        }
        else if (collision.gameObject.tag.Equals("Projectile"))
        {
            //Si un proyectil alcanza al enemigo, este se daña.
            damageEnemy();
        }
    }
    /// <summary>
    /// Rutina de ataque
    /// </summary>
    private void attack()
    {
        //Destruimos de momento el Game Object del enemigo, cuando este la lógica del jugador, haremos que dañe al jugador.
        PlayerState player = targetEnemy.GetComponent<PlayerState>();
        player.damagePlayer(attackForce);
        killEnemy();
    }
    /// <summary>
    /// Rutina de muerte del enemigo.
    /// </summary>
    private void killEnemy()
    {
        GameObject.Destroy(this.gameObject);
    }
    /// <summary>
    /// Rutina de daño del enemigo.
    /// </summary>
    private void damageEnemy()
    {
        life--;
        if(life<=0)
        {
            killEnemy();
        }
    }
}
