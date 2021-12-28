using UnityEngine;
using UnityEngine.UI;

public abstract class Product : MonoBehaviour
{
    public ShopLogic ShopLogic;
    public bool Buyed;
    public int Price;
    public int SkinNumber;
    public Text PriceText;
    public abstract void ButtonClick();
    public abstract void ChangeBuyedCondition();

}