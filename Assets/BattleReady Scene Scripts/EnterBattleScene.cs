using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnterBattleScene : MonoBehaviour
{
    [SerializeField] private ScrollRect scr;
    [SerializeField] private RectTransform content;
    private int num;
    private HorizontalLayoutGroup hlg;
    void Awake()
    {
        hlg = content.GetComponent<HorizontalLayoutGroup>();
        hlg.spacing = ScrollViews.instance.horizon.spacing;
        num = ScrollViews.instance.countryClearCountP;

    }
    private void Start()
    {
        GameObject[] gameOb = GameObject.FindGameObjectsWithTag("Country");
        int count = (gameOb.Length - 1) - ((gameOb.Length - 1) - num);
        for (int i = gameOb.Length - 1; i > count; i--)
        {
            gameOb[i].gameObject.SetActive(false);
            content.offsetMax = new Vector2(ScrollViews.instance.copyNum, content.offsetMax.y);
        }
        if (num > 0)
        {
            Rect contentRect = content.rect;
            contentRect.xMin = ScrollViews.instance.copyValue;
            content.sizeDelta = new Vector2(contentRect.width, content.sizeDelta.y);
            content.anchoredPosition = new Vector2(-ScrollViews.instance.copyValue, content.anchoredPosition.y);
            content.offsetMax = new Vector2(ScrollViews.instance.newright, content.offsetMax.y);
        }
    }
}
