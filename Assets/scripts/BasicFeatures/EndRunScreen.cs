using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunScreen : MonoBehaviour
{
    public GameObject liveStats;
    public GameObject endScreenMoke;
    public GameObject endScreen;
    public GameObject fadeOut;

    private WaitForSeconds shortDelay = new WaitForSeconds(2);
    private WaitForSeconds longDelay = new WaitForSeconds(3);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return longDelay;

        // Deactivate live stats
        liveStats.SetActive(false);

        // Activate the mock end screen
        endScreenMoke.SetActive(true);

        yield return shortDelay;

        // Activate the real end screen
        endScreen.SetActive(true);

        yield return longDelay;

        // Activate the fade out effect
        fadeOut.SetActive(true);

        yield return shortDelay;

        // Load the main menu scene
        SceneManager.LoadScene(0);
    }
}
