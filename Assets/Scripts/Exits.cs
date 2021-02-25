using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exits : MonoBehaviour
{

    public string toTravel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Finish"))
            {
                StartCoroutine(EndGame());
            }
            else
            {
                StartCoroutine(LoadYourAsyncScene(toTravel));
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(toTravel, LoadSceneMode.Single);
        GameManager.Instance.GameOver();
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
    }
}
