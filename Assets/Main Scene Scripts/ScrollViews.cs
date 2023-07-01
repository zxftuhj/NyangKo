using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ScrollViews : MonoBehaviour
{
    public static ScrollViews instance = null;
    [SerializeField] private ScrollRect scr;
    [SerializeField] private RectTransform content;
    private static HorizontalLayoutGroup hlg;
    public float newright;
    private int num = 0;
    private float nf = 0f;
    public float copyValue;
    private static int countryClearCount = 4;
    public float copyNum;

    public int countryClearCountP
    {   
        get
        {
            return countryClearCount;
        }
        set
        {
            countryClearCount += value;
        }
    }

    public HorizontalLayoutGroup horizon
    {
        get { return hlg; }
    }

    private void Awake()
    {
        newright = content.offsetMax.x;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        hlg = content.GetComponent<HorizontalLayoutGroup>();

    }
    void Start()
    {
        num = 0;
        GameObject[] gameOb = GameObject.FindGameObjectsWithTag("Country");
        int count = (gameOb.Length - 1) - ((gameOb.Length - 1) - countryClearCount);
        for (int i = gameOb.Length - 1; i > count; i--)
        {
            gameOb[i].gameObject.SetActive(false);
            newright = content.offsetMax.x - 274;
            content.offsetMax = new Vector2(newright, content.offsetMax.y);
            if (hlg != null)
            {
                hlg.spacing -= 7.6f;
            }
            if (num == 1)
            {
                hlg.spacing -= 11f;
            }
            else if (num > 1)
            {
                hlg.spacing -= nf;
            }
            nf += 8f;
            num++;
        }
        copyNum = newright;
        if (countryClearCount > 0)
        {
            copyValue = newright;
            newright = content.transform.position.x;
            Rect contentRect = content.rect;
            contentRect.xMin = copyValue;
            content.sizeDelta = new Vector2(contentRect.width, content.sizeDelta.y);
            content.anchoredPosition = new Vector2(-copyValue, content.anchoredPosition.y);
            content.offsetMax = new Vector2(newright, content.offsetMax.y);
        }
    }
}
