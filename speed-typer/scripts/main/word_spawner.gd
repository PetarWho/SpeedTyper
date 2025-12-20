extends Node
class_name WordSpawner

@export var word_scene: PackedScene
@export var word_canvas_path: NodePath

func SpawnWord() -> WordDisplay:
	if word_scene == null:
		return null
	var canvas := get_node_or_null(word_canvas_path)
	if canvas == null:
		canvas = self
	var display := word_scene.instantiate() as WordDisplay
	var viewport_size := get_viewport().get_visible_rect().size
	var min_x := 0.0
	var max_x := viewport_size.x
	var start_y := 0.0
	display.position = Vector2(randf_range(min_x, max_x), start_y)
	canvas.add_child(display)
	return display
