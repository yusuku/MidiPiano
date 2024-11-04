using UnityEngine;
using MidiJack;

public class MidiPiano : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] pianoNotes; // 各MIDIノートに対応するAudioClipを配置

    void Update()
    {
        // すべてのMIDIノートをチェック
        for (int i = 0; i < 128; i++)
        {
            // ノートが押された瞬間に音を再生
            if (MidiMaster.GetKeyDown(i))
            {
                PlayNote(i);
            }
        }
    }

    void PlayNote(int note)
    {
        if (note >= 0 && note < pianoNotes.Length && pianoNotes[note] != null)
        {
            // PlayOneShotを使用して音を再生
            audioSource.PlayOneShot(pianoNotes[note]);
        }
    }
}
