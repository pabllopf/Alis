namespace Alis.Editor
{
    using ImGuiNET;

    public class Inspector
    {
        private bool isOpen = true;

        public Inspector() 
        {
        
        }

        public void Draw() 
        {
            if (ImGui.Begin("Inspector", ref isOpen)) 
            {
                

            }

            ImGui.End();
        }
    }
}
