using System.Collections;
using System.Collections.ObjectModel;

var neuron1 = new Neuron();
var neuron2 = new Neuron();

var layer1 = new NeuronLayer(5);
var layer2 = new NeuronLayer(3);

neuron1.ConnectTo(neuron2);
neuron1.ConnectTo(layer1);
layer1.ConnectTo(layer2);

public static class NeuronExtensions
{
	public static void ConnectTo(this IEnumerable<Neuron> sourceNeurons, IEnumerable<Neuron> targetNeurons)
	{
		if (ReferenceEquals(sourceNeurons, targetNeurons))
		{
			return;
		}

		foreach (var sourceNeuron in sourceNeurons)
		{
			foreach (var targetNeuron in targetNeurons)
			{
				sourceNeuron.Out.Add(targetNeuron);
				targetNeuron.In.Add(sourceNeuron);
			}
		}
	}
}

public class Neuron : IEnumerable<Neuron>
{
	public List<Neuron> In = new List<Neuron>();
	public List<Neuron> Out = new List<Neuron>();

	public IEnumerator<Neuron> GetEnumerator()
	{
		yield return this;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

public class NeuronLayer : Collection<Neuron>
{
	public NeuronLayer(int count)
	{
		while (count --> 0)
		{
			Add(new Neuron());
		}
	}
}
