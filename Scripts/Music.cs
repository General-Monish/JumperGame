using System.Collections;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    private float indexNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start playing music when the script starts
        PlayNextClip();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here if needed
    }

    IEnumerator MusicClips()
    {
        float time = 1f; // Adjust the delay between clips as needed

        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Play the next clip
        PlayNextClip();

        // Start the coroutine again for continuous playback
        StartCoroutine(MusicClips());
    }

   public void PlayNextClip()
    {
        // Check if there are audio clips
        if (audioClips.Length > 0)
        {
            // Set the AudioClip for the AudioSource
            audioSource.clip = audioClips[Mathf.FloorToInt(indexNumber) % audioClips.Length];

            // Play the audio clip
            audioSource.Play();

            // Increment the index for the next iteration
            indexNumber++;
        }
        else
        {
            Debug.LogError("No audio clips assigned.");
        }
    }
}
