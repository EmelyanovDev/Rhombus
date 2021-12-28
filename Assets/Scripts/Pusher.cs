using UnityEngine;

public class Pusher : MonoBehaviour
{
    private float _pushDelay;
    private Animator _pusherAnim;
    private AudioSource _pusherSound;
    private VariablesList _variablesList;

    [SerializeField] private bool _isHorizontalPusher;
    private void Start()
    {
        _pusherAnim = GetComponent<Animator>();

        _variablesList = Camera.main.GetComponent<VariablesList>();
        _pushDelay = _variablesList.PushDelay;
        _pusherSound = _variablesList.PusherSound;
        
        Invoke(nameof(Push), _pushDelay);
    }
    

    private void Push()
    {
        if (_isHorizontalPusher)
        {
            _pusherAnim.Play("HorizontalPusherComplexion");
        }
        else
        {
            _pusherAnim.Play("VerticalPusherComplexion");
        }
        _pusherSound.Play();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
