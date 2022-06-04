#version 300 es

in vec4 position;
in vec4 normal;
in vec2 texcoord;

out vec3 vertexE;
out vec3 normalE;
out float angle;
flat out int instance;

uniform float translate;
uniform mat4 projection;
uniform mat4 view;
uniform mat4 normalMatrix;
uniform int count;

#define PI 3.141592653589793f

void main()
{
    float mi = mod(float(gl_InstanceID), 2.0f);
    angle = 2.0f * PI * float(gl_InstanceID) / 24.0f;
    float cangle = angle + (mi * 2.0f - 1.0f) * 2.0f * PI * float(count) / (5.0f * 60.0f);
    vec4 vpos = position + 10.0f * (1.0f + 0.3f * mi) * vec4(cos(cangle), sin(cangle), 0, 0);
    vertexE = (view * position).xyz;
    normalE = normalize((normalMatrix * normal).xyz);
    gl_Position = projection * vpos;
    instance = gl_InstanceID;
}

