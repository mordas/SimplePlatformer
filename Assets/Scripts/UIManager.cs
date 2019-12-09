using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coins, _lifesText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins(int score){
        _coins.text = "Coins: " + score;
    }

    public void updateLives(int li)
    {
        _lifesText.text = "Lifes: " + li;
    }
}
