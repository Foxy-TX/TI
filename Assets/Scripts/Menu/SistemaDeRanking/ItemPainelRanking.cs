using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPainelRanking : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _dataText;


    public void SetupItem(string nome, string score, string data){
        _nameText.text = nome;
        _scoreText.text = score;
        _dataText.text = data;
    }
}
