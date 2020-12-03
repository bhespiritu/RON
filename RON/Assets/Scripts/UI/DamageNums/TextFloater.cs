using UnityEngine;
using TMPro;

public class TextFloater : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Vector3 initialHeight;
    private Vector3 targetHeight;
    public float floatOffset = 1;
    public float floatDuration = 1;
    public Color color;
    public string text = "";
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "InfoPopups";
        textMesh = GetComponent<TextMeshPro>();
        initialHeight = (Vector2) transform.position;
        targetHeight = (Vector2) transform.position + Vector2.up * floatOffset;
        startTime = GameTimer.time;
        textMesh.SetText(text);
        Destroy(gameObject, floatDuration);
    }

    // Update is called once per frame
    void Update()
    {
        float interp = easeOut((GameTimer.time - startTime) / floatDuration);
        transform.position = Vector3.Lerp(initialHeight, targetHeight, interp);
        color.a = Mathf.Lerp(1, 0, interp);
        textMesh.color = color;
    }

    public static float easeOut(float x)
    {
        float invX = 1 - x;
        return 1 - invX * invX;
    }


}
