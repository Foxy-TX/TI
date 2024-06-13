using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelRanking : MonoBehaviour
{
    public List<ItemPainelRanking> itensPainel;

    private void Start()
    {
        ResetarPainel();
        AtualizarPainel();
    }
    private void OnEnable()
    {
        AtualizarPainel();
    }
    private void ResetarPainel()
    {
        for (int i = 0; i < itensPainel.Count; i++)
        {
            itensPainel[i].gameObject.SetActive(false);
        }
    }

    public void AtualizarPainel()
    {
        List<EntradaRanking> ranking = RankingManager.instance.ranking;
        if (ranking.Count > 0)
        {
            for (int i = 0; i < ranking.Count; i++)
            {
                itensPainel[i].SetupItem(ranking[i].nome, ranking[i].score.ToString(), ranking[i].data);
                itensPainel[i].gameObject.SetActive(true);
            }
        }
    }
}
