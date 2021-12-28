using System;
using UnityEngine;


public class TrailEffectProduct : Product
{
    [SerializeField] private Material _trailMaterial;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey($"Skin{SkinNumber}Buyed"))
        {
            Buyed = true;
            PriceText.color = new Color(0.6941177f, 0.9019608f, 0.5764706f);
        }

        if (PlayerPrefs.HasKey("TrailEffectNow"))
        {
            if (PlayerPrefs.GetInt("TrailEffectNow") == SkinNumber)
            {
                ShopLogic.Material = _trailMaterial;
                ShopLogic.TrailEffect(this, Buyed, Price);
            }
        }
    }

    public override void ButtonClick()
    {
        ShopLogic.Material = _trailMaterial;
        ShopLogic.TrailEffect(this, Buyed, Price);
        if (Buyed)
        {
            PlayerPrefs.SetInt("TrailEffectNow", SkinNumber);
        }
    }

    public override void ChangeBuyedCondition()
    {
        Buyed = true;
        PriceText.color = new Color(0.6941177f, 0.9019608f, 0.5764706f);
        PlayerPrefs.SetInt($"Skin{SkinNumber}Buyed", 1);
        PlayerPrefs.SetInt("TrailEffectNow", SkinNumber);
    }
}