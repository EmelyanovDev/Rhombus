using System.Collections;
using UnityEngine;

public class CoinCreate : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;

    [SerializeField] private float _createDelay;

    private Vector2 _createPosition;

    private int _coinDirection;

    private VariablesList _variablesList;
    private void Start()
    {
        _variablesList = Camera.main.GetComponent<VariablesList>();
        
        StartCoroutine(CreateCoin());
    }

    private IEnumerator CreateCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(_createDelay);

            Coin generatedCoin = Instantiate(_coinTemplate, Vector3.zero, Quaternion.identity);
            _coinDirection = Random.Range(0, 4); //определяет, куда будет двигаться монетка
            switch (_coinDirection)
            {
                case 0:
                    SetCoin(generatedCoin, new Vector2(_variablesList.CoinSpeed, 0), new Vector2(-4f, Random.Range(-4f, 4f)));
                    break;
                case 1:
                    SetCoin(generatedCoin, new Vector2(0, -_variablesList.CoinSpeed), new Vector2(Random.Range(-2.5f, 2.5f), 6f));
                    break;
                case 2:
                    SetCoin(generatedCoin, new Vector2(-_variablesList.CoinSpeed, 0), new Vector2(4f, Random.Range(-4f, 4f)));
                    break;
                case 3:
                    SetCoin(generatedCoin, new Vector2(0, _variablesList.CoinSpeed), new Vector2(Random.Range(-2.5f, 2.5f), -6f));
                    break;
            }
        }
    }
    
    private void SetCoin(Coin generatedCoin, Vector2 transformSpeed, Vector2 position)
    {
        generatedCoin.TransformSpeed = transformSpeed;
        generatedCoin.transform.position = position;
    }
}
