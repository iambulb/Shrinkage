using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumType
{
    public enum eProgramMode
    {
        Inspection,
        Stop,
        Test,
    }

    public enum eInspectionType
    {
        None,
        AI_Front,
        AI_Edge,
        EdgeBroken,
        EdgeContour,
        ForkBroken,
        ForkContour,
    }

    public enum eInspectionTriggerType
    {
        None,
        PLC,
        SENSOR,
    }

    public enum eLightType
    {
        None,
        Serial,
        IO,
    }

    public enum eSerialLightType
    {
        None,
        L_Light_RS232,
        CCS_RS485,
    }

    public enum eLineRateType
    {
        None,
        ConstantVel, // PLC에서 속도를 안받고 일정한 속도로 LineRate 지정할 경우
        VariableVel,   // PLC 에서 실시간 속도를 받는 경우 (PLC Data 중 Target Vel, Slow vel 필요)
    }

    public enum eCVDirection
    {
        Stop = 0,
        CW = 1,
        CCW = 2,
    }

    public enum eSeqStep
    {
        SEQ_STOP,
        SEQ_START,
        SEQ_INIT,
        SEQ_INSPECTION_WAIT,
        SEQ_INSPECTION,
        SEQ_SEND_RESULT,
        SEQ_UI_RESULT_UPDATE,
        SEQ_SAVE_IMAGE,
        SEQ_DELETE_DATA,
        SEQ_END,
        SEQ_ERROR,
    }

    public enum eInspSeqStep
    {
        SEQ_STOP,
        SEQ_INIT,
        SEQ_INSPECTION,
        SEQ_INSPECTION_WAIT,
        SEQ_COMPLETE,
        SEQ_ERR,
    }

    public enum eSubSeqLight
    {
        SUBSEQ_LIGHT_NONE = 0,
        SUBSEQ_LIGHT_ONOFF = 10,
        SUBSEQ_LIGHT_ONOFF_CHECK = 20,
    }

    public enum eAIInspectionType
    {
        None,
        Front,
        Edge,
    }

    public enum eDefectType
    {
        None,
        Broken,
        Chipping,
        Crack,
        Warning,
    }

    public enum eImageType
    {
        Jpeg,
        Bmp,
    }

    public enum eOriginDirection
    {
        LeftTop,
        RightTop,
        LeftBottom,
        RightBottom,
        Center,
    }

    public enum eDiskType
    {
        C,
        D,
    }
}