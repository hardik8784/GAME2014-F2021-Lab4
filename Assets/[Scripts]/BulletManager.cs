using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> EnemyBulletPool;
    public Queue<GameObject> PlayerBulletPool;
    public int EnemyBulletNumber;
    public int PlayerBulletNumber;
    //public GameObject bulletPrefab;

    private BulletFactory Factory;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBulletPool = new Queue<GameObject>();     //Empty Queue Created   
        PlayerBulletPool = new Queue<GameObject>();     //Empty Queue Created
        Factory = GetComponent<BulletFactory>();    //Reference to the Bullet Factory Code
        //BuildBulletPool();
    }

    ///// <summary>
    ///// This method builds a bulletpool with EnemyBulletNumber bullets
    ///// </summary>
    //private void BuildBulletPool()
    //{
    //    for(int i=0; i < EnemyBulletNumber;i++ )
    //    {
    //        Addbullet();
    //    }
    //}

    private void Addbullet(BulletType Type = BulletType.ENEMY)
    {
        var temp_bullet = Factory.CreateBullet();

        switch (Type)
        {
            case BulletType.ENEMY:
                EnemyBulletPool.Enqueue(temp_bullet);
                EnemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                PlayerBulletPool.Enqueue(temp_bullet);
                PlayerBulletNumber++;
                break;

        }
        
        //var temp_bullet = Instantiate(bulletPrefab);
        //temp_bullet.SetActive(false);
        //temp_bullet.transform.SetParent(transform);
        //EnemyBulletPool.Enqueue(temp_bullet);
    }

    /// <summary>
    /// This is used to remove the bullet from bulletpool
    /// and returns a referencec to itself.
    /// </summary>
    public GameObject GetBullet(Vector2 spawn_position, BulletType Type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch(Type)
        {
            case BulletType.ENEMY:
                if (EnemyBulletPool.Count < 1)
                {
                    Addbullet();
                    //EnemyBulletNumber++;
                }
                temp_bullet = EnemyBulletPool.Dequeue();
                temp_bullet.transform.position = spawn_position;
                temp_bullet.SetActive(true);
               
                break;
            case BulletType.PLAYER:
                if (PlayerBulletPool.Count < 1)
                {
                    Addbullet(BulletType.PLAYER);
                    //EnemyBulletNumber++;
                }
                temp_bullet = PlayerBulletPool.Dequeue();
                temp_bullet.transform.position = spawn_position;
                temp_bullet.SetActive(true);
                
                break;
        }
        return temp_bullet;
    }

    /// <summary>
    /// This method returns a bullet back to bulletpool
    /// </summary>
    public void ReturnBullet(GameObject returned_bullet, BulletType Type = BulletType.ENEMY)
    {
        returned_bullet.SetActive(false);

        switch (Type)
        {
            case BulletType.ENEMY:
                EnemyBulletPool.Enqueue(returned_bullet);
                break;
            case BulletType.PLAYER:
                PlayerBulletPool.Enqueue(returned_bullet);
                break;
        }
            

        
    }


}
