using UnityEngine;
using MidiJack;

public class MidiPiano : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] pianoNotes; // �eMIDI�m�[�g�ɑΉ�����AudioClip��z�u

    void Update()
    {
        // ���ׂĂ�MIDI�m�[�g���`�F�b�N
        for (int i = 0; i < 128; i++)
        {
            // �m�[�g�������ꂽ�u�Ԃɉ����Đ�
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
            // PlayOneShot���g�p���ĉ����Đ�
            audioSource.PlayOneShot(pianoNotes[note]);
        }
    }
}
