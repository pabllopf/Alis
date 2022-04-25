namespace Alis.Game.Android;

/// <summary>

/// The main activity class

/// </summary>

/// <seealso cref="Activity"/>

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    /// <summary>
    /// Ons the create using the specified saved instance state
    /// </summary>
    /// <param name="savedInstanceState">The saved instance state</param>
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }
}