using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableCamera : MonoBehaviour
{
    public GameObject quadCamera;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void EnableQuad()
    {
        quadCamera.SetActive(true);
    }

    public void DisableQuad()
    {
        quadCamera.SetActive(false);
    }

    public void AnimatorP1(bool enable)
    {
        animator.SetBool("NextP1", enable);
    }

    public void AnimatorP2(bool enable)
    {
        animator.SetBool("NextP2", enable);
    }

    public void AnimatorP3(bool enable)
    {
        animator.SetBool("NextP3", enable);
    }

    public void SetScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
