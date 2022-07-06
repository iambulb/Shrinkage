
using enumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Chem.Device.Light
{
    public class LightManager : ILight
    {
        private ILight _light = null;
        public void CreateObject(eSerialLightType type)
        {
            switch (type)
            {
                case eSerialLightType.CCS_RS485:
                    _light = new CCS_Light_RS485();
                    break;
                case eSerialLightType.L_Light_RS232:
                    _light = new L_Light_RS232();
                    break;
                case eSerialLightType.None:
                default:
                    break;
            }
        }

        public override void Init(string com, int baudRate)
        {
            if (_light == null)
                return;
            _light.Init(com, baudRate);
        }

        public override bool IsLightOn()
        {
            if (_light == null)
                return false;
            return _light.IsLightOn();
        }

        public override void LightOn(bool bOn)
        {
            if (_light == null)
                return;
            _light.LightOn(bOn);
        }

        public override bool SendData(string sendData)
        {
            if (_light == null)
                return false;
            return _light.SendData(sendData);
        }

        public override bool SendData(byte[] sendData)
        {
            if (_light == null)
                return false;
            return _light.SendData(sendData);
        }

        public override void SetLightValue(int value)
        {
            if (_light == null)
                return;
            _light.SetLightValue(value);
        }

        public override void Terminate()
        {
            if (_light == null)
                return;
            _light.Terminate();
        }
    }
}
