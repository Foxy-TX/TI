using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance;
    public List<EntradaRanking> ranking;
    [SerializeField] private string playerNickname;

    string caminhoSalvar;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        caminhoSalvar = Application.persistentDataPath + "/ranking.json";
        CarregarRanking();
    }
    public void AdicionarEntrada(float score)
    {
        if(score <= 0) return;

        EntradaRanking novaEntrada = new EntradaRanking();
        if (string.IsNullOrEmpty(playerNickname))
        {
            novaEntrada.nome = "NoName";
        }
        else
        {
            novaEntrada.nome = playerNickname;
        }
        novaEntrada.score = score;
        novaEntrada.data = DateTime.Now.ToString("yy-MM-dd");
        ranking.Add(novaEntrada);
        ranking.Sort((x, y) => y.score.CompareTo(x.score));
        if (ranking.Count > 20)
        {
            ranking.RemoveAt(ranking.Count - 1);
        }
        SalvarRanking();
    }

    public void SetPlayerNickname(string nick)
    {
        playerNickname = nick;
    }

    [ContextMenu("SalvarRanking")]
    public void SalvarRanking()
    {
        // Serializa o ranking em um array de Json
        // Não esquecer de baixar o Script JsonHelper.cs e anexar ao seu projeto, senão não irá funcionar!
        string json = JsonHelper.ToJson(ranking.ToArray());
        //salvo a string em um arquivo  de texto no caminho especificado
        File.WriteAllText(caminhoSalvar, json);
    }

    [ContextMenu("CarregarRanking")]
    public void CarregarRanking()
    {
        ranking = new List<EntradaRanking>();
        // lê o json salvo em um arquivo de texto no caminho especificado
        string jsonSalvo = File.ReadAllText(caminhoSalvar);
        // transforma a string em um array de Conquistas
        // Não esquecer de baixar o Script JsonHelper.cs e anexar ao seu projeto, senão não irá funcionar!
        EntradaRanking[] rankingContainer = JsonHelper.FromJson<EntradaRanking>(jsonSalvo);
        Debug.Log(rankingContainer.Length);

        // Atualiza minhas conquistas atuais
        for (int i = 0; i < rankingContainer.Length; i++)
        {
            EntradaRanking entradaSalva = new EntradaRanking();
            entradaSalva.nome = rankingContainer[i].nome;
            entradaSalva.score = rankingContainer[i].score;
            entradaSalva.data = rankingContainer[i].data;
            ranking.Add(entradaSalva);

        }
    }
}

[System.Serializable]
public class EntradaRanking
{
    public string nome;
    public float score;
    public string data;
}

