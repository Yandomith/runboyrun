using System.Collections;
using UnityEngine;
using PlayerMove;

public class LevelStarter : MonoBehaviour
{
    public GameObject count3;
    public GameObject count2;
    public GameObject count1;
    public GameObject countGo;
    public GameObject fadeinIntro;
    public GameObject player;
    public GameObject playerObject;

    [SerializeField] private PlayerController playerController;

    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        fadeinIntro.SetActive(true);
        playerObject.GetComponent<Animator>().Play("StandUP");

        yield return new WaitForSeconds(1.5f);

        ActivateCountdown(count3, 1f);
        yield return new WaitForSeconds(1f);

        ActivateCountdown(count2, 1f);
        yield return new WaitForSeconds(1f);

        ActivateCountdown(count1, 1f);
        yield return new WaitForSeconds(1f);

        ActivateCountdown(countGo, 1f);

        EnablePlayerControls();

    }

    void ActivateCountdown(GameObject countdownObject, float delay)
    {
        countdownObject.SetActive(true);
        StartCoroutine(DisableAfterDelay(countdownObject, delay));
    }

    IEnumerator DisableAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    void EnablePlayerControls()
    {
        playerController = player.GetComponent<PlayerController>();


        if (playerController != null)
            playerController.enabled = true;

    }
}
