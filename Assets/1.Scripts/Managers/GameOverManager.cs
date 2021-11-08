using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image backgroundImage;
    public Transform gameoverTextTr;
    bool isGameOver = false;

    void Update()
    {
        if(playerHealth.isDead && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(GameOverDirection());
        }
    }

    IEnumerator GameOverDirection()
    {
        yield return new WaitForSeconds(1.5f);
        for (float f = 0f; f <= 1; f += 0.03f) {
            // 구조체는 값 형태라 프로퍼티로 직접수정 불가능
            Color c = backgroundImage.color;
            c.a = f;
            backgroundImage.color = c;
            gameoverTextTr.localScale = Vector3.one * f;
            yield return new WaitForSeconds(.03f);
        }
        backgroundImage.color = Color.black;
        gameoverTextTr.localScale = Vector3.one;

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
