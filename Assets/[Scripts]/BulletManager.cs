using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int bulletNumber;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();     //Empty Queue Created   

        //BuildBulletPool();
    }

    /// <summary>
    /// This method builds a bulletpool with bulletNumber bullets
    /// </summary>
    private void BuildBulletPool()
    {
        for(int i=0; i < bulletNumber;i++ )
        {
            Addbullet();
        }
    }

    private void Addbullet()
    {
        var temp_bullet = Instantiate(bulletPrefab);
        temp_bullet.SetActive(false);
        temp_bullet.transform.SetParent(transform);
        bulletPool.Enqueue(temp_bullet);
    }

    /// <summary>
    /// This is used to remove the bullet from bulletpool
    /// and returns a referencec to itself.
    /// </summary>
    public GameObject GetBullet(Vector2 spawn_position)
    {
        if(bulletPool.Count <1)
        {
            Addbullet();
            bulletNumber++;
        }
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = spawn_position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    /// <summary>
    /// This method returns a bullet back to bulletpool
    /// </summary>
    public void ReturnBullet(GameObject returned_bullet)
    {
        returned_bullet.SetActive(false);
        bulletPool.Enqueue(returned_bullet);
    }


}
