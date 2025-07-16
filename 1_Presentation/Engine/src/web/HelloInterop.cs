using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    public static class HelloInterop
    {
        private static float _checkboxValue = 0.5f;

        [JSInvokable]
        public static async Task RenderUI()
        {
            
            Dictionary<string, float> values = await ImGui.Process(imgui =>
            {
                imgui.Begin("Hola");
                imgui.Text("Texto");
                imgui.SliderFloat("Slider", _checkboxValue, 0.0f, 1.0f);
                imgui.End();
                
                imgui.Begin("Hola mundo 2");
                imgui.Text("Texto 3332");
                imgui.SliderFloat("Slider22", _checkboxValue, 0.0f, 1.0f);
                imgui.End();
            });

            if (values.TryGetValue("Slider", out float newValue))
            {
                _checkboxValue = newValue;
            }
            
            if (values.TryGetValue("Slider22", out float newValue2))
            {
                _checkboxValue = newValue2;
            }

            
        }
    
    
    
    }
}