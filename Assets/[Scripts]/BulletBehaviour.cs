using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public BulletType Type;


    [Header("Bullet Movement")]
    
    [Range(0.0f,0.5f)]
    public float Speed;
    public Bounds bulletBounds;
    public BulletDirection direction;

    private BulletManager bulletManager;
    private Vector3 BulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();

        switch(direction)
        {
            case BulletDirection.UP:
                BulletVelocity = new Vector3(0.0f, Speed,0.0f);
                break;

            case BulletDirection.DOWN:
                BulletVelocity = new Vector3(0.0f, -Speed, 0.0f);
                break;

            case BulletDirection.RIGHT:
                BulletVelocity = new Vector3(Speed, 0.0f, 0.0f);
                break;

            case BulletDirection.LEFT:
                BulletVelocity = new Vector3(-Speed, 0.0f, 0.0f);
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += BulletVelocity;
        //transform.position -= new Vector3(0.0f, Speed, 0.0f);
    }

    private void CheckBounds()
    {
        //Check Bottom Bounds
        if (transform.position.y < bulletBounds.Max)
        {
            //Destroy(this.gameObject);
            bulletManager.ReturnBullet(this.gameObject , Type);
        }

        //Check Top Bounds
        if (transform.position.y > bulletBounds.Min)
        {
            //Destroy(this.gameObject);
            bulletManager.ReturnBullet(this.gameObject, Type);
        }
    }
}
