using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersUI : MonoBehaviour
{
    public Text textoFeedbackValor;
    public Slider slider;


  

    public void AtualizarTextoSliderVolumeBG(float valor)
    {
        textoFeedbackValor.text = (valor * 100f).ToString("F0") + "%";
        AudioController.Instance.AtualizarVolumeBG(valor);
    }

    public void AtualizarTextoSliderVolumeSFX(float valor)
    {
        textoFeedbackValor.text = (valor * 100f).ToString("F0") + "%";
        AudioController.Instance.AtualizarVolumeSFX(valor);
        
    }

}
