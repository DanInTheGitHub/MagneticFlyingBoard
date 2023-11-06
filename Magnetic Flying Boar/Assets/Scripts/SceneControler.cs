using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{
    public void ChangeScene(int nScene)//NUmero de la escena
    {
        SceneManager.LoadScene(nScene);
    }
}