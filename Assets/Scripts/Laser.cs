using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _strikeDelay;
    private Animator _laserAnim;
    private VariablesList _variablesList;
    private AudioSource _laserSound;
    private void Start()
    {
        _laserAnim = GetComponent<Animator>();

        _variablesList = Camera.main.GetComponent<VariablesList>();
        
        _strikeDelay = _variablesList.StrikeDelay;

        _laserSound = _variablesList.LaserSound;
        
        Invoke(nameof(Strike), _strikeDelay);
    }

    private void Strike()
    {
        _laserAnim.Play("LaserStrike");
        _laserSound.Play();
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
