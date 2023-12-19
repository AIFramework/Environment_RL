using System;
using System.Collections.Generic;
using System.Linq;

namespace EnvLib.Aggregator
{
    public class KNN1D
    {
        public static double[] KnnX(IEnumerable<IGameObj> gameObjs, IGameObj centralObj, int top_k = 5)
        {
            List<DistanceWithDirect1D> distanceWithDirect1Ds = new List<DistanceWithDirect1D>(gameObjs.Count());
            List<double> distVector = new List<double>(top_k);

            foreach (var item in gameObjs)
                distanceWithDirect1Ds.Add(new DistanceWithDirect1D(item.CoordX - centralObj.CoordX));

            distanceWithDirect1Ds.Sort((x, y) => x.Dist.CompareTo(y.Dist));

            for (int i = 0; i < top_k; i++)
                distVector.Add(distanceWithDirect1Ds[i].DistanceWithDirect);

            distVector.Sort();

            return distVector.ToArray();
        }


    }

    public class DistanceWithDirect1D
    {
        public double Dist => Math.Abs(DistanceWithDirect);
        public double DistanceWithDirect { get; set; }

        public DistanceWithDirect1D(double dif)
        {
            DistanceWithDirect = dif;
        }
    }
}
