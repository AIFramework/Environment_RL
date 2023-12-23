using AI.DataStructs.Algebraic;
using AI.ML.Regression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvLib.ComplexObjectControl.Base
{
    /// <summary>
    /// Модель обратного процесса, к процессу управления
    /// </summary>
    [Serializable]
    public class ObjectInversModel
    {

        public IMultyRegression<Vector> MultyRegression;

        public ObjectInversModel() { }

        public virtual Vector GetControl(Vector state) 
        {
            return MultyRegression.Predict(state);
        }

        public virtual void Train(ObjModelDataset dataset) 
        {
            MultyRegression.Train(dataset.States.ToArray(), dataset.ControlActions.ToArray());
        }

    }

    [Serializable]
    public class ObjModelDataset 
    {
        public List<Vector> States { get; set; } = new List<Vector>();

        public List<Vector> ControlActions { get; set; } = new List<Vector>();


        public void Add(Vector state, Vector action) 
        {
            States.Add(state);
            ControlActions.Add(action);
        }
    }
}
