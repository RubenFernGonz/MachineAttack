using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Administrador de los generadores de enemigos.
/// </summary>
public class EnemyGeneratorManager : MonoBehaviour
{
    /// <summary>
    /// Lista con los generadores de enemigos.
    /// </summary>
    private EnemyGenerator[] enemyGenerators;
    /// <summary>
    /// Segundos que tarda en generarse una nueva oleada de enemigos.
    /// </summary>
    public float waveFreq;
    /// <summary>
    /// Cantidad de enemigos que se generan en las oleadas.
    /// </summary>
    public static int generationRatio = 0;
    /// <summary>
    /// Aumento de enemigos establecido para cada final de fase, por defecto es dos (se duplica la cantidad de enemigos generados tras cada fase).
    /// </summary>
    public int augmentRatio = 2;
    /// <summary>
    /// Cantidad de oleadas que conforman una fase.
    /// </summary>
    public int wavesInAPhase = 1;
    /// <summary>
    /// Cantidad máxima de enemigos a generar.
    /// </summary>
    private int maxEnemies;
    /// <summary>
    /// Contador de oleadas.
    /// </summary>
    private int wavesCounter;
    // Start is called before the first frame update
    void Start()
    {
        enemyGenerators = GameObject.FindObjectsOfType<EnemyGenerator>();
        maxEnemies = enemyGenerators.Length;
        StartCoroutine(generatingWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Genera los enemigos de una oleada.
    /// </summary>
    private void generateEnemies()
    {
        //Seleccionamos de forma aleatoria los generadores de la oleada
        List<int> indexGenerators = new List<int>();
        for(int i = 0; i < generationRatio; i++)
        {
            bool repeated = true;
            int index = -1;
            while (repeated)
            {
                index = Random.Range(0, maxEnemies);
                if (!indexGenerators.Contains(index)) repeated = false;
            }
            indexGenerators.Add(index);
        }
        for(int i=0; i < indexGenerators.Count; i++)
        {
            int selectedIndex = indexGenerators[i];
            enemyGenerators[selectedIndex].GenerateEnemy();
        }
    }
    /// <summary>
    /// Genera la oleada.
    /// </summary>
    private void generateWave()
    {
        generateEnemies();
        wavesCounter++;
        if(wavesCounter == wavesInAPhase)
        {
            wavesCounter = 0;
            generationRatio = generationRatio * augmentRatio;
            if(generationRatio > maxEnemies)
            {
                generationRatio = maxEnemies;
            }
        }
    }
    /// <summary>
    /// Corutina para generar los enemigos de forma constante.
    /// </summary>
    /// <returns></returns>
    private IEnumerator generatingWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveFreq);
            generateWave();
        }
    } 
}
