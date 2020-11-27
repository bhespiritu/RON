using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    public Canvas PopupCanvas;
    public Image PopupParent;
    public Image PopupIcon;
    public Text PopupTitle;
    public Text PopupDesc;

    public float openTime = 0.2f;
    public float closeTime = 0.2f;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(PopupCanvas);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Destroy(PopupCanvas);
        }
    }

    private void Start()
    {
        initialWidth = PopupParent.rectTransform.rect.width;
    }

    private int framesSince;
    private float triggerTime;

    public bool isOpen { get; }

    private float initialWidth;

    public void triggerOpen()
    {
        StartCoroutine(animateOpen());
    }

    public void triggerClose()
    {
        StartCoroutine(animateClose());
    }

    IEnumerator animateOpen()
    {
        float t = 0.01f;
        PopupDesc.gameObject.SetActive(true);
        PopupTitle.gameObject.SetActive(true);
        PopupIcon.gameObject.SetActive(true);
        while (t < openTime)
        {
            PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, EaseIn(t / openTime) * initialWidth);
            PopupDesc.color = Color.Lerp(Color.white, Color.black, EaseOut(t / openTime));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialWidth);
        
    }

    IEnumerator animateClose()
    {
        float t = 0.01f;

        while (t < closeTime)
        {
            PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, EaseIn(1- (t / closeTime)) * initialWidth);
            PopupDesc.color = Color.Lerp(Color.black, Color.white, EaseOut(t / closeTime));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        PopupDesc.gameObject.SetActive(false);
        PopupTitle.gameObject.SetActive(false);
        PopupIcon.gameObject.SetActive(false);
    }

    public static float bounceEase(float t)
    {
        const float c4 = (2 * Mathf.PI) / 3;
        return t == 0 ? 0 : (t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - .75f) * c4) + 1);
    }

    public static float EaseIn(float t)
    {
        return t * t * t;
    }

    public static float EaseOut(float t)
    {
        float invT = 1 - t;
        return 1 - invT * invT * invT;
    }

}
