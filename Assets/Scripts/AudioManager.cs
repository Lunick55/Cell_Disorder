using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    float timer;
    bool isBossWave = false;
    public AudioClip mainWave;
    public AudioClip bossWave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if ((timer > 60.0 && timer < 70.0) || (timer > 120.0 && timer < 130.0) || (timer > 180.0 && timer < 190.0))
        {
            this.gameObject.GetComponent<AudioSource>().clip = bossWave;
            audioChange();
        }
        else
        {
            this.gameObject.GetComponent<AudioSource>().clip = mainWave;
            audioChangeBack();
        }
    }

    void audioChange()
    {
        if (!isBossWave)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            isBossWave = true;
        }
    }

    void audioChangeBack()
    {
        if (isBossWave)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            isBossWave = false;
        }
    }
}
