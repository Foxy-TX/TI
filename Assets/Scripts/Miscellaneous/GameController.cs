using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private int _pontos = 0;
    private int vida = 10;
    public TMP_Text pontuacoText;
    public TMP_Text HealthText;
    public GameObject btn_tryAgain;
    public static GameController instance;

    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AdicionarPontos()
    {
        _pontos ++;
        pontuacoText.text = "Pontos: " + _pontos.ToString();
    }

    public void GameOver()
    {
        vida --;
        HealthText.text = "Vida: " + vida.ToString();
        if(vida == 0){
        btn_tryAgain.SetActive(true);
    }
    }

    public void EnemyShield()
    {
        btn_tryAgain.SetActive(true);
    }

    public void CheatVida(){
        vida = 10;
        if(vida < 10){
            vida = 10;
            HealthText.text = "Vida: " + vida.ToString();
        }
    }

    public void Power_Up(){
        vida += 5;
        HealthText.text = "Vida: " + vida.ToString();
    }
}
