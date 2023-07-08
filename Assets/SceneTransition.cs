using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Image image;

    public void TransiteScene(string sceneName)
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() => { image.gameObject.SetActive(true); })
            .Append(image.DOFade(0, 2).From())
            .AppendCallback(() => { GameManager.instance.TransiteScene(sceneName); });


        
    }




}
