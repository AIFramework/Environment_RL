using AI.DataStructs.Algebraic;
using AI.ML.NeuralNetwork.CoreNNW.Activations;
using AI.ML.Regression;

NeuralMultyRegression neuralMultyRegression = new NeuralMultyRegression(2, 3, 12, new TanhUnit());
neuralMultyRegression.EpochesToPass = 50;

Vector[] inps = { new Vector(1, 2), new Vector(2, 2), new Vector(2, 2), new Vector(1, -2) };
Vector[] outps = { new Vector(1, 3, -1), new Vector(-2, 0, 2), new Vector(-2, 0, 2), new Vector(-1, -2, 1) };
int k = 0;


neuralMultyRegression.Train(inps, outps);

var result = neuralMultyRegression.Predict(inps[k]);

Console.WriteLine($"\n\n\nInp: {inps[k]}\n\nPredict: {result}");
