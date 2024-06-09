using UnityEngine;
using UnityEngine.UI;

public class BackgroundMover : MonoBehaviour
{
    private const float k_maxLength = 1f; // �e�N�X�`���̍ő咷��
    private const string k_propName = "_MainTex"; // �e�N�X�`���̃v���p�e�B��

    [SerializeField]
    private Vector2 m_offsetSpeed; // �w�i�̈ړ����x�̐ݒ�

    private Material m_material; // �w�i�Ɏg�p�����}�e���A��

    private void Start()
    {
        // Image�R���|�[�l���g���A�^�b�`����Ă���ꍇ�A���̃}�e���A�����g�p����
        if (GetComponent<Image>() is Image image)
        {
            m_material = image.material;
        }
    }

    private void Update()
    {
        // �}�e���A�����ݒ肳��Ă���ꍇ�̂ݏ������s��
        if (m_material)
        {
            // x��y�̃I�t�Z�b�g�l�����ԂƑ��x�Ɋ�Â��Čv�Z���A0 �` 1�͈̔͂Ń��[�v������
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
            var offset = new Vector2(x, y);

            // �}�e���A���ɃI�t�Z�b�g��ݒ肷��
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // �Q�[���I�u�W�F�N�g���j�������ۂɁA�}�e���A���̃I�t�Z�b�g�����Z�b�g����
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}
