using Godot;

namespace ExtendedCanvas
{
    public abstract partial class BufferedCanvasLayer : CanvasLayer
    {
        public virtual void LoadCanvas(Node sceneToLoad)
        {
            sceneToLoad.CallDeferred("add_child", this);
        }
    }   
}