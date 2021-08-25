using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public static FoodScript instance;
    [SerializeField] private BoxCollider2D spawnArea;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ChangePosition();
    }

    public void ChangePosition()
    {
        Bounds bounds = spawnArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }
}
