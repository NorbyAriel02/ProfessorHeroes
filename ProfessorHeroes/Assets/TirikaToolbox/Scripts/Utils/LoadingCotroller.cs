using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LoadingCotroller : MonoBehaviour
{
    public GameObject LoadingPanel;    
    public float fadeSpeed = 0.001f;    
    Image panel;
    void Start()
    {
        panel = LoadingPanel.GetComponent<Image>();
        GameManager.Instance.OnLoadScene += FadeIn;
    }
    private void OnEnable()
    {
        ChangeOfScene.OnOut += FadeOut;
        ChangeOfScene.OnStart += FadeIn;
        
        panel = LoadingPanel.GetComponent<Image>();
        FadeIn();
    }
    private void OnDisable()
    {
        ChangeOfScene.OnOut -= FadeOut;
        ChangeOfScene.OnStart -= FadeIn;
        GameManager.Instance.OnLoadScene -= FadeIn;
    }
    private void Update()
    {
        //if(Input.GetKeyUp(KeyCode.I))
        //    FadeIn();

        //if(Input.GetKeyUp(KeyCode.O))
        //    FadeOut();
    }
    public void FadeIn()
    {        
        StartCoroutine(FadeIn(fadeSpeed));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOut(fadeSpeed));
    }
    public IEnumerator FadeOut(float fadeSpeed)
    {
        LoadingPanel.SetActive(true);        
        float targetAlpha = 1;
        float currentAlpha = 0;
        panel.color = new Color(0, 0, 0, currentAlpha);
        while ((currentAlpha + fadeSpeed) <= targetAlpha)//current alpha se aproxima a 1 pero nunca es 1
        {            
            currentAlpha = Mathf.Lerp(panel.color.a, targetAlpha, fadeSpeed);
            panel.color = new Color(0, 0, 0, currentAlpha);
            yield return null;
        }
        panel.color = new Color(0, 0, 0, targetAlpha);

    }
    public IEnumerator FadeIn(float fadeSpeed)
    {        
        float targetAlpha = 0;
        float currentAlpha = 1;
        panel.color = new Color(0, 0, 0, currentAlpha);        
        while ((currentAlpha - fadeSpeed) >= targetAlpha)//current alpha se aproxima a 0 pero nunca es 0
        {         
            currentAlpha = Mathf.Lerp(panel.color.a, targetAlpha, fadeSpeed);
            panel.color = new Color(0, 0, 0, currentAlpha);
            yield return null;
        }
        panel.color = new Color(0, 0, 0, targetAlpha);        
        LoadingPanel.SetActive(false);
    }   
}
