using UnityEngine;

public class SphereDrop : MonoBehaviour
{
    public GameObject target; // �ΏۃI�u�W�F�N�g

    bool check = false; // �`�F�b�N�t���O

    void Update()
    {
        /*Vector3 cube = target.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < 3f)
        {
            SphereGravity();
        }*/

        // �`�F�b�N�����ꂽ�ꍇ
        if (check)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic; // Rigidbody �̓��I�ȃ^�C�v�ɕύX
        }
    }

    // ���̂ɏd�͂�K�p���郁�\�b�h
    void SphereGravity()
    {
        GetComponent<Rigidbody>().useGravity = true; // �d�͂�L���ɂ���
    }

    // �`�F�b�N�C�x���g�̏���
    public void CheckEventHandler(Collider2D collider)
    {
        check = true; // �`�F�b�N�t���O�𗧂Ă�
    }
}
