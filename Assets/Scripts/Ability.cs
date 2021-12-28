using System;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private float _abilityDelay;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _eye;
    private Animator _playerAnimator;
    private float _startAbilityDelay;

    private void Start()
    {
        _startAbilityDelay = _abilityDelay;
        _playerAnimator = _player.GetComponent<Animator>();
        _abilityDelay = 0;
    }

    public void InvisibleAbility()
    {
        if (_abilityDelay <= 0)
        {
            _eye.SetActive(false);

            _abilityDelay = _startAbilityDelay;
            
            _playerAnimator.Play("PlayerInvisible");
        }
    }

    private void Update()
    {
        _abilityDelay -= Time.deltaTime;
        if (_abilityDelay <= 0)
        {
            if (!_eye.activeInHierarchy)
            {
                _eye.SetActive(true);
            }
        }
    }
}
