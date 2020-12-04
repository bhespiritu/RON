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
    public RectTransform IconHolder;
    public Text PopupTitle;
    public Text PopupDesc;

    public Sprite testSprite;

    public bool showIcon = true;

    public float openTime = 0.2f;
    public float closeTime = 0.2f;

    public bool isOpen { get; }

    private float initialWidth;
    private Queue<Popup> popupQueue;
    private bool popupActive = false;
    private Coroutine currentPopup;
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
        popupQueue = new Queue<Popup>();
        PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        PopupDesc.gameObject.SetActive(false);
        PopupTitle.gameObject.SetActive(false);
        PopupIcon.gameObject.SetActive(false);
        //Sample Usage:
        //queuePopup(5,"Sample Title", "This is a test message", testSprite);
        //queuePopup(5, "Sample Title", "This is a test message", testSprite);
        //queuePopup(2, "Sample Title2", "This is a test message2");
        //queuePopup(5, "Sample Title3", "This is a test message3", testSprite);
    }

    private void Update()
    {
        if (!popupActive)
        {
            if (popupQueue.Count > 0)
            {
                Popup pop = popupQueue.Dequeue();

                PopupTitle.text = pop.title;
                PopupDesc.text = pop.description;
                if(pop.icon)
                {
                    PopupIcon.sprite = pop.icon;
                    PopupIcon.gameObject.SetActive(true);
                    IconHolder.gameObject.SetActive(true);
                } else
                {
                    IconHolder.gameObject.SetActive(false);

                }
               
                PopupDesc.gameObject.SetActive(!string.IsNullOrEmpty(pop.description));
                PopupTitle.gameObject.SetActive(!string.IsNullOrEmpty(pop.title));

                currentPopup = StartCoroutine(popUpFor(pop.duration));
            }
        }
    }

    private void triggerOpen()
    {
        StartCoroutine(animateOpen());
    }

    private void triggerClose()
    {
        StartCoroutine(animateClose());
    }

    private void showFor(float time)
    {
        StartCoroutine(popUpFor(time));
    }

    public void queuePopup(float time, string title, string message, Sprite icon = null, bool force = false)
    {
        if(force)
        {
            if(currentPopup != null)
                StopCoroutine(currentPopup);
            PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            PopupDesc.gameObject.SetActive(false);
            PopupTitle.gameObject.SetActive(false);
            PopupIcon.gameObject.SetActive(false);
            popupActive = false;
            
            clearQueue();
        }
        Popup pop = new Popup(time, title, message, icon);
        popupQueue.Enqueue(pop);
    }

    public void clearQueue()
    {
        popupQueue.Clear();
    }

    IEnumerator popUpFor(float time)
    {
        yield return new WaitForEndOfFrame();
        popupActive = true;
        float t = 0.01f;
        while (t < openTime)
        {
            PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, EaseIn(t / openTime) * initialWidth);
            PopupDesc.color = Color.Lerp(Color.white, Color.black, EaseOut(t / openTime));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialWidth);

        yield return new WaitForSeconds(time);
        t = 0.01f;

        while (t < closeTime)
        {
            PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, EaseIn(1 - (t / closeTime)) * initialWidth);
            PopupDesc.color = Color.Lerp(Color.black, Color.white, EaseOut(t / closeTime));
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PopupParent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        PopupDesc.gameObject.SetActive(false);
        PopupTitle.gameObject.SetActive(false);
        PopupIcon.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        popupActive = false;
    }


    IEnumerator animateOpen()
    {
        popupActive = true;
        float t = 0.01f;
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
        popupActive = false;
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

    private struct Popup
    {
        public string title;
        public string description;
        public Sprite icon;
        public float duration;
        public Popup(float duration = 5, string title = "", string desc = "", Sprite sprite = null)
        {
            this.title = title;
            this.description = desc;
            this.icon = sprite;
            this.duration = duration;
        }

    }

}
