using UnityEngine;
using UnityEngine.UI;

public class OutLine : Product
{
    [SerializeField] private Color _outLineColor;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey($"Skin{SkinNumber}Buyed"))
        {
            Buyed = true;
            PriceText.color = new Color(0.6941177f, 0.9019608f, 0.5764706f);
        }
        
        if (PlayerPrefs.HasKey("OutLineNow"))
        {
            if (PlayerPrefs.GetInt("OutLineNow") == SkinNumber)
            {
                ShopLogic.Color = _outLineColor;
                ShopLogic.OutLine(this, Buyed, Price);
            }
        }
    }
    
    public override void ButtonClick()
    {
        ShopLogic.Color = _outLineColor;
        ShopLogic.OutLine(this, Buyed, Price);
        if (Buyed)
        {
            PlayerPrefs.SetInt("OutLineNow", SkinNumber);
        }
    }
    
    public override void ChangeBuyedCondition()
    {
        Buyed = true;
        PriceText.color = new Color(0.6941177f, 0.9019608f, 0.5764706f);
        PlayerPrefs.SetInt($"Skin{SkinNumber}Buyed", 1);
        PlayerPrefs.SetInt("OutLineNow", SkinNumber);
    }
}