using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioClip))]
public class PlayAlarm : MonoBehaviour {
    [SerializeField]
    private AudioClip alarmSound;
    [SerializeField]
    private int hour, minutes;
    private AudioSource sound { get { return GetComponent<AudioSource>(); } }
    [SerializeField]
    private Text timeText;

	void Start () {
        timeText = GetComponent<UnityEngine.UI.Text>();
        sound.clip = alarmSound;
        sound.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
        System.DateTime time = System.DateTime.Now;
        timeText.text = time.ToString("hh:mm");
        if (time.Hour == hour && time.Minute == minutes && !sound.isPlaying)
        {
            Debug.Log("playing");
            sound.PlayOneShot(alarmSound);
        }
	}
}
