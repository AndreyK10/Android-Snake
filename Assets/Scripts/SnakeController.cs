using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    private List<GameObject> segments = new List<GameObject>();
    [SerializeField] private GameObject segment;
    private Vector2 direction = Vector2.left;
    [SerializeField] private float timeBeforeMovement;
    private float _timeBeforeMovement;
    [SerializeField] private int initialSize;
    public static int initialScore;

    private void Awake()
    {
        initialScore = initialSize;
        _timeBeforeMovement = PlayerPrefs.GetFloat("Speed");
        if (_timeBeforeMovement >= 0.05f && _timeBeforeMovement <= 0.2f) timeBeforeMovement = _timeBeforeMovement;
    }

    private void Start()
    {
        segments.Add(gameObject);
        for (int i = 0; i < initialSize; i++)
        {
            segments.Add(Instantiate(segment));
        }
        StartCoroutine(StartMovement());
    }
    public void TurnUp()
    {
        if (direction != Vector2.down) direction = Vector2.up;
    }
    public void TurnDown()
    {
        if (direction != Vector2.up) direction = Vector2.down;
    }
    public void TurnLeft()
    {
        if (direction != Vector2.right) direction = Vector2.left;
    }
    public void TurnRight()
    {
        if (direction != Vector2.left) direction = Vector2.right;
    }

    private void Move()
    {
        transform.position = new Vector3((Mathf.Round(transform.position.x) + direction.x), (Mathf.Round(transform.position.y) + direction.y), 0f);
    }

    private IEnumerator StartMovement()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(timeBeforeMovement);
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].transform.position = segments[i - 1].transform.position;
            }
        }
    }

    private void Grow()
    {
        GameObject obj = Instantiate(segment);
        obj.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FoodScript>())
        {
            FoodScript.instance.ChangePosition();
            Handheld.Vibrate();
            Grow();
            ScoreController.instance.IncreaseScore();
        }
        if (collision.CompareTag("Obstacle"))
        {
            GameplayController.isDead = true;
        }
    }
}
