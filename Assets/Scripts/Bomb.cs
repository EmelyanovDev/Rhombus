using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator _animator;
    private VariablesList _variablesList;
    private AudioSource _explosionSound;
    [SerializeField] private ParticleSystem _exposionEffect;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _variablesList = Camera.main.GetComponent<VariablesList>();
        _explosionSound = _variablesList.BombSound;
        _animator.SetFloat("speed", Camera.main.GetComponent<VariablesList>().DetonateSpeed);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void Exposion()
    {
        _exposionEffect.Play();
        _explosionSound.Play();
    }
}
