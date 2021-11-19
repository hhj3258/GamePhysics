# Basic Kinematic_BeanBag Game

## 개요
가속도, 속도, 변위(위치) 간의 관계성에 관한 간단한 공 던지기(포물선 운동) 게임 예제

![image](https://user-images.githubusercontent.com/70702088/122098922-66a72b00-ce4c-11eb-816e-e92c74952d5b.png)

## 핵심 코드
```C#
        //0.05초마다 타이머에 의해 호출됨
        private void ActionPerformed(object sender, EventArgs e)
        {
            //시간 업데이트, 빈백의 포지션 계산
            double timeIncrement = 0.05d;
            time += timeIncrement;

            //x축(수평) 위치 변화 방정식 = 초기 x위치+초기 x속도 * t
            x = x0 + vx0 * time;

            double g = -9.81d;  //중력 가속도

            //z축(수직) 위치 변화 방정식 = 초기 z위치 + 초기 z속도 * t + 1/2gt^2
            z = z0 + vz0 * time + 0.5 * g * time * time;

            UpdateDisplay();

            //바닥 zPos=1.4
            if (z <= 1.4)
            {
                gameTimer.Stop();
            }
        }
```


## 구현 환경
- Visual Studio 2019
- Windows Forms 앱(.NET Framework)
- .NET Framework 4.7.2
