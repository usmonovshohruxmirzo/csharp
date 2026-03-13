public interface IButton
{
    void Paint();
}

public interface ICheckbox
{
    void Paint();
}

public class WindowsButton : IButton
{
    public void Paint() => Console.WriteLine("Rendering Windows Button");
}

public class WindowsCheckbox : ICheckbox
{
    public void Paint() => Console.WriteLine("Rendering Windows Checkbox");
}

public class MacButton : IButton
{
    public void Paint() => Console.WriteLine("Rendering Mac Button");
}

public class MacCheckbox : ICheckbox
{
    public void Paint() => Console.WriteLine("Rendering Mac Checkbox");
}

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void RenderUI()
    {
        _button.Paint();
        _checkbox.Paint();
    }
}
