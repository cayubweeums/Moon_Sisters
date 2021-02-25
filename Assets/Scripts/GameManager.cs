using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject dialogBox;
    public GameObject dialogText;
    private Coroutine dialogCoroutine;
    public GameObject startButton;
    public GameObject StartBackground;
    public GameObject canvas;
    public GameObject events;




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
        }
        else
        {
            Destroy(gameObject);
            Destroy(events);
            Destroy(canvas);
        }
    }

    public static GameManager Instance
    {
        get; private set;
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("FirstScene"));
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 1f));
    }

    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = StartBackground.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        sprite.color = endValue;
    }

    public void StartDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogCoroutine = StartCoroutine(TypeText(text));
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCoroutine);

    }

    IEnumerator TypeText(string text)
    {
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.01f);

        }
    }

    public void GameOver()
    {
        startButton.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), 1f));
    }

}
