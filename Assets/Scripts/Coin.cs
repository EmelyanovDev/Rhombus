using UnityEngine;

public class Coin : MonoBehaviour
{
    [HideInInspector] public Vector2 TransformSpeed;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    
    private void Update()
    {
        transform.Translate(TransformSpeed * Time.deltaTime);
    }
    
}
