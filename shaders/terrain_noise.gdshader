shader_type canvas_item;

uniform vec2 camera_offset;

void fragment() {
    vec2 shifted_uv = UV + (camera_offset * 0.001); 
    
    COLOR = texture(TEXTURE, shifted_uv);
}