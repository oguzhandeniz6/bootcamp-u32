using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ObjectHealthBar : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] GameObject healthPointPrefab;
    Dictionary<GameObject, bool> healthPoints = new Dictionary<GameObject, bool>();
    List<Image> images = new List<Image>();

    public void Initialize(int health)
    {

        int targetHealth = health;
        mainCamera = Camera.main;

        //Can deðerlerine göre can kutusu spawnla
        for (int i = 0; i < targetHealth; i++)
        {
            GameObject hp = Instantiate(healthPointPrefab, transform);
            healthPoints.Add(hp, true);
            images.Add(hp.GetComponent<Image>());
        }

        //Yüzünü cameraya çevir
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);

        //Baþlangýçta görünmez yap
        ToggleVisibility(false);
      

    }

    public void LoseHealthPoint()
    {
        KeyValuePair<GameObject, bool> lastHealthPoint = default;

        foreach(KeyValuePair<GameObject, bool> kvp in healthPoints)
        {

            if (kvp.Value == false)
            {
                break;
            }
            lastHealthPoint = kvp;

        }

        //Kutu yok olma animasyonu
        Sequence loseHealth = DOTween.Sequence();
        loseHealth
            .Append(lastHealthPoint.Key.GetComponent<Image>().DOColor(Color.red, 0.3f))
            .Append(lastHealthPoint.Key.GetComponent<Image>().DOFade(0, 0.3f))
            .AppendCallback(() => healthPoints[lastHealthPoint.Key] = false);




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleVisibility(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleVisibility(false);
        }
    }



    void ToggleVisibility(bool toggle)
    {
        foreach (Image img in images)
        {
            img.enabled = toggle;
        }
    }



}
