using UnityEngine;

public class CustomClock : MonoBehaviour
{
    // 中心となる時間（24時間形式）
    public int centerHour = 6;
    public int centerMinute = 0;

    // 時計の針の速度
    public float hourHandSpeed = 30.0f; // 30 degrees per hour
    public float minuteHandSpeed = 6.0f; // 6 degrees per minute

    // Update is called once per frame
    void Update()
    {
        // 中心時間からの差分を計算
        int hourDifference = System.DateTime.Now.Hour - centerHour;
        int minuteDifference = System.DateTime.Now.Minute - centerMinute;

        // 時計の針の角度を計算
        float hourHandAngle = -(hourDifference * hourHandSpeed);
        float minuteHandAngle = -(minuteDifference * minuteHandSpeed);

        // 時計の針の角度を更新
        transform.Find("HourHand").localEulerAngles = new Vector3(0, 0, hourHandAngle);
        transform.Find("MinuteHand").localEulerAngles = new Vector3(0, 0, minuteHandAngle);
    }
}

