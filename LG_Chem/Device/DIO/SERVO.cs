using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG_Chem.Device.DIO
{
    public class SERVO
    {
        public int m_lAxisCounts = 0;                          // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo = 0;                          // 제어할 축 번호 선언 및 초기화
        public uint m_uModuleID = 0;                         // 제어할 축의 모듈 I/O 선언 및 초기화 
        public int m_lBoardNo = 0, m_lModulePos = 0;
        public static double dCmdPos = 0.0, dCmdVel = 0.0, dActPos = 0.0;
        private static SERVO m_formMotion;

        private Thread[] m_hTestThread = new Thread[64];
        private bool[] m_bTestActive = new bool[64];

        public void initLibrary()
        {
            // ※ [CAUTION] 아래와 다른 Mot파일(모션 설정파일)을 사용할 경우 경로를 변경하십시요.
            String szFilePath = Directory.GetCurrentDirectory() + "\\" + "Config" + "\\" + "lg.mot";
            //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
            //if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            //{
            //    MessageBox.Show("Intialize Fail..!!");
            //}
            //++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
            if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("Mot File Not Found.");

            
        }
        public void AddAxisInfo()
        {
            String strAxis = "";

            //++ 유효한 전체 모션축수를 반환합니다.
            CAXM.AxmInfoGetAxisCount(ref m_lAxisCounts);
            m_lAxisNo = 0;
            //++ 지정한 축의 정보를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            for (int i = 0; i < m_lAxisCounts; i++)
            {
                switch (m_uModuleID)
                {
                    //++ 지정한 축의 정보를 반환합니다.
                    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
                    case (uint)AXT_MODULE.AXT_SMC_4V04: strAxis = String.Format("{0:00}-[PCIB-QI4A]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_2V04: strAxis = String.Format("{0:00}-[PCIB-QI2A]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04: strAxis = String.Format("{0:00}-(RTEX-PM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q: strAxis = String.Format("{0:00}-(RTEX-PM2Q)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE: strAxis = String.Format("{0:00}-(RTEX-PM2QE)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A4: strAxis = String.Format("{0:00}-[RTEX-A4N]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A5: strAxis = String.Format("{0:00}-[RTEX-A5N]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV: strAxis = String.Format("{0:00}-[MLII-SGDV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM: strAxis = String.Format("{0:00}-(MLII-PM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL: strAxis = String.Format("{0:00}-[MLII-CSDL]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR: strAxis = String.Format("{0:00}-[MLII-CSDH]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV: strAxis = String.Format("{0:00}-[SIIIH-MRJ4]", i); break;
                    default: strAxis = String.Format("{0:00}-[Unknown]", i); break;
                }

            }

        }
        public void UpdateState()
        {
            uint uAbsRel = 0, uProfile = 0, uOnOff = 0;

            m_lAxisNo = 0;

            //++ 지정한 축의 서보온 상태를 반환합니다.
            CAXM.AxmSignalIsServoOn(m_lAxisNo, ref uOnOff);

            //++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
            CAXM.AxmMotGetAbsRelMode(m_lAxisNo, ref uAbsRel);

            //++ 지정한 축의 구동 프로파일 설정값을 확인합니다.
            CAXM.AxmMotGetProfileMode(m_lAxisNo, ref uProfile);


        }
        public void Move(double Pos)
        {
            uint duRetCode = 0;

            double dPosition1 = Pos;
            double dVelocity = double.Parse(Machine._Cfg.mSetup.servospeed.ToString());
            double dAccel = double.Parse(Machine._Cfg.mSetup.servospeed.ToString());
            double dDecel = double.Parse(Machine._Cfg.mSetup.servospeed.ToString());

            //++ 지정 축의 구동 좌표계를 설정합니다. 
            // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
            //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            duRetCode = CAXM.AxmMotSetAbsRelMode(m_lAxisNo, 1);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMotSetAbsRelMode return error[Code:{0:d}]", duRetCode));

            //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            duRetCode = CAXM.AxmMoveStartPos(0, dPosition1, dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveStartPos return error[Code:{0:d}]", duRetCode));
        }
        public void AbsMove(double Pos)
        {
            uint duRetCode = 0;


            double dPosition1 = Pos;
            double dVelocity = double.Parse(Machine._Cfg.mSetup.servospeed.ToString());
            double dAccel = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));
            double dDecel = Math.Abs(double.Parse(Machine._Cfg.mSetup.servospeed.ToString()));

            //++ 지정 축의 구동 좌표계를 설정합니다. 
            // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
            //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            duRetCode = CAXM.AxmMotSetAbsRelMode(m_lAxisNo, 0);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMotSetAbsRelMode return error[Code:{0:d}]", duRetCode));

            //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            duRetCode = CAXM.AxmMoveStartPos(0, dPosition1, dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveStartPos return error[Code:{0:d}]", duRetCode));
        }
        public void ServoOn(int on)
        {
            uint duOnOff;

            //++ 지정 축의 Servo On/Off 신호를 출력합니다.
            duOnOff = (uint)Convert.ToInt32(on);
            CAXM.AxmSignalServoOn(m_lAxisNo, duOnOff);
        }
        public void Timer()
        {
            

            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            CAXM.AxmStatusGetCmdPos(m_lAxisNo, ref dCmdPos);
            //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
            CAXM.AxmStatusGetActPos(m_lAxisNo, ref dActPos);
            //++ 지정한 축의 구동 속도를 반환합니다.
            CAXM.AxmStatusReadVel(m_lAxisNo, ref dCmdVel);

            FormMain.Instance().edtCmdPos.Text = String.Format("{0:0.000}", dCmdPos);
            FormMain.Instance().edtActPos.Text = String.Format("{0:0.000}", dActPos);
            //edtCmdVel.Text = String.Format("{0:0.000}", dCmdVel);
        }

        public bool Limit()
        {
            uint duState1 = 0, duState2 = 0, duRetCode;
            bool result = true;
            duRetCode = CAXM.AxmSignalReadSoftLimit(m_lAxisNo, ref duState1, ref duState2);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                result = Convert.ToBoolean(duState2);
                //chkSwlimitN.Checked = Convert.ToBoolean(duState2);
            }
            return result;
        }


    }
}
