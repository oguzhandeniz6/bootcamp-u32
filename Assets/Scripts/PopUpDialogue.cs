using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PopUpDialogue : MonoBehaviour
{
    [SerializeField] GameObject popUpBox;
    [SerializeField] TMP_Text popUpText;
    Camera mainCamera;
    [SerializeField] float dialogueDisplayDuration = 4;
    private Image popUpImage;
    private Color initialColorAlpha;
    private Color initialTextColorAlpha;


    private void Start()
    {


        //Kamerayi al
        mainCamera = Camera.main;
        popUpImage = popUpBox.GetComponent<Image>();

        initialTextColorAlpha = popUpText.color;
        initialColorAlpha = popUpImage.color;

        //Baslangicta kapat
        popUpBox.SetActive(false);

    }

    public void PrintDialogue(Component sender, object data)
    {
        if (data is string)
        {
                 string textToPrint = (string) data;

            if (popUpBox.active)
            {
                return;
            }

            Sequence seq = DOTween.Sequence();
            seq
                .AppendCallback(() =>
                {
                    popUpBox.SetActive(true);
                    popUpText.text = textToPrint;
                    popUpImage.color = initialColorAlpha;
                    popUpText.color = initialTextColorAlpha;
                }).AppendInterval
                (
                dialogueDisplayDuration/2
                )
                .Append
                (
                popUpText.DOFade(0, dialogueDisplayDuration/2)

                ).Join
                (
                popUpImage.DOFade(0, dialogueDisplayDuration/2)
                ).OnComplete(() => { popUpBox.SetActive(false); });

        }
        
       

    }

    public void PrintDialogueDirectly(string text)
    {
        Sequence seq = DOTween.Sequence();
        seq
            .AppendCallback(() =>
            {
                popUpBox.SetActive(true);
                popUpText.text = text;
                popUpImage.color = initialColorAlpha;
                popUpText.color = initialTextColorAlpha;
            }).AppendInterval
            (
            dialogueDisplayDuration / 2
            )
            .Append
            (
            popUpText.DOFade(0, dialogueDisplayDuration / 2)

            ).Join
            (
            popUpImage.DOFade(0, dialogueDisplayDuration / 2)
            ).OnComplete(() => { popUpBox.SetActive(false); });


    }
    private void Update()
    {
        //Kameraya yuzunu cevir
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }


}
