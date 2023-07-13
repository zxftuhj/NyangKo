using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMove : MonoBehaviour
{
    public static BackMove instance;
    private static string str;
    public Animator animator;
    private void Awake()
    {
        instance = this;
    }
    public string strP
    {
        get => str;
        set => str=value;
    }
    public void FadeNextScene()
    {
        animator.SetTrigger("ToClick");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(str);
    }
}
