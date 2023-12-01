using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Generador de enemigos.
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    /// <summary>
    /// Prefab del enemigo
    /// </summary>
    public GameObject enemyPrefab;
    /// <summary>
    /// Objetivo hacia el que se moverá el enemigo generado.
    /// </summary>
    public GameObject targetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GenerateEnemy();
        }

    }
    /// <summary>
    /// Genera un enemigo
    /// </summary>
    public void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.targetEnemy= targetEnemy;
    }
}
