using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Bounds movementBounds;
    public Bounds StartingRange;

    [Header("Bullets")]
    public Transform bulletSpawn;
    //public GameObject bulletPrefab;
    public int FrameDelay;
    
    private float StartingPoint;
    private float RandomSpeed;
    private BulletManager bulletManager;


    // Start is called before the first frame update
    void Start()
    {
        RandomSpeed = Random.Range(movementBounds.Min, movementBounds.Max);
        StartingPoint = Random.Range(StartingRange.Min, StartingRange.Max);
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, RandomSpeed) + StartingPoint, transform.position.y);
    }

    void FixedUpdate()
    {
        if(Time.frameCount % FrameDelay == 0)
        {
            //var temp_bullet = Instantiate(bulletPrefab);
            //temp_bullet.transform.position = bulletSpawn.position;
            bulletManager.GetBullet(bulletSpawn.position);

        }
    }
}
