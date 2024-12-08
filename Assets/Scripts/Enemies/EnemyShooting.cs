using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    [SerializeField] private float timer;
    private GameObject player;
    private Animator animator;

    [Header("Audio")]
    [SerializeField] private AudioClip shootSound; // Assign your snowball sound effect here
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

        // Play the shooting sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
