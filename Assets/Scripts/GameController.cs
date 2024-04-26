using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] interativos;
    public GameObject coin;
    private int _pontos = 0;
    private int vida = 10;
    public TMP_Text pontuacoText;
    public TMP_Text HealthText;
    public GameObject btn_tryAgain;
    public GameObject btn_Win;
    public static GameController instance;

    private Vector3 spawn = new Vector3(18, -3, -0);
    
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

    void Start()
    {
        InvokeRepeating(nameof(spawnCoins), 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemies()
    {
        int index = Random.Range(0, interativos.Length);
        GameObject selecionado = interativos[index];
        Instantiate(selecionado, spawn, selecionado.transform.rotation);
    }
    void spawnCoins()
    {
        Instantiate(coin, spawn, coin.transform.rotation);
    }

    public void AdicionarPontos()
    {
        _pontos ++;
        pontuacoText.text = "Pontos: " + _pontos.ToString();
        if(_pontos == 10){
            btn_Win.SetActive(true);
        }
    }

    public void GameOver()
    {
        vida --;
        HealthText.text = "Vida: " + vida.ToString();
        if(vida == 0){
        btn_tryAgain.SetActive(true);
    }
    }

    public void CheatVida(){
        vida = 10;
        if(vida < 10){
            vida = 10;
            HealthText.text = "Vida: " + vida.ToString();
        }
    }
}
