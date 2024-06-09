using UnityEngine;
using UnityEngine.UI;

// �w�i���y�̊Ǘ����s���X�N���v�g
public class BgmManager : MonoBehaviour
{
    public Slider slider;       // ���ʂ𒲐����邽�߂̃X���C�_�[
    AudioSource audioSource;    // AudioSource�R���|�[�l���g�ւ̎Q��

    // �J�n���ɌĂ΂�郁�\�b�h
    void Start()
    {
        // AudioSource�R���|�[�l���g���擾����
        audioSource = GetComponent<AudioSource>();

        // �X���C�_�[�̒l���ύX���ꂽ�Ƃ��ɌĂ΂�郊�X�i�[��o�^����
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }
}
