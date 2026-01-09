using Godot;

namespace nostart_framework_godot.SuperResources;

public enum GEngine
{
    enginegraropog
};

public static class GetResource
{
    public static GEngine GraphicsEngine{get; set;} = GEngine.enginegraropog;
    public static Texture GetTexture(string name)
    {
        Texture sprite = GD.Load<Texture>(GraphicsEngine.ToString()+name);
        return sprite;
    }
}