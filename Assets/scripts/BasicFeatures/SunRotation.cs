using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float sunRotateSpeed = 0.5f;
    public Transform sunTransform;

    private const string sunRoseKey = "SunRose";
    private const string sunRotXKey = "SunRotX";
    private const float saveInterval = 1.0f;

    private float timeSinceLastSave = 0f;

    void Start()
    {
        LoadSunRotation();
    }

    void Update()
    {
        // Rotate the sun
        sunTransform.Rotate(sunRotateSpeed * Time.deltaTime, 0, 0, Space.World);

        // Save the rotation every saveInterval seconds
        timeSinceLastSave += Time.deltaTime;
        if (timeSinceLastSave >= saveInterval)
        {
            SaveSunRotation();
            timeSinceLastSave = 0f;
        }
    }

    private void LoadSunRotation()
    {
        if (PlayerPrefs.HasKey(sunRoseKey))
        {
            float savedRotX = PlayerPrefs.GetFloat(sunRotXKey, 0);
            sunTransform.rotation = Quaternion.Euler(savedRotX,10f, 0f);
        }
        else
        {
            PlayerPrefs.SetInt(sunRoseKey, 1);
            PlayerPrefs.Save();
        }
    }

    private void SaveSunRotation()
    {
        PlayerPrefs.SetFloat(sunRotXKey, sunTransform.rotation.eulerAngles.x);
        PlayerPrefs.Save();
    }
}
