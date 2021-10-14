using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject EnemyBullet;
    public GameObject PlayerBullet;

    public GameObject CreateBullet(BulletType Type = BulletType.ENEMY)
    {
        GameObject Temp_Bullet = null;

        switch(Type)
        {
            case BulletType.ENEMY:
                Temp_Bullet = Instantiate(EnemyBullet);
                break;
            case BulletType.PLAYER:
                Temp_Bullet = Instantiate(PlayerBullet);
                break;
        }

        Temp_Bullet.transform.parent = transform;
        Temp_Bullet.SetActive(false);
        return Temp_Bullet;
    }
}
