using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class ScreenSFX : MonoBehaviour
{

    [SerializeField] Image flashIMG;
    [SerializeField] private Color initialBackgroundColor;

    private void Awake()
    {
        initialBackgroundColor =Camera.main.backgroundColor;
    }

    public void DoFlash()
    {
        flashIMG.color = Color.white;
        if (!flashIMG.gameObject.active)
        {
            flashIMG.gameObject.SetActive(true);
        }
        flashIMG.DOFade(0, 0.2f);
    }
    

    [SerializeField] float shakeDuration;
    [SerializeField] float shakeStrength;
    [SerializeField] int shakeVibrato;

    public void DoShake()
    {
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato).OnComplete(() => { Camera.main.GetComponent<CinemachineBrain>().enabled = true; });
        
    }

    public void DoBackgroundColor()
    {
        Camera.main.backgroundColor = initialBackgroundColor;
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.DOColor(Color.magenta, 2))
            .Append(Camera.main.DOColor(Color.black, 2))
            .Append(Camera.main.DOColor(Color.cyan, 2))
            .Append(Camera.main.DOColor(Color.black, 2))
            .Append(Camera.main.DOColor(Color.magenta, 2))
            .Append(Camera.main.DOColor(Color.black, 2));
    }
        
           
           
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            DoFlash();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            DoShake();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            DoBackgroundColor();
        }
    }
}
