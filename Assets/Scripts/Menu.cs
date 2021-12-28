using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    private Animator _menuAnimator;
    private bool _restartScene;
    [SerializeField] private Animator _shopAnimator;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private AudioSource _buttonSound;
    [SerializeField] private AudioSource _disagreeSound;
    [SerializeField] private GameObject _abilityButton;
    [SerializeField] private GameObject _rebornButton;
    [SerializeField] private Text _countDownText;

    [SerializeField] private GameObject _pauseYes;
    [SerializeField] private GameObject _pauseNo;

    private void Start()
    {
        _menuAnimator = GetComponent<Animator>();
        Advertisement.Initialize("4380313");
    }
    
    
    private void RestartButton()
    {
        _menuAnimator.Play("MenuLeave");
        _restartScene = true;
        _buttonSound.Play();
    }
    
    private void RestartActiveScene()
    {
        if (_restartScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void ShopButton()
    {
        _menuAnimator.Play("MenuLeave");
        _shopAnimator.Play("ShopCreate");
        _buttonSound.Play();
    }

    private void ShopExitButton()
    {
        _shopAnimator.Play("ShopLeave");
        _menuAnimator.Play("MenuCreate");
        _buttonSound.Play();
    }

    private void RebornButton()
    {
        if (Advertisement.IsReady())
        {
            StartCoroutine(AdvertisementWatch());
        }
        else
        {
            _disagreeSound.Play();
        }
    }

    private IEnumerator AdvertisementWatch()
    {
        Advertisement.Show("Rewarded_Android");

        _playerMove.Die(true, true, "none", 0f, "MenuLeave", true);
        _buttonSound.Play();
        
        Destroy(_rebornButton);

        _countDownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            _countDownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        Destroy(_countDownText);
        _playerMove._playerAnimator.Play("PlayerInvisible");
        Time.timeScale = 1f;
    }

    public void PauseButton()
    {
        switch (Time.timeScale)
        {
            case 0f:
                Time.timeScale = 1f;
                _pauseNo.SetActive(true);
                _pauseYes.SetActive(false);
                break;
            case 1f:
                Time.timeScale = 0f;
                _pauseNo.SetActive(false);
                _pauseYes.SetActive(true);
                break;
        }
    }
}
