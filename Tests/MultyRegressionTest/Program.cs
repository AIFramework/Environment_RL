using AI.DataStructs.Algebraic;
using AI.ML.NeuralNetwork.CoreNNW.Activations;
using AI.ML.Regression;
using EnvLib.ComplexObjectControl.Objects;


ElectroMotor electroMotor = new ElectroMotor();
NeuralMultyRegression neuralMultyRegressionInv = new NeuralMultyRegression(2, 3, 8, new TanhUnit());
NeuralMultyRegression neuralMultyRegression = new NeuralMultyRegression(3, 2, 32, new TanhUnit());
neuralMultyRegressionInv.EpochesToPass = 70;
neuralMultyRegression.EpochesToPass = 70;


var dat = GeneratedInp(2900);
Vector[] inps = dat.Item1.ToArray();   // { new Vector(1, 2), new Vector(2, 2), new Vector(2, 2), new Vector(1, -2) };
Vector[] outps = dat.Item2.ToArray(); //  { new Vector(1, 3, -1), new Vector(-2, 0, 2), new Vector(-2, 0, 2), new Vector(-1, -2, 1) };








neuralMultyRegressionInv.Train(outps, inps);
neuralMultyRegression.Train(inps, outps);


for (int i = 0; i < 10; i++)
{
    Random random = new Random();
    double k = random.Next(1, 16);
	double r = Math.Round(100 *random.NextDouble());
    double d = Math.Round(2 * random.NextDouble(),2);
	Vector inp = new Vector(r, k, d);
	Vector speed = electroMotor.GetState(inp).Transform(x=>Math.Round(x, 2));
    var result = neuralMultyRegressionInv.Predict(speed).Transform(x => Math.Round(x, 2));
	Vector sp = neuralMultyRegression.Predict(result).Transform(x => Math.Round(x, 2));
    Console.WriteLine($"\n\n\nInp: {speed}\nPredict control: {result}\nReal contrl: {inp} \nPredict regress {sp}\nReal regress {electroMotor.GetState(result).Transform(x => Math.Round(x, 2))}");
}




(List<Vector>, List<Vector>) GeneratedInp(int n)
{
    Random random = new Random();
	List<Vector> listInp = new List<Vector>();
	List<Vector> listOutp = new List<Vector>();

	for (int i = 0; i < n; i++)
	{
		double k = random.Next(1, 18);
		double d = Math.Round(2 * random.NextDouble(), 2);
        double r = Math.Round(100 * random.NextDouble());
        listInp.Add(new Vector(r, k, d));
		listOutp.Add(electroMotor.GetState(listInp[i]));
    }

	return (listInp, listOutp);
}