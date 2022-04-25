using ObjCRuntime;

namespace Alis.Game.MacOs;

/// <summary>

/// The view controller class

/// </summary>

/// <seealso cref="NSViewController"/>

public partial class ViewController : NSViewController
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ViewController"/> class
    /// </summary>
    /// <param name="handle">The handle</param>
    protected ViewController(NativeHandle handle) : base(handle)
    {
    }

    /// <summary>
    /// Views the did load
    /// </summary>
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Do any additional setup after loading the view.
    }

    /// <summary>
    /// Gets or sets the value of the represented object
    /// </summary>
    public override NSObject RepresentedObject
    {
        get => base.RepresentedObject;
        set
        {
            base.RepresentedObject = value;

            // Update the view, if already loaded.
        }
    }
}