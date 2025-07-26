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
    const menuDockHeight = 27;
    const menuBarHeight = ImGui.GetFrameHeight() + menuDockHeight; // Altura de la barra de menú superior
    const bottomMenuHeight = 40; // Altura fija del menú inferior

    // Calcula las áreas
    const width = canvas.width;
    const height = canvas.height - menuBarHeight - bottomMenuHeight;
  
    // Calcula el área disponible quitando menú superior e inferior
    const style = ImGui.GetStyle();
    const windowWidth = width / 3;
    const windowPosX = 0;
    const windowPosY = menuBarHeight;
    
    // Posiciona y dimensiona la ventana "Inspector"
    ImGui.SetNextWindowPos(new ImVec2(windowPosX, windowPosY), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth / 2, height - (height / 3)), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Hierarchy");
    ImGui.Text("Contenido de la Jerarquía");
    ImGui.End();

    ImGui.SetNextWindowPos(new ImVec2(windowPosX, windowPosY + (height / 3) * 2), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth / 2, (height / 3)), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Plugin");
    ImGui.Text("Contenido del Plugin");
    ImGui.End();
    
    // Posiciona y dimensiona la ventana settings
    ImGui.SetNextWindowPos(new ImVec2(windowPosX + (windowWidth / 2), windowPosY), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth, height - (height / 3)), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Scene");
    ImGui.Text("Contenido de la Escena");
    ImGui.End();

    // Posiciona y dimensiona la ventana settings
    ImGui.SetNextWindowPos(new ImVec2(windowPosX + (windowWidth / 2) * 3, windowPosY), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth, height - (height / 3)), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Game");
    ImGui.Text("Contenido del Juego");
    ImGui.End();


    // Posiciona y dimensiona la ventana settings
    ImGui.SetNextWindowPos(new ImVec2(windowPosX + (windowWidth / 2) * 3, windowPosY + (height / 3) * 2), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth, height / 3), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Asset Browser");
    ImGui.Text("Contenido del Navegador de Recursos");
    ImGui.End();

    // Posiciona y dimensiona la ventana settings
    ImGui.SetNextWindowPos(new ImVec2(windowPosX + (windowWidth / 2), windowPosY + (height / 3) * 2), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth, height / 3), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Console");
    ImGui.Text("Contenido de la Consola");
    ImGui.End();
    

    // Posiciona y dimensiona la ventana "Inspector"
    ImGui.SetNextWindowPos(new ImVec2(windowPosX + (windowWidth * 2) + (windowWidth / 2), windowPosY), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2((windowWidth / 2), height - (height / 3)), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Inspector");
    ImGui.Text("Contenido del Inspector");
    ImGui.End();

    ImGui.SetNextWindowPos(new ImVec2(windowPosX + (windowWidth * 2) + (windowWidth / 2), windowPosY + (height / 3) * 2), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(windowWidth / 2, (height / 3)), ImGui.Cond.FirstUseEver);
    ImGui.Begin("Audio Player");
    ImGui.Text("Contenido del Reproductor de Audio");
    ImGui.End();
    

    // Menús
   
    //ImGui.ShowDemoWindow();
    renderMainMenuBar();
    renderMenuBar();
    renderBottomMenu();
    //await DotNet.invokeMethodAsync("Alis.App.Engine.Web", "RenderUi");


    ImGui.PopStyleColor(48);
    context.clearColor(color[0], color[1], color[2], 1.0);
    context.clear(context.COLOR_BUFFER_BIT);

    ImGuiImplWeb.EndRenderWebGL();

    requestAnimationFrame(frame);
}

function renderMenuBar() {
    const style = ImGui.GetStyle();
    const menuBarHeight = 25;
    ImGui.SetNextWindowPos(new ImVec2(0, 25), ImGui.Cond.FirstUseEver);
    ImGui.SetNextWindowSize(new ImVec2(canvas.width, menuBarHeight), ImGui.Cond.FirstUseEver);

    // Parámetros de estilo
    style.WindowRounding = 0.0;
    style.ChildRounding = 0.0;
    style.FrameRounding = 0.0;

    style.WindowPadding = new ImVec2(0, 0);
    //style.FramePadding = new ImVec2(0, 0);
    //style.ItemSpacing = new ImVec2(0, 0);
    //style.ItemInnerSpacing = new ImVec2(0, 0);
    
    
    if (ImGui.Begin("MenuBarWindow", null,
        ImGui.WindowFlags.NoTitleBar |
        ImGui.WindowFlags.NoResize |
        ImGui.WindowFlags.NoMove |
        ImGui.WindowFlags.NoScrollbar |
        ImGui.WindowFlags.NoSavedSettings |
        ImGui.WindowFlags.NoCollapse |
        ImGui.WindowFlags.NoBringToFrontOnFocus
    )) {
        // Botones de navegación izquierda
        if (ImGui.Button("⏪")) { /* Acción volver atrás */ }
        ImGui.SameLine();
        if (ImGui.Button("⏩")) { /* Acción adelante */ }

        // Centrar los botones de control
        const windowWidth = ImGui.GetWindowSize().x;
        const buttonWidth = 40 * 3 + 20 * 2; // 3 botones + 2 espacios
        const centerPos = (windowWidth - buttonWidth) / 2;
        ImGui.SameLine(centerPos);

        if (ImGui.Button("▶️")) { /* Acción play */ }
        ImGui.SameLine();
        if (ImGui.Button("⏸️")) { /* Acción pausa */ }
        ImGui.SameLine();
        if (ImGui.Button("⏹️")) { /* Acción stop */ }
    }
    ImGui.End();

   

    // Parámetros de estilo
    style.WindowRounding = 0.0;
    style.ChildRounding = 4.0;
    style.FrameRounding = 4.0;

    style.WindowPadding = new ImVec2(10, 10);
    style.FramePadding = new ImVec2(6, 6);
    style.ItemSpacing = new ImVec2(6, 6);
    style.ItemInnerSpacing = new ImVec2(6, 6);
}

function renderMainMenuBar() {
    
    const labelMenu = "File";
    const labelNew = "New";
    const labelOpen = "Open";
    const labelSave = "Save";
    
    
    if(ImGui.BeginMainMenuBar()) 
    {
        // File Menu
        if (ImGui.BeginMenu(labelMenu)) {
            if (ImGui.MenuItem(labelNew, "ctrl+n")) {
                console.log("New file created");
            }
            if (ImGui.MenuItem(labelOpen, "ctrl+o")) {
                console.log("Open file dialog");
            }
            if (ImGui.MenuItem(labelSave, "ctrl+s")) {
                console.log("Save file");
            }
            ImGui.EndMenu();
        }
        ImGui.EndMainMenuBar();
    }
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
