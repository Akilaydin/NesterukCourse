var lightSwitch = new LightSwitch();

lightSwitch.On();
lightSwitch.Off();
lightSwitch.Off();

lightSwitch.On();
lightSwitch.On();

public class LightSwitch
{
	public LightSwitchState CurrentState = new OffLightSwitchState();
	
	public void On()
	{
		CurrentState.On(this);
	}
	
	public void Off()
	{
		CurrentState.Off(this);	
	}
}

public abstract class LightSwitchState
{
	public virtual void On(LightSwitch sw) { }
	public virtual void Off(LightSwitch sw) { }
}

public class OnLightSwitchState : LightSwitchState
{
	public override void On(LightSwitch sw)
	{
		Console.WriteLine("Light already turned on");
	}

	public override void Off(LightSwitch sw)
	{
		Console.WriteLine("Turning light off");
		sw.CurrentState = new OffLightSwitchState();
	}
}

public class OffLightSwitchState : LightSwitchState
{
	public override void On(LightSwitch sw)
	{
		Console.WriteLine("Turning light on");
		sw.CurrentState = new OnLightSwitchState();
	}
	
	public override void Off(LightSwitch sw)
	{
		Console.WriteLine("Light already turned off");
	}
}