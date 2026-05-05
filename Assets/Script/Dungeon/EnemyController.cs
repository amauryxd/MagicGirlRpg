using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<GameObject> enemys;
    public EnemysSOBActivate enemysSOBActivate;
    void Start()
    {
        if(!enemysSOBActivate.enemy1Active)
        {
            enemys[0].SetActive(false);
        }
        if(!enemysSOBActivate.enemy2Active)
        {
            enemys[1].SetActive(false);
        }
        if(!enemysSOBActivate.enemy3Active)
        {
            enemys[2].SetActive(false);
        }
        if(!enemysSOBActivate.enemy4Active)
        {
            enemys[3].SetActive(false);
        }
    }
}
