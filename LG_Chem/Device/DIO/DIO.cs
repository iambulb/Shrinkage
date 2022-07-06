using enumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum AXT_INTERRUPT_CLASS : uint
{
    KIND_MESSAGE,
    KIND_CALLBACK,
    KIND_EVENT
}

namespace LG_Chem.Device.DIO
{

    public class DIO
    {
        public CtrlTapDispaly ResultDataControl = new CtrlTapDispaly();
        public Device.DIO.SERVO Servo = new SERVO();
        public static bool bDown = false;
        public static bool[] bInput = new bool[10];
        public bool OpenDevice()
        {
            //++
            // Initialize library 
            if (CAXL.AxlOpen(7) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                uint uStatus = 0;

                if (CAXD.AxdInfoIsDIOModule(ref uStatus) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    if ((AXT_EXISTENCE)uStatus == AXT_EXISTENCE.STATUS_EXIST)
                    {
                        int nModuleCount = 0;

                        if (CAXD.AxdInfoGetModuleCount(ref nModuleCount) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                        {
                            short i = 0;
                            int nBoardNo = 0;
                            int nModulePos = 0;
                            uint uModuleID = 0;
                            string strData = "";

                            for (i = 0; i < nModuleCount; i++)
                            {
                                if (CAXD.AxdInfoGetModule(i, ref nBoardNo, ref nModulePos, ref uModuleID) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                                {
                                    switch ((AXT_MODULE)uModuleID)
                                    {
                                        case AXT_MODULE.AXT_SIO_DI32: strData = String.Format("[{0:D2}:{1:D2}] SIO-DI32", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_DO32P: strData = String.Format("[{0:D2}:{1:D2}] SIO-DO32P", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_DB32P: strData = String.Format("[{0:D2}:{1:D2}] SIO-DB32P", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_DO32T: strData = String.Format("[{0:D2}:{1:D2}] SIO-DO32T", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_DB32T: strData = String.Format("[{0:D2}:{1:D2}] SIO-DB32T", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDI32: strData = String.Format("[{0:D2}:{1:D2}] SIO_RDI32", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDO32: strData = String.Format("[{0:D2}:{1:D2}] SIO_RDO32", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDB128MLII: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB128MLII", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RSIMPLEIOMLII: strData = String.Format("[{0:D2}:{1:D2}] SIO-RSIMPLEIOMLII", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDO16AMLII: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDO16AMLII", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDO16BMLII: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDO16BMLII", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDB96MLII: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB96MLII", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDO32RTEX: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDO32RTEX", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDI32RTEX: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDI32RTEX", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDB32RTEX: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB32RTEX", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_DI32_P: strData = String.Format("[{0:D2}:{1:D2}] SIO-DI32_P", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_DO32T_P: strData = String.Format("[{0:D2}:{1:D2}] SIO-DO32T_P", nBoardNo, i); break;
                                        case AXT_MODULE.AXT_SIO_RDB32T: strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB32T", nBoardNo, i); break;
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Module not exist.");

                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Open Error!");
            }

            return true;
        }

        public static bool OutputIndex(int nIndex, uint uValue)
        {

            int nModuleCount = 0;
            uint upStatus = 0;
            CAXD.AxdInfoIsDIOModule(ref upStatus);

            CAXD.AxdInfoGetModuleCount(ref nModuleCount);

            if (nModuleCount > 0)
            {
                int nBoardNo = 0;
                int nModulePos = 0;
                uint uModuleID = 0;

                CAXD.AxdInfoGetModule(0, ref nBoardNo, ref nModulePos, ref uModuleID);

                switch ((AXT_MODULE)uModuleID)
                {
                    case AXT_MODULE.AXT_SIO_DO32P:
                    case AXT_MODULE.AXT_SIO_DO32T:
                    case AXT_MODULE.AXT_SIO_RDO32:
                        CAXD.AxdoWriteOutportBit(0, nIndex + 16, uValue);
                        break;
                    case AXT_MODULE.AXT_SIO_DB32P:
                    case AXT_MODULE.AXT_SIO_DB32T:
                    case AXT_MODULE.AXT_SIO_RDB128MLII:
                        CAXD.AxdoWriteOutportBit(0, nIndex, uValue);
                        break;

                    default:
                        return false;
                }
            }

            return true;
        }

        private bool InputIndex(int nIndex, uint uValue)
        {
            int nModuleCount = 0;

            CAXD.AxdInfoGetModuleCount(ref nModuleCount);

            if (nModuleCount > 0)
            {
                int nBoardNo = 0;
                int nModulePos = 0;
                uint uModuleID = 0;

                CAXD.AxdInfoGetModule(0, ref nBoardNo, ref nModulePos, ref uModuleID);

                switch ((AXT_MODULE)uModuleID)
                {
                    case AXT_MODULE.AXT_SIO_DO32P:
                    case AXT_MODULE.AXT_SIO_DO32T:
                    case AXT_MODULE.AXT_SIO_RDO32:
                        CAXD.AxdoWriteOutportBit(0, nIndex, uValue);
                        break;

                    default:
                        if(nIndex == 0)
                        {
                            bInput[nIndex] = false;
                            OutputIndex(3, (uint)0);
                        }
                        else if(nIndex == 1)
                        {
                            OutputIndex(4, (uint)1);
                            ResultDataControl.chbxLiveMode.Checked = false;
                            Sequence.Instance().StartSequence();
                            Thread.Sleep(1000);
                            OutputIndex(4, (uint)0);
                        }
                        //Reset Click
                        else if (nIndex == 2)
                        {
                            if (!DIO.bInput[0])
                            {
                                Sequence._isEMO = false;
                            }
                            DIO.OutputIndex(3, (uint)0);
                            DIO.OutputIndex(0, (uint)1);
                            DIO.OutputIndex(1, (uint)0);
                            DIO.OutputIndex(2, (uint)0);
                            OutputIndex(5, (uint)1);
                            CAXM.AxmSignalSetServoAlarm(0, 0);
                            CAXM.AxmSignalServoAlarmReset(0, 1);
                            Servo.initLibrary();
                            Servo.AddAxisInfo();
                            Servo.UpdateState();
                            CAXM.AxmSignalSetServoAlarm(0, 0);
                            Thread.Sleep(2000);
                            OutputIndex(5, (uint)0);
                            CAXM.AxmSignalServoAlarmReset(0, 0);
                            Sequence.SeqStep = eSeqStep.SEQ_STOP;
                            Thread.Sleep(500);
                            CAXM.AxmStatusSetPosMatch(0, 0);
                            Servo.AbsMove(400000);
                        }
                        else if(nIndex == 3)
                        {
                            bDown = false;
                        }
                        else if (nIndex == 4)
                        {
                            bDown = true;
                        }

                        return false;
                }
            }

            return true;
        }
       public void TimerSensor()
       {
            short nIndex = 0;
            uint uDataHigh = 0;
            uint uDataLow = 0;
            uint uFlagHigh = 0;
            uint uFlagLow = 0;
            int nBoardNo = 0;
            int nModulePos = 0;
            uint uModuleID = 0;

            CAXD.AxdInfoGetModule(0, ref nBoardNo, ref nModulePos, ref uModuleID);

            switch ((AXT_MODULE)uModuleID)
            {
                case AXT_MODULE.AXT_SIO_DI32:
                case AXT_MODULE.AXT_SIO_RDI32:
                case AXT_MODULE.AXT_SIO_RSIMPLEIOMLII:
                case AXT_MODULE.AXT_SIO_RDO16AMLII:
                case AXT_MODULE.AXT_SIO_RDO16BMLII:
                case AXT_MODULE.AXT_SIO_DI32_P:
                case AXT_MODULE.AXT_SIO_RDI32RTEX:
                    //++
                    // Read inputting signal in WORD
                    CAXD.AxdiReadInportWord(0, 0, ref uDataHigh);
                    CAXD.AxdiReadInportWord(0, 1, ref uDataLow);

                    for (nIndex = 0; nIndex < 16; nIndex++)
                    {
                        // Verify the last bit value of data read
                        uFlagHigh = uDataHigh & 0x0001;
                        uFlagLow = uDataLow & 0x0001;

                        // Shift rightward by bit by bit
                        uDataHigh = uDataHigh >> 1;
                        uDataLow = uDataLow >> 1;

                        // Updat bit value in control
                        if (uFlagHigh == 1)
                        {
                            InputIndex(nIndex, (uint)1);
                            //bInput[nIndex] = true;
                        }
                        //checkHigh[nIndex].Checked = true;
                        else
                        {
                            InputIndex(nIndex, (uint)0);
                            //bInput[nIndex] = false;
                        }
                        //checkHigh[nIndex].Checked = false;

                        if (uFlagLow == 1)
                            OutputIndex(nIndex, (uint)1);
                        
                        //checkLow[nIndex].Checked = true;
                        //else
                        //    OutputIndex(nIndex, (uint)1);
                        //checkLow[nIndex].Checked = false;
                    }
                    break;

                case AXT_MODULE.AXT_SIO_DB32P:
                case AXT_MODULE.AXT_SIO_DB32T:
                case AXT_MODULE.AXT_SIO_RDB32T:
                case AXT_MODULE.AXT_SIO_RDB32RTEX:
                case AXT_MODULE.AXT_SIO_RDB96MLII:
                case AXT_MODULE.AXT_SIO_RDB128MLII:
                    //++
                    // Read inputting signal in WORD
                    CAXD.AxdiReadInportWord(0, 0, ref uDataHigh);

                    for (nIndex = 0; nIndex < 16; nIndex++)
                    {
                        // Verify the last bit value of data read
                        uFlagHigh = uDataHigh & 0x0001;

                        // Shift rightward by bit by bit
                        uDataHigh = uDataHigh >> 1;

                        // Updat bit value in control
                        if (uFlagHigh == 1)
                        {
                            InputIndex(nIndex, (uint)1);
                        }
                        //checkHigh[nIndex].Checked = true;
                        else
                        {
                            //EMO Click
                            if(nIndex == 0)
                            {
                                if (!bInput[nIndex])
                                {
                                    bInput[nIndex] = true;
                                    OutputIndex(3, (uint)1);
                                    OutputIndex(0, (uint)1);
                                    OutputIndex(1, (uint)1);
                                    OutputIndex(2, (uint)0);
                                    OutputIndex(7, (uint)0);
                                    OutputIndex(6, (uint)1);
                                    Sequence._isStop = true;
                                    Sequence._isEMO = true;
                                    MessageBox.Show("비상 정지!");
                                }
                                
                            }
                            //InputIndex(nIndex, (uint)0);
                            
                        }
                    }
                    break;
            }
       }



    }
}
