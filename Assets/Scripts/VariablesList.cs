using System.Collections;
using UnityEngine;

public class VariablesList : MonoBehaviour
{
    [SerializeField] private float _changeDifficultDelay;
    
    [Header("Variables")]
    [SerializeField] private GameObject _player;
    [SerializeField] private float _pushDelay;
    [SerializeField] private float _detonateSpeed;
    [SerializeField] private float _strikeDelay;
    [SerializeField] private float _coinSpeed;
    [SerializeField] private float _SawDestroyTime;
    [SerializeField] private float _sawMoveSpeed;
    [SerializeField] private float _bulletMoveSpeed;

    [Header("Sounds")]
    public AudioSource PusherSound;
    public AudioSource LaserSound;
    public AudioSource BombSound;

    public GameObject Player => _player;
    public float PushDelay => _pushDelay;
    public float DetonateSpeed => _detonateSpeed;
    public float StrikeDelay => _strikeDelay;
    public float CoinSpeed => _coinSpeed;
    public float SawDestroyTime => _SawDestroyTime;
    public float SawMoveSpeed => _sawMoveSpeed;
    
    public float BulletMoveSpeed => _bulletMoveSpeed;

    private void Start()
    {
        StartCoroutine(ChangeDifficult());
    }

    private IEnumerator ChangeDifficult()
    {
        while (true)
        {
            yield return new WaitForSeconds(_changeDifficultDelay);
                
            _pushDelay *= 0.9f;
            _detonateSpeed *= 1.1f;
            _strikeDelay *= 0.9f;
            _SawDestroyTime *= 1.1f;
            _sawMoveSpeed *= 1.1f;
            _bulletMoveSpeed *= 1.1f;
        }
    }
}
