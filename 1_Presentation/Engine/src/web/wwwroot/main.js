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

                case "textcolored":
                    const colorArr = cmd.args.color.length === 3 ? [...cmd.args.color, 1.0] : cmd.args.color;
                    ImGui.TextColored(new ImVec4(...colorArr), cmd.args.text);
                    break;

                case "textdisabled":
                    ImGui.TextDisabled(cmd.args.text);
                    break;

                case "separator":
                    ImGui.Separator();
                    break;

                case "button":
                    if (ImGui.Button(cmd.args.label)) {
                        updatedValues[cmd.args.label] = true;
                    }
                    break;

                case "checkbox":
                    const boolRef = [cmd.args.value];
                    if (ImGui.Checkbox(cmd.args.label, boolRef)) {
                        updatedValues[cmd.args.label] = boolRef[0];
                    }
                    break;

                case "sliderfloat":
                    const refVal = [cmd.args.value];
                    const changed = ImGui.SliderFloat(cmd.args.label, refVal, cmd.args.min, cmd.args.max);
                    updatedValues[cmd.args.label] = refVal[0];
                    break;

                case "coloredit3":
                    const colorRef = [...cmd.args.value];
                    if (ImGui.ColorEdit3(cmd.args.label, colorRef)) {
                        updatedValues[cmd.args.label] = colorRef;
                    }
                    break;

                case "plotlines":
                    ImGui.PlotLines(cmd.args.label, cmd.args.values, cmd.args.values.length, cmd.args.offset, cmd.args.overlayText, cmd.args.scaleMin, cmd.args.scaleMax, new ImVec2(...cmd.args.size));
                    break;

                case "plothistogram":
                    ImGui.PlotHistogram(cmd.args.label, cmd.args.values, cmd.args.values.length, cmd.args.offset, cmd.args.overlayText, cmd.args.scaleMin, cmd.args.scaleMax, new ImVec2(...cmd.args.size));
                    break;

                case "image":
                    ImGui.Image(new ImTextureRef(cmd.args.texture), new ImVec2(...cmd.args.size));
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

    await DotNet.invokeMethodAsync("Alis.App.Engine.Web", "RenderUi");

    ImGui.End();

    if (showDemo[0]) ImGui.ShowDemoWindow(showDemo);

    context.clearColor(color[0], color[1], color[2], 1.0);
    context.clear(context.COLOR_BUFFER_BIT);

    ImGuiImplWeb.EndRenderWebGL();

    requestAnimationFrame(frame);
}

requestAnimationFrame(frame);
