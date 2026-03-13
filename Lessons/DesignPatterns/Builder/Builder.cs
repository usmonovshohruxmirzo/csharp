public class Computer
{
    public string? CPU { get; set; }
    public string? GPU { get; set; }
    public int RAM { get; set; }
    public int Storage { get; set; }

    public void ShowSpecs()
    {
        Console.WriteLine($"CPU: {CPU}, GPU: {GPU}, RAM: {RAM}GB, Storage: {Storage}GB");
    }
}

public interface IComputerBuilder
{
    void SetCPU(string cpu);
    void SetGPU(string gpu);
    void SetRAM(int ram);
    void SetStorage(int storage);
    Computer GetComputer();
}

public class GamingPCBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public void SetCPU(string cpu) => _computer.CPU = cpu;
    public void SetGPU(string gpu) => _computer.GPU = gpu;
    public void SetRAM(int ram) => _computer.RAM = ram;
    public void SetStorage(int storage) => _computer.Storage = storage;

    public Computer GetComputer() => _computer;
}

public class Director
{
    private readonly IComputerBuilder _builder;

    public Director(IComputerBuilder builder)
    {
        _builder = builder;
    }

    public void BuildGamingPC()
    {
        _builder.SetCPU("Intel i9");
        _builder.SetGPU("NVIDIA RTX 4090");
        _builder.SetRAM(32);
        _builder.SetStorage(2000);
    }

    public void BuildOfficePC()
    {
        _builder.SetCPU("Intel i5");
        _builder.SetGPU(null!);
        _builder.SetRAM(16);
        _builder.SetStorage(500);
    }
}
