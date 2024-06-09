using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    // �t�F�[�h�C�����s���R���[�`��
    IEnumerator Color_FadeIn()
    {
        // ��ʂ��t�F�[�h�C��������R���[�`��

        // �F��ς���Q�[���I�u�W�F�N�g����Image�R���|�[�l���g���擾
        Image fade = GetComponent<Image>();

        // �t�F�[�h���̐F��ݒ�i���j���ύX��
        fade.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        // �t�F�[�h�C���ɂ����鎞�ԁi�b�j���ύX��
        const float fade_time = 2.0f;

        // ���[�v�񐔁i0�̓G���[�j���ύX��
        const int loop_count = 10;

        // �E�F�C�g���ԎZ�o
        float wait_time = fade_time / loop_count;

        // �F�̊Ԋu���Z�o
        float alpha_interval = 1.0f / loop_count;

        // �F�����X�ɕς��郋�[�v
        for (float alpha = 1.0f; alpha >= 0.0f; alpha -= alpha_interval)
        {
            // �҂�����
            yield return new WaitForSeconds(wait_time);

            // Alpha�l��������������
            fade.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    // �t�F�[�h�A�E�g���s���R���[�`��
    IEnumerator Color_FadeOut()
    {
        // ��ʂ��t�F�[�h�A�E�g������R���[�`��

        // �F��ς���Q�[���I�u�W�F�N�g����Image�R���|�[�l���g���擾
        Image fade = GetComponent<Image>();

        // �t�F�[�h��̐F��ݒ�i���j���ύX��
        fade.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        // �t�F�[�h�A�E�g�ɂ����鎞�ԁi�b�j���ύX��
        const float fade_time = 2.0f;

        // ���[�v�񐔁i0�̓G���[�j���ύX��
        const int loop_count = 10;

        // �E�F�C�g���ԎZ�o
        float wait_time = fade_time / loop_count;

        // �F�̊Ԋu���Z�o
        float alpha_interval = 1.0f / loop_count;

        // �F�����X�ɕς��郋�[�v
        for (float alpha = 0.0f; alpha <= 1.0f; alpha += alpha_interval)
        {
            // �҂�����
            yield return new WaitForSeconds(wait_time);

            // Alpha�l���������グ��
            fade.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }

        // �V�[�������[�h����
        SceneManager.LoadScene("Title");
    }

    // �t�F�[�h�A�E�g�������J�n���郁�\�b�h
    public void Fadeout()
    {
        StartCoroutine(Color_FadeOut());
    }
}
