extends Node

@export var delay_before_loading: float = 3.0
@export var scene_path: String = "res://scenes/LoadingScreen.tscn"

var _time_elapsed: float = 0.0

func _process(delta: float) -> void:
	_time_elapsed += delta
	if _time_elapsed > delay_before_loading and scene_path != "":
		get_tree().change_scene_to_file(scene_path)
