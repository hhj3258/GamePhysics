## BeanBag Game

```C#
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
```
            
