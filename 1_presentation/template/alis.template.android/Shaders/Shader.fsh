#version 300 es

in highp vec3 vertexE;
in highp vec3 normalE;
in highp float angle;
flat in highp int instance;

out lowp vec4 fragColor;

uniform highp vec3 light;

void main()
{
    highp vec3 L = normalize (light - vertexE);
    highp vec3 E = normalize (-vertexE);
    highp vec3 R = normalize (-reflect (L, normalE));

    lowp vec4 amb = vec4 (.33f, .33f, .33f, 1.0f);
    lowp vec4 diff = vec4 (.8f, .8f, .8f, 1.0f) * max(dot(normalE,L), 0.0);
    diff = clamp (diff, 0.0, 1.0f);

    fragColor = amb + diff * vec4 (cos(angle)/3.0f + 0.33f, cos(angle)/3.0f + 0.33f, sin(angle)/3.0f + 0.33f, 1.0f);
}

