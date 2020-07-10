using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clicker : MonoBehaviour
{
    public InputField hacks;

    public Text txt;
    public Text CarPrice;
    public Text HousePrice;
    public Text Shop;

    public int HousePriceInt = 5000;
    public int CarPriceInt = 1000;

    public int score;

    public int Car;
    public int House;
    void Start()
    {
        if (PlayerPrefs.HasKey("balance"))
        {
            score = PlayerPrefs.GetInt("balance");
        }
        if (PlayerPrefs.HasKey("house"))
        {
            House = PlayerPrefs.GetInt("house", House);
        }
        if (PlayerPrefs.HasKey("car"))
        {
            Car = PlayerPrefs.GetInt("car", Car);
        }
        
        CheckSold();
    }
    
    public void CheckSold()
    {
        if (Car == 1)
        {
            CarPrice.text = "SOLD!";
        }
        if (House == 1)
        {
            HousePrice.text = "SOLD!";
        }
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        score++;
        txt.text = $"Balance: {score}$";
        PPrefs();
    }

    public void ClickShop()
    {
        SceneManager.LoadScene("menu");
    }

    public void CloseShop()
    {
        SceneManager.LoadScene("main");
    }

    public void BuyCar()
    {
        if (score >= CarPriceInt)
        {
            score -= CarPriceInt;
            Car = 1;
            CheckSold();
            PPrefs();
        }
        else
        {
            Shop.text = "Not enough money!";
        }
    }
    public void BuyHouse()
    {
        if (score >= HousePriceInt)
        {
            score -= HousePriceInt;
            House = 1;
            CheckSold();
            PPrefs();
        }
        else
        {
            Shop.text = "Not enough money!";
        }
    }

    public void OpenHack()
    {
        SceneManager.LoadScene("hack");
    }
    public void Hack()
    {
        if (hacks.text == "Hereigo")
        {
            score += 100000;
            PPrefs();
        }
        if (hacks.text == "NoHereigo")
        {
            score = 0;
            PPrefs();
        }
    }

    private void PPrefs()
    {
        PlayerPrefs.SetInt("balance", score);
        PlayerPrefs.SetInt("car", Car);
        PlayerPrefs.SetInt("house", House);
    }
}
