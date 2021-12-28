using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopLogic : MonoBehaviour
{
    [HideInInspector] public Material Material;
    [HideInInspector] public Color Color;

    [SerializeField] private ScoreMoney _scoreMoney;

    [SerializeField] private ParticleSystemRenderer _trailRenderer;
    [SerializeField] private SpriteRenderer _outLine;

    [SerializeField] private AudioSource _agreeSound;
    [SerializeField] private AudioSource _disAgreeSound;

    public void TrailEffect(TrailEffectProduct trailEffectProduct, bool buyed, int price)
    {
        if (buyed)
        {
            _trailRenderer.material = Material;
            _agreeSound.Play();
        }
        else
        {
            if (_scoreMoney.MoneyCount >= price)
            {
                _scoreMoney.ChangeMoneyCount(-price);
                trailEffectProduct.ChangeBuyedCondition();
                _trailRenderer.material = Material;
                _agreeSound.Play();
            }
            else
            {
                _disAgreeSound.Play();
            }
        }
    }

    public void OutLine(OutLine outLine, bool buyed, int price)
    {
        if (buyed)
        {
            _outLine.color = Color;
            _agreeSound.Play();
        }
        else
        {
            if (_scoreMoney.MoneyCount >= price)
            {
                _scoreMoney.ChangeMoneyCount(-price);
                outLine.ChangeBuyedCondition();
                _outLine.color = Color;
                _agreeSound.Play();
            }
            else
            {
                _disAgreeSound.Play();
            }
        }
        
    }
}
