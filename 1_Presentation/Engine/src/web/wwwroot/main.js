import { ImGui, ImGuiImplWeb, ImVec2, ImVec4, ImTextureRef } from "jsimgui";

const canvas = document.querySelector("#render-canvas");
const context = canvas.getContext("webgl2");

if (!context) throw new Error("Your browser does not support WebGL2.");

const devicePixelRatio = globalThis.devicePixelRatio;
canvas.width = canvas.clientWidth * devicePixelRatio;
canvas.height = canvas.clientHeight * devicePixelRatio;

await ImGuiImplWeb.InitWebGL(canvas);
setImGuiStyle();

function setImGuiStyle() {
    console.info("Setting ImGui style...");
    
    ImGui.StyleColorsDark();

    const io = ImGui.GetIO();
    io.FontGlobalScale = 2.0;

    io.ConfigFlags |= ImGui.ConfigFlags.DockingEnable;

    const style = ImGui.GetStyle();
    
    // Parámetros de estilo
    style.WindowRounding = 0.0;
    style.ChildRounding = 4.0;
    style.FrameRounding = 4.0;
    style.PopupRounding = 4.0;
    style.ScrollbarRounding = 4.0;
    style.GrabRounding = 2.0;
    style.LogSliderDeadzone = 4.0;
    style.TabRounding = 4.0;
    style.WindowBorderSize = 1.0;
    style.ChildBorderSize = 1.0;
    style.PopupBorderSize = 1.0;
    style.FrameBorderSize = 1.0;
    style.TabBorderSize = 1.0;
    style.WindowPadding = new ImVec2(10, 10);
    style.FramePadding = new ImVec2(6, 6);
    style.ItemSpacing = new ImVec2(6, 6);
    style.ItemInnerSpacing = new ImVec2(6, 6);
    style.CellPadding = new ImVec2(10, 10);
    style.TouchExtraPadding = new ImVec2(0, 0);
    style.IndentSpacing = 15;
    style.ScrollbarSize = 12;
    style.GrabMinSize = 10;
    style.WindowTitleAlign = new ImVec2(0.5, 0.5);
    style.ButtonTextAlign = new ImVec2(0.5, 0.5);
    style.DisplayWindowPadding = new ImVec2(19, 19);
    style.DisplaySafeAreaPadding = new ImVec2(3, 3);
    style.AntiAliasedLines = true;
    style.AntiAliasedFill = true;
    style.CurveTessellationTol = 1.25;
    style.CircleTessellationMaxError = 0.2;
    style.Alpha = 1.0;
    style.DisabledAlpha = 0.6;

    console.info("ImGui style set to dark");
}

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

let consoleMessages = [];

// Redefinir console.log, console.warn, console.error para capturar mensajes
const originalLog = console.log;
const originalWarn = console.warn;
const originalError = console.error;
console.log = function(...args) {
    consoleMessages.push({ type: "log", message: args.map(String).join(" ") });
    originalLog.apply(console, args);
};
console.warn = function(...args) {
    consoleMessages.push({ type: "warn", message: args.map(String).join(" ") });
    originalWarn.apply(console, args);
};
console.error = function(...args) {
    consoleMessages.push({ type: "error", message: args.map(String).join(" ") });
    originalError.apply(console, args);
};

function renderConsole() {
    ImGui.Begin("Consola", null, ImGui.WindowFlags.NoCollapse | ImGui.WindowFlags.NoResize);
    ImGui.Text("Mensajes de la consola del navegador:");
    ImGui.Separator();
    ImGui.BeginChild("ConsoleScroll", new ImVec2(0, 300), true);
    for (let i = 0; i < consoleMessages.length; i++) {
        const msg = consoleMessages[i];
        if (msg.type === "error") {
            ImGui.TextColored(new ImVec4(1,0.2,0.2,1), msg.message);
        } else if (msg.type === "warn") {
            ImGui.TextColored(new ImVec4(1,1,0.2,1), msg.message);
        } else {
            ImGui.Text(msg.message);
        }
    }
    ImGui.EndChild();
    if (ImGui.Button("Limpiar")) {
        consoleMessages = [];
    }
    ImGui.End();
}


// Variables globales para controlar el estado de los menús
let menuState = {
    file: "",
    edit: "",
    assets: "",
    gameObject: "",
    component: "",
    tools: "",
    window: "",
    help: ""
};


async function frame() {
    ImGuiImplWeb.BeginRenderWebGL();
    
    // Puedes usar PushStyleColor para sobreescribir colores por frame
   ImGui.PushStyleColor(ImGui.Col.TextDisabled,         0xFF808080);
   
   ImGui.PushStyleColor(ImGui.Col.WindowBg,             0xFF212426);
   ImGui.PushStyleColor(ImGui.Col.ChildBg,              0xFF212426);
   ImGui.PushStyleColor(ImGui.Col.PopupBg,              0xFF212426);
   ImGui.PushStyleColor(ImGui.Col.Border,               0xFF404040);
   ImGui.PushStyleColor(ImGui.Col.BorderShadow,         0x00000000);
   
   ImGui.PushStyleColor(ImGui.Col.FrameBg,              0xFF333333);
   ImGui.PushStyleColor(ImGui.Col.FrameBgHovered,       0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.FrameBgActive,        0xFF666666);
   
   ImGui.PushStyleColor(ImGui.Col.TitleBg,              0xFF1A1A1A);
   ImGui.PushStyleColor(ImGui.Col.TitleBgActive,        0xFF1A1A1A);
   ImGui.PushStyleColor(ImGui.Col.TitleBgCollapsed,     0xFF1A1A1A);
   
   
   ImGui.PushStyleColor(ImGui.Col.MenuBarBg,            0xFF262626);
   ImGui.PushStyleColor(ImGui.Col.ScrollbarBg,          0xFF1A1A1A);
   ImGui.PushStyleColor(ImGui.Col.ScrollbarGrab,        0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.ScrollbarGrabHovered, 0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.ScrollbarGrabActive,  0xFF808080);
   ImGui.PushStyleColor(ImGui.Col.CheckMark,            0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.SliderGrab,           0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.SliderGrabActive,     0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.Button,               0xFF333333);
   ImGui.PushStyleColor(ImGui.Col.ButtonHovered,        0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.ButtonActive,         0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.Header,               0xFF333333);
   ImGui.PushStyleColor(ImGui.Col.HeaderHovered,        0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.HeaderActive,         0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.Separator,            0xFF404040);
   ImGui.PushStyleColor(ImGui.Col.SeparatorHovered,     0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.SeparatorActive,      0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.ResizeGrip,           0xFF333333);
   ImGui.PushStyleColor(ImGui.Col.ResizeGripHovered,    0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.ResizeGripActive,     0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.Tab,                  0xFF1A1A1A);
   ImGui.PushStyleColor(ImGui.Col.TabHovered,           0xFF4D4D4D);
   ImGui.PushStyleColor(ImGui.Col.TabActive,            0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.TabUnfocused,         0xFF1A1A1A);
   ImGui.PushStyleColor(ImGui.Col.TabUnfocusedActive,   0xFF666666);
   ImGui.PushStyleColor(ImGui.Col.PlotLines,            0xFF9C9C9C);
   ImGui.PushStyleColor(ImGui.Col.PlotLinesHovered,     0xFFB3B3B3);
   ImGui.PushStyleColor(ImGui.Col.PlotHistogram,        0xFF9C9C9C);
   ImGui.PushStyleColor(ImGui.Col.PlotHistogramHovered, 0xFFB3B3B3);
   ImGui.PushStyleColor(ImGui.Col.TextSelectedBg,       0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.DragDropTarget,       0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.NavHighlight,         0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.NavWindowingHighlight,0xFFFA9743);
   ImGui.PushStyleColor(ImGui.Col.NavWindowingDimBg,    0x99333333);
   ImGui.PushStyleColor(ImGui.Col.ModalWindowDimBg,     0x99333333);

    ImGui.PushStyleColor(ImGui.Col.Text,                 0xFFFFFFFF);

    
   
    // Calcula la altura del menú superior y del menú inferior
    const menuBarHeight = ImGui.GetFrameHeight(); // Altura de la barra de menú superior
    const bottomMenuHeight = 40; // Altura fija del menú inferior

    // Ajusta la posición y el tamaño de la ventana principal para no solaparse con los menús
    ImGui.SetNextWindowPos(new ImVec2(0, menuBarHeight));
    ImGui.SetNextWindowSize(new ImVec2(canvas.width, canvas.height - menuBarHeight - bottomMenuHeight));
    ImGui.PushStyleVar(ImGui.StyleVar.WindowRounding, 0.0);
    ImGui.PushStyleVar(ImGui.StyleVar.WindowBorderSize, 0.0);
    ImGui.Begin("MainDockspace", null,
        ImGui.WindowFlags.MenuBar |
        ImGui.WindowFlags.NoTitleBar |
        ImGui.WindowFlags.NoCollapse |
        ImGui.WindowFlags.NoResize |
        ImGui.WindowFlags.NoMove |
        ImGui.WindowFlags.NoBringToFrontOnFocus |
        ImGui.WindowFlags.NoNavFocus
    );

    // Menú principal y menú inferior dentro de la ventana principal
    renderMainMenuBar();
    await DotNet.invokeMethodAsync("Alis.App.Engine.Web", "RenderUi");
    ImGui.ShowDemoWindow(showDemo);
    renderConsole();
    renderBottomMenu();

    ImGui.End();
    ImGui.PopStyleVar(2);


    ImGui.PopStyleColor(48);
    context.clearColor(color[0], color[1], color[2], 1.0);
    context.clear(context.COLOR_BUFFER_BIT);

    ImGuiImplWeb.EndRenderWebGL();

    requestAnimationFrame(frame);
}


function renderMainMenuBar() {
    ImGui.BeginMainMenuBar();
    // File Menu
    if (ImGui.BeginMenu("File")) {
        if (ImGui.MenuItem("New Scene")) { menuState.file = "New Scene"; }
        if (ImGui.MenuItem("Open Scene...")) { menuState.file = "Open Scene..."; }
        ImGui.Separator();
        if (ImGui.MenuItem("Save")) { menuState.file = "Save"; }
        if (ImGui.MenuItem("Save As...")) { menuState.file = "Save As..."; }
        ImGui.Separator();
        if (ImGui.MenuItem("New Project")) { menuState.file = "New Project"; }
        if (ImGui.MenuItem("Open Project")) { menuState.file = "Open Project"; }
        if (ImGui.MenuItem("Save Project")) { menuState.file = "Save Project"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Build Profiles")) { menuState.file = "Build Profiles"; }
        if (ImGui.MenuItem("Build And Run")) { menuState.file = "Build And Run"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Close")) { menuState.file = "Close"; }
        ImGui.EndMenu();
    }
    // Edit Menu
    if (ImGui.BeginMenu("Edit")) {
        if (ImGui.MenuItem("Undo")) { menuState.edit = "Undo"; }
        if (ImGui.MenuItem("Redo")) { menuState.edit = "Redo"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Undo History")) { menuState.edit = "Undo History"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Select All")) { menuState.edit = "Select All"; }
        if (ImGui.MenuItem("Deselect All")) { menuState.edit = "Deselect All"; }
        if (ImGui.MenuItem("Select Children")) { menuState.edit = "Select Children"; }
        if (ImGui.MenuItem("Select Prefab Root")) { menuState.edit = "Select Prefab Root"; }
        if (ImGui.MenuItem("Invert Selection")) { menuState.edit = "Invert Selection"; }
        if (ImGui.MenuItem("Selection Groups")) { menuState.edit = "Selection Groups"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Cut")) { menuState.edit = "Cut"; }
        if (ImGui.MenuItem("Copy")) { menuState.edit = "Copy"; }
        if (ImGui.MenuItem("Paste")) { menuState.edit = "Paste"; }
        if (ImGui.MenuItem("Paste Special")) { menuState.edit = "Paste Special"; }
        if (ImGui.MenuItem("Duplicate")) { menuState.edit = "Duplicate"; }
        if (ImGui.MenuItem("Rename")) { menuState.edit = "Rename"; }
        if (ImGui.MenuItem("Delete")) { menuState.edit = "Delete"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Frame Selected in Scene")) { menuState.edit = "Frame Selected in Scene"; }
        if (ImGui.MenuItem("Frame Selected in Window under Cursor")) { menuState.edit = "Frame Selected in Window under Cursor"; }
        if (ImGui.MenuItem("Lock View to Selected")) { menuState.edit = "Lock View to Selected"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Search")) { menuState.edit = "Search"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Play")) { menuState.edit = "Play"; }
        if (ImGui.MenuItem("Pause")) { menuState.edit = "Pause"; }
        if (ImGui.MenuItem("Step")) { menuState.edit = "Step"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Project Settings...")) { menuState.edit = "Project Settings..."; }
        if (ImGui.MenuItem("Clear All PlayerPrefs")) { menuState.edit = "Clear All PlayerPrefs"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Lighting")) { menuState.edit = "Lighting"; }
        if (ImGui.MenuItem("Graphics Tier")) { menuState.edit = "Graphics Tier"; }
        if (ImGui.MenuItem("Rendering")) { menuState.edit = "Rendering"; }
        ImGui.EndMenu();
    }
    // Assets Menu
    if (ImGui.BeginMenu("Assets")) {
        if (ImGui.MenuItem("Create")) { menuState.assets = "Create"; }
        if (ImGui.MenuItem("Import New Asset...")) { menuState.assets = "Import New Asset..."; }
        if (ImGui.MenuItem("Import Package...")) { menuState.assets = "Import Package..."; }
        if (ImGui.MenuItem("Export Package...")) { menuState.assets = "Export Package..."; }
        ImGui.Separator();
        if (ImGui.MenuItem("Find References In Scene")) { menuState.assets = "Find References In Scene"; }
        if (ImGui.MenuItem("Open Asset...")) { menuState.assets = "Open Asset..."; }
        ImGui.Separator();
        if (ImGui.MenuItem("Reimport")) { menuState.assets = "Reimport"; }
        if (ImGui.MenuItem("Reimport All")) { menuState.assets = "Reimport All"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Refresh")) { menuState.assets = "Refresh"; }
        if (ImGui.MenuItem("Remove Unused Assets")) { menuState.assets = "Remove Unused Assets"; }
        ImGui.EndMenu();
    }
    // GameObject Menu
    if (ImGui.BeginMenu("GameObject")) {
        if (ImGui.MenuItem("Create Empty")) { menuState.gameObject = "Create Empty"; }
        if (ImGui.MenuItem("Create Empty Child")) { menuState.gameObject = "Create Empty Child"; }
        ImGui.Separator();
        if (ImGui.MenuItem("2D Object")) { menuState.gameObject = "2D Object"; }
        if (ImGui.MenuItem("UI")) { menuState.gameObject = "UI"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Light")) { menuState.gameObject = "Light"; }
        if (ImGui.MenuItem("Audio")) { menuState.gameObject = "Audio"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Tilemap")) { menuState.gameObject = "Tilemap"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Align With View")) { menuState.gameObject = "Align With View"; }
        if (ImGui.MenuItem("Align View to Selected")) { menuState.gameObject = "Align View to Selected"; }
        if (ImGui.MenuItem("Move to View")) { menuState.gameObject = "Move to View"; }
        if (ImGui.MenuItem("Rename")) { menuState.gameObject = "Rename"; }
        if (ImGui.MenuItem("Duplicate")) { menuState.gameObject = "Duplicate"; }
        if (ImGui.MenuItem("Delete")) { menuState.gameObject = "Delete"; }
        ImGui.EndMenu();
    }
    // Component Menu
    if (ImGui.BeginMenu("Component")) {
        if (ImGui.MenuItem("Add Component")) { menuState.component = "Add Component"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Physics 2D")) { menuState.component = "Physics 2D"; }
        if (ImGui.MenuItem("Rendering 2D")) { menuState.component = "Rendering 2D"; }
        if (ImGui.MenuItem("Audio")) { menuState.component = "Audio"; }
        if (ImGui.MenuItem("UI")) { menuState.component = "UI"; }
        if (ImGui.MenuItem("Scripts")) { menuState.component = "Scripts"; }
        ImGui.EndMenu();
    }
    // Tools Menu
    if (ImGui.BeginMenu("Tools")) {
        if (ImGui.MenuItem("Sprite Editor")) { menuState.tools = "Sprite Editor"; }
        if (ImGui.MenuItem("Tilemap Editor")) { menuState.tools = "Tilemap Editor"; }
        if (ImGui.MenuItem("Animation Editor")) { menuState.tools = "Animation Editor"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Custom Tools...")) { menuState.tools = "Custom Tools..."; }
        ImGui.EndMenu();
    }
    // Window Menu
    if (ImGui.BeginMenu("Window")) {
        if (ImGui.MenuItem("General")) { menuState.window = "General"; }
        if (ImGui.MenuItem("Scene View")) { menuState.window = "Scene View"; }
        if (ImGui.MenuItem("Game View")) { menuState.window = "Game View"; }
        if (ImGui.MenuItem("Inspector")) { menuState.window = "Inspector"; }
        if (ImGui.MenuItem("Hierarchy")) { menuState.window = "Hierarchy"; }
        if (ImGui.MenuItem("Console")) { menuState.window = "Console"; }
        ImGui.EndMenu();
    }
    // Help Menu
    if (ImGui.BeginMenu("Help")) {
        if (ImGui.MenuItem("About Alis")) { menuState.help = "About Alis"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Preferences")) { menuState.help = "Preferences"; }
        if (ImGui.MenuItem("Alis Manual")) { menuState.help = "Alis Manual"; }
        if (ImGui.MenuItem("API Reference")) { menuState.help = "API Reference"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Report Bug")) { menuState.help = "Report Bug"; }
        ImGui.Separator();
        if (ImGui.MenuItem("Quit Alis")) { menuState.help = "Quit Alis"; }
        ImGui.EndMenu();
    }
    ImGui.EndMainMenuBar();
}

function renderBottomMenu() {
    const bottomMenuHeight = 40;
    const sizeMenu = 30;
    const posY = 150; // Puedes ajustar según plataforma
    const menuSize = new ImVec2(canvas.width, bottomMenuHeight);
    ImGui.SetNextWindowPos(new ImVec2(0, canvas.height - bottomMenuHeight));
    ImGui.SetNextWindowSize(menuSize);

    if (ImGui.Begin("Bottom Menu", true, ImGui.WindowFlags.NoTitleBar | ImGui.WindowFlags.NoResize | ImGui.WindowFlags.NoMove | ImGui.WindowFlags.NoScrollbar | ImGui.WindowFlags.NoSavedSettings)) {
        ImGui.Columns(6, "MenuColumns", false);

        // Botón de notificaciones (sin funcionalidad)
        ImGui.Button("🔔##notifications");
        ImGui.SameLine();
        if (ImGui.BeginCombo("##branchSelector", "master")) {
            ImGui.Selectable("master");
            ImGui.Selectable("develop");
            ImGui.Selectable("feature/new-feature");
            ImGui.EndCombo();
        }

        ImGui.NextColumn();
        ImGui.NextColumn();
        ImGui.NextColumn();
        ImGui.NextColumn();
        ImGui.NextColumn();

        // Barra de progreso alineada a la derecha
        ImGui.ProgressBar(0.2, new ImVec2(150, 20), "3/15");
    }
    ImGui.End();
}

requestAnimationFrame(frame);
