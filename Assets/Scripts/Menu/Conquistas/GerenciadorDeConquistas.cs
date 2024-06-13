using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class GerenciadorDeConquistas : MonoBehaviour
{
    public static GerenciadorDeConquistas instance;
    public List<Conquista> conquistas;
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
        caminhoSalvar = Application.persistentDataPath + "/conquistas.json";
        CarregarConquistas();
    }
    public void ConquistaQuaseCompleta()
    {

        if (ValidarSeConquistaFoiHabilitada(0) == true)
        {
            // A conquista ja foi destravada!
            return;
        }
        if (GameController.instance._pontos > 10f)
        {
            conquistas[0].conquistaAtivada = true;
            Debug.Log("Uma Nova Conquista foi destravada: " + conquistas[0].nome);
        }
    }

    public void ImuneAMorte()
    {
        if (ValidarSeConquistaFoiHabilitada(1) == true) return;
        if (Level2.instance.conq== true)
        {
            conquistas[1].conquistaAtivada = true;
            Debug.Log("Uma Nova Conquista foi destravada: " + conquistas[1].nome);
        }
    }

    public bool ValidarSeConquistaFoiHabilitada(int id)
    {
        bool resultado = false;
        for (int i = 0; i < conquistas.Count; i++)
        {
            if (conquistas[i].ID == id && conquistas[i].conquistaAtivada == true)
            {

                resultado = true;
            }
        }
        return resultado;
    }
    [ContextMenu("SalvarConquistas")]
    public void SalvarConquistas()
    {
        // Serializa nossa lista de conquistas em um array de Json
        // Não esquecer de baixar o Script JsonHelper.cs e anexar ao seu projeto, senão não irá funcionar!
        string json = JsonHelper.ToJson(conquistas.ToArray());
        //salvo a string em um arquivo  de texto no caminho especificado
        File.WriteAllText(caminhoSalvar, json);
    }

    [ContextMenu("CarregarConquistas")]
    public void CarregarConquistas()
    {
        // lê o json salvo em um arquivo de texto no caminho especificado
        string jsonSalvo = File.ReadAllText(caminhoSalvar);
        // transforma a string em um array de Conquistas
        // Não esquecer de baixar o Script JsonHelper.cs e anexar ao seu projeto, senão não irá funcionar!
        Conquista[] conquistasContainer = JsonHelper.FromJson<Conquista>(jsonSalvo);
        // Atualiza minhas conquistas atuais
        for (int i = 0; i < conquistasContainer.Length; i++)
        {
            conquistas[i].nome             = conquistasContainer[i].nome;
            conquistas[i].dscConquista     = conquistasContainer[i].dscConquista;
            conquistas[i].conquistaAtivada = conquistasContainer[i].conquistaAtivada;
            conquistas[i].ID               = conquistasContainer[i].ID;
        }
    }
}

[System.Serializable]
public class Conquista
{
    public int ID = 0;
    public string nome;
    public string dscConquista;
    public int codIcone;
    public bool conquistaAtivada;

}

