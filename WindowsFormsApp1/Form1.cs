using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, WaveOutEvent> waveOutDict = new Dictionary<string, WaveOutEvent>(); 
        private Dictionary<string, AudioFileReader> audioFileDict = new Dictionary<string, AudioFileReader>(); 
        private Dictionary<string, bool> isPlayingDict = new Dictionary<string, bool>(); 

        public Form1()
        {
            InitializeComponent();
            isPlayingDict.Add("cryFaceBtn", false);
            isPlayingDict.Add("joyFaceBtn", false);
            isPlayingDict.Add("bonusFaceBtn", false);
            isPlayingDict.Add("shockedFaceBtn", false);
            isPlayingDict.Add("noFaceBtn", false);
            isPlayingDict.Add("ConfusedFaceBtn", false);

            isPlayingDict.Add("pointsFaceBtn", false);
            isPlayingDict.Add("unknownFaceBtn", false);
            isPlayingDict.Add("MichalFaceBtn", false);
            isPlayingDict.Add("noKingFaceBtn", false);
            isPlayingDict.Add("yesKingFaceBtn", false);
            isPlayingDict.Add("SorryFaceBtn", false);
        }

        private void PlayOrStopAudio(string buttonName, string filePath)
        {
            try
            {
                if (!isPlayingDict[buttonName])
                {
                    foreach (var key in isPlayingDict.Keys)
                    {
                        if (key != buttonName && isPlayingDict[key])
                        {
                            StopAudio(key); 
                        }
                    }

                    PlayAudio(buttonName, filePath);
                    isPlayingDict[buttonName] = true;
                }
                else 
                {
                    StopAudio(buttonName);
                    isPlayingDict[buttonName] = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PlayAudio(string buttonName, string filePath)
        {
            try
            {
                if (waveOutDict.ContainsKey(buttonName)) 
                {
                    StopAudio(buttonName);
                }

                var audioFile = new AudioFileReader(filePath);
                var waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();

                waveOut.PlaybackStopped += (s, ev) =>
                {
                    isPlayingDict[buttonName] = false; 
                };

                waveOutDict[buttonName] = waveOut;
                audioFileDict[buttonName] = audioFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing the file: " + ex.Message);
            }
        }

        private void StopAudio(string buttonName)
        {
            try
            {
                if (waveOutDict.ContainsKey(buttonName))
                {
                    waveOutDict[buttonName].Stop();
                    waveOutDict[buttonName].Dispose();
                    waveOutDict.Remove(buttonName);
                }

                if (audioFileDict.ContainsKey(buttonName))
                {
                    audioFileDict[buttonName].Dispose();
                    audioFileDict.Remove(buttonName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping the music: " + ex.Message);
            }
        }

        private void cryFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("cryFaceBtn", "cryVoice.Wav");
        }

        private void joyFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("joyFaceBtn", "joyVoice.Wav");
        }

        private void bonusFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("bonusFaceBtn", "bonusVoice.Wav");
        }

        private void shockedFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("shockedFaceBtn", "shockedVoice.Wav");
        }

        private void noFace_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("noKingFaceBtn", "noVoice.Wav");
        }

        private void ConfusedFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("yesKingFaceBtn", "yesKingVoice.Wav");
        }

        private void pointsFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("pointsFaceBtn", "PointVoice.Wav");

        }

        private void unknownFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("unknownFaceBtn", "unknownVoice.Wav");
        }

        private void MichalFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("MichalFaceBtn", "MichalVoice.Wav");
        }

        private void noKingFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("noKingFaceBtn", "noKingVoice.Wav");
        }

        private void yesKingFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("yesKingFaceBtn", "yesKingVoice.Wav");

        }

        private void SorryFaceBtn_Click(object sender, EventArgs e)
        {
            PlayOrStopAudio("SorryFaceBtn", "SorryVoice.Wav");
        }
    }
}