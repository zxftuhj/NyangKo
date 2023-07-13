using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackScene : MonoBehaviour
{
    [SerializeField] private Image rightdoor;
    [SerializeField] private Image leftdoor;
    [SerializeField] private Button BattleButton;
    [SerializeField] private Button PowerUpButton;
    [SerializeField] private Button textButton;
    [SerializeField] private Text CatCamp;
    [SerializeField] private Text CatCamp2;
    [SerializeField] private Image Mascot;
    [SerializeField] private Image Copydoor1;
    [SerializeField] private Image Copydoor2;
    [SerializeField] private Button Copybtn1;
    [SerializeField] private Button Copybtn2;
    [SerializeField] private Text CopyCatCamp;
    [SerializeField] private GameObject gameob;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Text text;
    [SerializeField] private Canvas backCanvas;
    public float jumpPower;
    private bool istrue = false;
    private bool istrue2 = true;
    private string str = "고양이 기지에 온 걸 환영해! 파워 업 화면에서 새로운 캐릭터를 획득하는거다냥";
    Vector3 vec = new Vector3();
    void Awake()
    {
        text.text = str;
        vec = CatCamp.transform.position;
    }
    public void ClickToBack()
    {
        istrue = true;
        backCanvas.overrideSorting = true;
        backCanvas.sortingOrder = 6;
        if (istrue)
        {
            StartCoroutine("BackCoroutine");
        }
    }
    void Update()
    {
        if (istrue)
        {
            ClickToBack();
        }
    }
    IEnumerator BackCoroutine()
    {
        leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, Copydoor1.transform.position, 13f);
        rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, Copydoor2.transform.position, 13f);
        CatCamp.transform.position = Vector3.MoveTowards(CatCamp.transform.position, CopyCatCamp.transform.position, 11f);
        yield return new WaitForSeconds(0.1f);
        CatCamp2.transform.position = Vector3.MoveTowards(CatCamp2.transform.position, vec, 12f);
        yield return new WaitForSeconds(0.8f);
        BattleButton.transform.position = Vector3.MoveTowards(BattleButton.transform.position, Copybtn1.transform.position, 9f);
        yield return new WaitForSeconds(0.1f);
        JumpMo();
        PowerUpButton.transform.position = Vector3.MoveTowards(PowerUpButton.transform.position, Copybtn2.transform.position, 9f);
        yield return new WaitForSeconds(0.7f);
        gameob.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.6f);
        textButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Main");
        istrue = false;
    }

    private void JumpMo()
    {
        if (istrue2)
        {
            gameob.GetComponent<BoxCollider2D>().enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            istrue2 = false;
        }
    }
}
