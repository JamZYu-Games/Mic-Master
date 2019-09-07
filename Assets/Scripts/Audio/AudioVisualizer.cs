using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVisualizer : MonoBehaviour {
		
	public Transform[] audioSpectrumCapsules;
    public int size;
	[Range(1, 100)] public float heightMultiplier;
	[Range(64, 8192)] public int numberOfSamples; //step by 2
	public FFTWindow fftWindow;
	public float lerpTime = 1;
	public Slider sensitivitySlider;

	private float[] audioSpectrumObjects;

	/*
	 * The intensity of the frequencies found between 0 and 44100 will be
	 * grouped into 1024 elements. So each element will contain a range of about 43.06 Hz.
	 * The average human voice spans from about 60 hz to 9k Hz
	 * we need a way to assign a range to each object that gets animated. that would be the best way to control and modify animatoins.
	*/

	void Start(){

		heightMultiplier = PlayerPrefsManager.GetSensitivity ();

		sensitivitySlider.onValueChanged.AddListener(delegate {
			SensitivityValueChangedHandler(sensitivitySlider);
		});
        audioSpectrumObjects = new float[size];
	}

	void Update() {

		// initialize our float array
		float[] spectrum = new float[numberOfSamples];

		// populate array with fequency spectrum data
		GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);


		// loop over audioSpectrumObjects and modify according to fequency spectrum data
		// this loop matches the Array element to an object on a One-to-One basis.
		for(int i = 0; i < audioSpectrumCapsules.Length; i++)
		{

			// apply height multiplier to intensity
			float intensity = spectrum[i+9] * heightMultiplier;

			// calculate object's scale
			float lerpY = Mathf.Lerp(audioSpectrumCapsules[i].localScale.y,intensity,lerpTime);
			Vector3 newScale = new Vector3( audioSpectrumCapsules[i].localScale.x, lerpY + 0.05f, audioSpectrumCapsules[i].localScale.z);

			audioSpectrumCapsules[i].localScale = newScale;

		}
	}

	public void SensitivityValueChangedHandler(Slider sensitivitySlider){
		heightMultiplier = sensitivitySlider.value;
	}

}
