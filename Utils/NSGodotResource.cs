using Godot;

namespace NSGodotResource
{
    public enum GEngine
    {
        enginegraropog
    };

    public static class Resource
    {
        public static GEngine GraphicsEngine{get; set;} = GEngine.enginegraropog;
        public static Texture GetTexture(string name)
        {
            Texture sprite = GD.Load<Texture>(GraphicsEngine.ToString()+name);
            return sprite;
        }
    }   
}