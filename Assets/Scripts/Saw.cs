using UnityEngine;

public class Saw : MonoBehaviour
{
    private float _rotateSpeed;

    private float _moveSpeed;

    private Vector2 _purposePoint;
    
    private VariablesList _variablesList;

    private float _moveSpeedSpread = 0.1f;

    private float _timeBeforeDestroy;

    private GameObject _player;

    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private SawDestroyEffect _destroyLogic;

    private void Start()
    {
        _variablesList = Camera.main.gameObject.GetComponent<VariablesList>();

        _player = _variablesList.Player;

        _moveSpeed = _variablesList.SawMoveSpeed + Random.Range(-_moveSpeedSpread, _moveSpeedSpread); //получить скорость пилы + небольшой разброс

        _timeBeforeDestroy = _variablesList.SawDestroyTime;

        _rotateSpeed = _moveSpeed * 125;    

        if (Random.Range(0, 2) == 0) //в какую сторону будет вращаться пила
        {
            _rotateSpeed *= -1;
        }
        
        Invoke(nameof(Destroy), _timeBeforeDestroy);
    }
    
    private void FixedUpdate()
    {
        _purposePoint = _player.transform.position;
        
        transform.position = Vector3.MoveTowards(transform.position, _purposePoint, _moveSpeed * Time.deltaTime);

        transform.Rotate(0,0,_rotateSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        _destroyLogic.Destroy();
        _destroyEffect.gameObject.transform.SetParent(null);
        _destroyEffect.Play();
        Destroy(gameObject);
    }
}
