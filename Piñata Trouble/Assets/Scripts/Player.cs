using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private List<GameObject> bullets = new List<GameObject>();

    public Transform leftWall;
    public Transform rightWall;

    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite idleSprite;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pinata"))
        {
            if(GameManager.Instance.canTakeDamage)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }
    private void HandleMovement()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.LeftArrow) && pos.x > -11.35f)
        {
            pos += Vector3.left * moveSpeed * Time.deltaTime;
            spriteRenderer.sprite = leftSprite;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && pos.x < 11.35f)
        {
            pos += Vector3.right * moveSpeed * Time.deltaTime;
            spriteRenderer.sprite = rightSprite;
        }

        else
            spriteRenderer.sprite = idleSprite;

        transform.position = pos;
    }
    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            bullets.Add(bullet);

            Destroy(bullet, 1.5f);
        }

        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            GameObject b = bullets[i];
            if (b != null)
            {
                b.transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
            }
            else
            {
                bullets.RemoveAt(i);
            }
        }
    }
}
