using AI.Controls.ComplexObjectControl.Base;
using AI.DataStructs.Algebraic;
using AI.HightLevelFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvLib.ComplexObjectControl.Objects
{
    /// <summary>
    /// Электродвигатель с управлением на базе шим
    /// </summary>
    [Serializable]
    public class ElectroMotor : ComplexObjectBase
    {
        double _k = 10;
        Random random = new Random();
        double C = 2e-7; // Конденсатор ШИМ


        public ElectroMotor(double k = 10) { }

        /// <summary>
        /// Выдает скорость машины и качество управления
        /// </summary>
        /// <param name="action">0 индекс - значение резистора в ШИМ, 1 - передача(1-3), 2 - скважность</param>
        /// <returns></returns>
        public override Vector GetState(Vector action)
        {
            Vector outp = new Vector(2);
            outp[0] = _k / (action[2] + 1) * action[1];// + 2 * random.NextDouble();
            outp[1] = Q(action[0], action[1]);
            return outp;
        }

        private double GetF(double r) 
        {
            return 1.44 / (r*1e+3 * C);
        }

        private double Q(double r, double kP) 
        {
            return ActivationFunctions.Sigmoid(GetF(r) / (kP*100 - 2));
        }
    }
}
