using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    [SerializeField] private float timer;
    private GameObject player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 70)
        {
            timer += Time.deltaTime;

            if (timer > 6)
            {
                timer = 0;
                TriggerAttack();
            }
        }
    }

    void TriggerAttack()
    {
        animator?.SetTrigger("Attack");
        StartCoroutine(ShootAfterDelay(0.5f));
    }

    IEnumerator ShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        shoot();
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
