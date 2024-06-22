using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MonsterSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject monsterPre;
    public Text winText; 
    private int monsterDeathCount = 0;  // counter for monster deaths
    private const int maxMonsterDeaths = 4; 

    private void Start()
    {
        Monster.onMonsterDead += SpawnMonster;
        winText.gameObject.SetActive(false);  // ensure win text is hidden at start
    }

    public void SpawnMonster()
    {
        if (monsterDeathCount >= maxMonsterDeaths)
        {   
            // display win text
            winText.gameObject.SetActive(true);
            winText.text = "You win!";
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(monsterPre, spawnPoints[randomIndex].position, Quaternion.identity);
        monsterDeathCount++; 
    }

    private void OnDestroy()
    {
        Monster.onMonsterDead -= SpawnMonster; 
    }
}
