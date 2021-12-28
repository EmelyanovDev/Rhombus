using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private ScoreMoney _scoreMoney;
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private Animator _moneyNotificationAnimator;
    [SerializeField] private Animator _menuAnimator;
    [SerializeField] private GameObject _abilityButton;
    [SerializeField] private AudioSource _coinSound;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private GameObject _pauseButton;

    private Rigidbody2D _rigidbody;
    [HideInInspector] public Animator _playerAnimator;
    private Camera _camera;
    private CapsuleCollider2D _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _camera = Camera.main;
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        Invoke(nameof(EnableAnimator), 0.01f);
    }

    private void EnableAnimator()
    {
        _playerAnimator.enabled = true;
    }

    private void FixedUpdate()
    {
        //_rigidbody.velocity = _joystick.Direction * (_moveSpeed * Time.deltaTime);
        _rigidbody.AddForce(_joystick.Direction * _moveSpeed);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _moneyNotificationAnimator.Play("MoneyNotification");
            _scoreMoney.ChangeMoneyCount(1);
            _coinSound.Play();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Obstacle obstacle) || other.CompareTag("VisibleZone"))
        {
            Die(false, false, "PlayerDeath", 0, "MenuCreate", false);
        }
    }

    public void Die(bool abillityButton, bool joystick, string playerAnimation, float timeScale, string menuAnimation, bool pauseButton)
    {
        _abilityButton.SetActive(abillityButton);
        _joystick.gameObject.SetActive(joystick);
        _deathEffect.Play();
        _playerAnimator.Play(playerAnimation);
        Time.timeScale = timeScale;
        _menuAnimator.Play(menuAnimation);
        _deathSound.Play();
        _pauseButton.SetActive(pauseButton);
    }
}