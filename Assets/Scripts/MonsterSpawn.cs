using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 引用UnityEngine.UI命名空间

public class MonsterSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject monsterPre;
    public Text winText; // 新增：引用UI Text对象

    private int monsterDeathCount = 0; // 计数器，记录怪物死亡次数
    private const int maxMonsterDeaths = 3; // 定义最大怪物死亡次数

    private void Start()
    {
        Monster.onMonsterDead += SpawnMonster;
        winText.gameObject.SetActive(false); // 初始状态隐藏“ You win”文本
    }

    public void SpawnMonster()
    {
        if (monsterDeathCount >= maxMonsterDeaths)
        {
            // 如果怪物死亡次数达到或超过最大值，则显示“ You win”文本
            winText.gameObject.SetActive(true);
            winText.text = "You win!";
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(monsterPre, spawnPoints[randomIndex].position, Quaternion.identity);
        monsterDeathCount++; // 每次生成怪物时增加计数
    }

    private void OnDestroy()
    {
        Monster.onMonsterDead -= SpawnMonster; // 确保在销毁时解除事件订阅，避免内存泄漏
    }
}
