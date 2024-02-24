using Stateless;

using static System.Console;

var light = new StateMachine<bool, LightTrigger>(false);

light.Configure(false).Permit(LightTrigger.On, true).OnEntry(transition =>
{
	WriteLine(transition.IsReentry ? "Light already off" : "Switching light off");
}).PermitReentry(LightTrigger.Off);

light.Configure(true).Permit(LightTrigger.Off, false).OnEntry(() =>
{
	WriteLine("Turning light on");
}).Ignore(LightTrigger.On);

light.Fire(LightTrigger.Off);
light.Fire(LightTrigger.On);
light.Fire(LightTrigger.On);
light.Fire(LightTrigger.Off);
light.Fire(LightTrigger.Off);

public enum LightTrigger
{
	On, Off
}