import { ImGui, ImGuiImplWeb, ImVec2, ImVec4, ImTextureRef } from "jsimgui";

const canvas = document.querySelector("#render-canvas");
const context = canvas.getContext("webgl2");

if (!context) throw new Error("Your browser does not support WebGL2.");

const devicePixelRatio = globalThis.devicePixelRatio;
canvas.width = canvas.clientWidth * devicePixelRatio;
canvas.height = canvas.clientHeight * devicePixelRatio;

await ImGuiImplWeb.InitWebGL(canvas);


window.ImGuiInterop = {
    processFrame: function(commands) {
        const updatedValues = {};

        for (const cmd of commands) {
            switch (cmd.command) {
                case "begin":
                    ImGui.Begin(cmd.args.name);
                    break;

                case "end":
                    ImGui.End();
                    break;

                case "text":
                    ImGui.Text(cmd.args.text);
                    break;

                case "sliderfloat":
                    const refVal = [cmd.args.value];
                    const changed = ImGui.SliderFloat(cmd.args.label, refVal, cmd.args.min, cmd.args.max);
                    updatedValues[cmd.args.label] = refVal[0];
                    break;
            }
        }

        return updatedValues;
    }
};


const color = [0.0, 0.5, 0.5];
const showDemo = [true];
const docking = [false];

const imgJsLogo = new Image();
imgJsLogo.src = "javascript.png";
const jsLogo = await ImGuiImplWeb.LoadImageWebGL(canvas, imgJsLogo);

let code = [
    ``,
];
let evalCode = "";



async function frame() {
    ImGuiImplWeb.BeginRenderWebGL();

    ImGui.SetNextWindowPos(new ImVec2(10, 10), ImGui.Cond.Once);
    ImGui.SetNextWindowSize(new ImVec2(330, 400), ImGui.Cond.Once);
    ImGui.Begin("WebGL");

    ImGui.SeparatorText("Welcome");
    ImGui.Text("Welcome to jsimgui!");
    ImGui.TextDisabled(`Using ImGui v${ImGui.GetVersion()}-docking`);

    ImGui.Spacing();

    if (ImGui.TreeNode("Other Examples")) {
        ImGui.Bullet();
        if (ImGui.TextLink("Three.js")) {
            globalThis.open("https://mori2003.github.io/jsimgui/docs/examples/threegl/", "_self");
        }
        ImGui.SameLine();
        ImGui.Text("(WebGL2 Renderer)");
        ImGui.Spacing();
        ImGui.TreePop();
    }

    if (ImGui.TreeNode("Source Code")) {
        if (ImGui.TextLink("Github")) {
            globalThis.open("https://github.com/mori2003/jsimgui/", "_self");
        }
        ImGui.TreePop();
    }

    ImGui.Spacing();
    ImGui.Checkbox("Show ImGui Demo", showDemo);
    ImGui.SameLine();
    if (ImGui.Checkbox("Enable Docking", docking)) {
        if (docking[0]) {
            const io = ImGui.GetIO();
            io.ConfigFlags |= ImGui.ConfigFlags.DockingEnable;
        } else {
            const io = ImGui.GetIO();
            io.ConfigFlags &= ~ImGui.ConfigFlags.DockingEnable;
        }
    }

    ImGui.SeparatorText("Features");

    if (ImGui.CollapsingHeader("Widgets")) {
        if (ImGui.Button("Button")) {
            alert("Button pressed");
        }

        ImGui.Text("Text");
        ImGui.TextColored(new ImVec4(1, 1, 0, 1), "Colored Text");
        ImGui.TextDisabled("Disabled Text");

        ImGui.Image(new ImTextureRef(jsLogo), new ImVec2(50, 50));

        const values = [0, 1, 2, 3, 4];
        ImGui.ColorEdit3("clearColor", color);
        ImGui.PlotLines("My Plot", values, values.length, 0, "", 0, 4, new ImVec2(0, 80));
        ImGui.PlotHistogram("My Histogram", values, values.length, 0, "", 0, 4, new ImVec2(0, 80));
    }

    /*
    // 🔄 Llamada al método C# que devuelve el código
    const newCode = await DotNet.invokeMethodAsync("Alis.App.Engine.Web", "GetImGuiCode");
    code[0] = newCode;

    // Ejecutar el código recibido
    evalCode = code[0];
    try {
        eval(evalCode);
    } catch (e) {
        console.error("Error al ejecutar código desde Blazor:", e);
    }*/

    await DotNet.invokeMethodAsync("Alis.App.Engine.Web", "RenderUI");

    ImGui.End();

    if (showDemo[0]) ImGui.ShowDemoWindow(showDemo);

    context.clearColor(color[0], color[1], color[2], 1.0);
    context.clear(context.COLOR_BUFFER_BIT);

    ImGuiImplWeb.EndRenderWebGL();

    requestAnimationFrame(frame);
}

requestAnimationFrame(frame);
