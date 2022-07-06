using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Chem.Device.Light
{
    public abstract class ILight
    {
        public abstract void Init(string com, int baudRate);

        public abstract void LightOn(bool bOn);

        public abstract void SetLightValue(int value);
        public abstract bool IsLightOn();

        public abstract void Terminate();

        public abstract bool SendData(string sendData);

        public abstract bool SendData(byte[] sendData);

    }
}
