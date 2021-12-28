using UnityEngine;
using UnityEngine.UI;

public class ScoreMoney : MonoBehaviour
{
    private int _scoreCount;
    [SerializeField] private Text _scoreText;

    public int MoneyCount;
    [SerializeField] private Text[] _moneyText;

    private int _recordCount;
    [SerializeField] private Text _recordText;

    private float _oneSecondTimer = 1;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            _recordCount = PlayerPrefs.GetInt("Record");
            _recordText.text = ":" + _recordCount;
        }

        if (PlayerPrefs.HasKey("Money"))
        {
            MoneyCount = PlayerPrefs.GetInt("Money");
            foreach (var text in _moneyText)
            {
                text.text = ":" + MoneyCount;
            }
        }
            
    }
    
    private void Update()
    {
        _oneSecondTimer -= Time.deltaTime;
        if (_oneSecondTimer <= 0)
        {
            _scoreCount++;
            _scoreText.text = ":" + _scoreCount;

            if (_scoreCount > _recordCount)
            {
                _recordCount = _scoreCount;
                _recordText.text = ":" + _recordCount;
                PlayerPrefs.SetInt("Record", _recordCount);
            }
            
            _oneSecondTimer = 1f;
        }
    }

    public void ChangeMoneyCount(int count)
    {
        MoneyCount += count;
        foreach (var text in _moneyText)
        {
            text.text = ":" + MoneyCount;
        }
        PlayerPrefs.SetInt("Money", MoneyCount);
    }
}
