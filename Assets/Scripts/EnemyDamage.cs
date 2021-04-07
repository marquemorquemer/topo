using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float damageTime;
    private float counter;
    public bool hasHit;
    bool playerInRange;
    public Health hp;
    public GameObject player;
    


    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit)
        {
            counter += Time.deltaTime;
            if (counter > damageTime)
            {
                counter = 0;
                hasHit = false;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (!hasHit)
            {
                Destroy(gameObject);
                hasHit = true;
                SceneManager.LoadScene("Inicial");
            }
        }
    }
}
